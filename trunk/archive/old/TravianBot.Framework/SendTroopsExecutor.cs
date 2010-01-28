using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;

namespace TravianBot.Framework
{
    public class SendTroopsExecutor : IExecutor
    {
        public SendTroopsExecutor(ServerInfo serverInfo)
        {
            //DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\sendtroops");
            DirectoryInfo di = new DirectoryInfo(Misc.GetConfigValue("sendTroopsDirectory"));
            FileInfo[] attackFiles = di.GetFiles("*.xml");
            foreach (FileInfo attackFile in attackFiles)
            {
                //Console.WriteLine("Found '{0}' in '{1}'", attackFile, di.FullName);
                fileNames.Add(attackFile.FullName);
            }
            this.serverInfo = serverInfo;
        }

        public ActionContainer ActionContainer
        {
            get { return actionContainer; }
        }

        public ActionList ActionList
        {
            get { return actionList; }
        }

        public void Parse()
        {
            foreach (string fileName in fileNames)
            {
                using (Stream xmlStream = File.OpenRead(fileName))
                {
                    actionList = new ActionList();
                    using (ActionParser actionParser = new ActionParser(xmlStream))
                    {
                        //Console.WriteLine("Parsing '{0}'", fileName);
                        actionList = actionParser.Parse();
                    }
                    actionContainer = new ActionContainer();
                    actionContainer.AddActionList(fileName, actionList);
                }
            }
        }

        public void Process()
        {
            Random random = new Random(99999999);
            foreach (KeyValuePair<string, ActionList> container in actionContainer.ActionsContainer)
            {
                string tempFile = String.Format(CultureInfo.InvariantCulture, "{0}.temp", container.Key);
                string tempContent = Misc.ReadContent(tempFile);
                bool attackIdFound = false;
                foreach (KeyValuePair<string, Action> list in container.Value.ActionsList)
                {
                    ActionParameters parameters = list.Value.GetActionParameters(list.Key);
                    //ActionParameters @param = container.Value.ActionsList[action.Key].ActionParameters[i];
                    int enabled = parameters.Enabled;
                    if (enabled != 1)
                    {
                        continue;
                    }
                    string actionId = parameters.Id;
                    string tempId = String.Format(CultureInfo.InvariantCulture, ".{0}.", actionId);
                    if (tempContent.IndexOf(tempId) == -1)
                    {
                        attackIdFound = true;
                        int unitCount = parameters.UnitCount;
                        int availableUnits = GetAvailableUnitCount(parameters);
                        if (availableUnits > unitCount)
                        {
                            DateTime now = new DateTime(DateTime.Now.Ticks);
                            Console.WriteLine("{0} We have {1} {2}. Attacking '{3}[{4}]' with {5}!",
                                              now.ToString("yyyy-MM-dd HH:mm:ss"),
                                              availableUnits,
                                              parameters.UnitName,
                                              parameters.PlayerName,
                                              parameters.VillageName,
                                              parameters.UnitCount);
                            ExecuteAttack(parameters);
                            Misc.WriteData(tempFile, tempId, true);
                        }
                        else
                        {
                            break;
                        }
                        Thread.Sleep(random.Next(5000, 15000));
                    }
                }
                if (!attackIdFound)
                {
                    Misc.WriteData(tempFile, "", false);
                }
            }
        }

        private void ExecuteAttack(ActionParameters parameters)
        {
            //b=1&t1=&t4=&t7=&t9=&t2=&t5=&t8=&t10=&t3=29&t6=&c=4&dname=&x=-16&y=-93&s1.x=22&s1.y=8&s1=ok
            //<input type="hidden" name="id" value="39">
            //<input type="hidden" name="a" value="18979">
            //<input type="hidden" name="c" value="4">
            //<input type="hidden" name="kid" value="396080">

            //id=39&a=47889&c=4&kid=395278&t1=0&t2=0&t3=29&t4=0&t5=0&t6=0&t7=0&t8=0&t9=0&t10=0&t11=0&s1.x=39&s1.y=9&s1=ok
            StringBuilder troops = new StringBuilder();
            for (int t = 0; t < 11; t++)
            {
                troops.AppendFormat("&t{0}={1}", (t + 1), t == parameters.UnitId ? parameters.UnitCount : 0);
            }
            Random rnd = new Random();
            String postData = String.Format(CultureInfo.InvariantCulture,
                                            "id=39&a={0}&c={1}&kid={2}{3}{4}",
                                            rnd.Next(10001, 99999),
                                            parameters.SendTroopType,
                                            Misc.ConvertXY(parameters.CoordinateX, parameters.CoordinateY),
                                            troops,
                                            String.Format("&s1.x={0}&s1.y={1}&s1=ok", rnd.Next(0, 79), rnd.Next(0, 19)));

            string url = String.Format(CultureInfo.InvariantCulture, "{0}?newdid={1}", serverInfo.SendUnitsUrl, parameters.VillageId);
            Http.SendData(url, postData, serverInfo.CookieContainer, serverInfo.CookieCollection);
        }

        private int GetAvailableUnitCount(ActionParameters parameters)
        {
            int villageId = parameters.VillageId;
            string url = String.Format(CultureInfo.InvariantCulture, "{0}?newdid={1}", serverInfo.Dorf1Url, villageId);
            string pageSource = Http.SendData(url, null, serverInfo.CookieContainer, serverInfo.CookieCollection);
            HtmlParser htmlParser = new HtmlParser(pageSource);
            htmlParser.ParseUnitsInVillage(serverInfo, villageId);
            Unit units = serverInfo.GetVillage(villageId).GetUnit(parameters.UnitName);
            return units != null ? units.UnitCount : 0;
        }

        private ActionContainer actionContainer;
        private ActionList actionList;
        private readonly List<string> fileNames = new List<string>();
        private readonly ServerInfo serverInfo;
    }
}
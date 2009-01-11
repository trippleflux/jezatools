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
            foreach (KeyValuePair<string, ActionList> container in actionContainer.ActionsContainer)
            {
                string tempFile = String.Format(CultureInfo.InvariantCulture, "{0}.temp", container.Key);
                string tempContent = Misc.ReadContent(tempFile);
                bool attackIdFound = false;
                foreach (KeyValuePair<string, Action> list in container.Value.ActionsList)
                {
                    ActionParameters @param = list.Value.GetActionParameters(list.Key);
                    //ActionParameters @param = container.Value.ActionsList[action.Key].ActionParameters[i];
                    int enabled = @param.Enabled;
                    if (enabled != 1)
                    {
                        continue;
                    }
                    string actionId = @param.Id;
                    string tempId = String.Format(CultureInfo.InvariantCulture, ".{0}.", actionId);
                    if (tempContent.IndexOf(tempId) == -1)
                    {
                        attackIdFound = true;
                        int unitCount = @param.UnitCount;
                        int availableUnits = GetAvailableUnitCount(@param);
                        if (availableUnits > unitCount)
                        {
                            DateTime now = new DateTime(DateTime.Now.Ticks);
                            Console.WriteLine("{0} We have {1} {2}. Attacking '{3}[{4}]' with {5}!",
                                              now.ToString("yyyy-MM-dd HH:mm:ss"),
                                              availableUnits,
                                              @param.UnitName,
                                              @param.PlayerName,
                                              @param.VillageName,
                                              @param.UnitCount);
                            ExecuteAttack(@param);
                            Misc.WriteData(tempFile, tempId, true);
                        }
                        else
                        {
                            break;
                        }
                        Thread.Sleep(2000);
                    }
                }
                if (!attackIdFound)
                {
                    Misc.WriteData(tempFile, "", false);
                }
            }
        }

        private void ExecuteAttack(ActionParameters @param)
        {
            StringBuilder troops = new StringBuilder();
            for (int t = 0; t < 11; t++)
            {
                troops.AppendFormat("&t{0}={1}", (t + 1), t == @param.UnitId ? @param.UnitCount : 0);
            }
            Random rnd = new Random();
            String postData = String.Format(CultureInfo.InvariantCulture,
                                            "id=39&a={0}&c={1}&kid={2}{3}{4}",
                                            rnd.Next(10001, 99999),
                                            @param.SendTroopType,
                                            Misc.ConvertXY(@param.CoordinateX, @param.CoordinateY),
                                            troops,
                                            String.Format("&s1.x={0}&s1.y={1}&s1=ok", rnd.Next(0, 79), rnd.Next(0, 19)));

            string url = String.Format(CultureInfo.InvariantCulture, "{0}?newdid={1}", serverInfo.SendUnitsUrl, @param.VillageId);
            Http.SendData(url, postData, serverInfo.CookieContainer, serverInfo.CookieCollection);
        }

        private int GetAvailableUnitCount(ActionParameters @param)
        {
            int villageId = @param.VillageId;
            string url = String.Format(CultureInfo.InvariantCulture, "{0}?newdid={1}", serverInfo.Dorf1Url, villageId);
            string pageSource = Http.SendData(url, null, serverInfo.CookieContainer, serverInfo.CookieCollection);
            HtmlParser htmlParser = new HtmlParser(pageSource);
            htmlParser.ParseUnitsInVillage(serverInfo, villageId);
            Unit units = serverInfo.GetVillage(villageId).GetUnit(@param.UnitName);
            return units != null ? units.UnitCount : 0;
        }

        private ActionContainer actionContainer;
        private ActionList actionList;
        private readonly List<string> fileNames = new List<string>();
        private readonly ServerInfo serverInfo;
    }
}
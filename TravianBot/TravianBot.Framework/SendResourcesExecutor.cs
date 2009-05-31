#region

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

#endregion

namespace TravianBot.Framework
{
    public class SendResourcesExecutor
    {
        public SendResourcesExecutor(ServerInfo serverInfo)
        {
            DirectoryInfo di = new DirectoryInfo(Misc.GetConfigValue("sendResourcesDirectory"));
            FileInfo[] files = di.GetFiles("*.xml");
            foreach (FileInfo file in files)
            {
                //Console.WriteLine("Found '{0}' in '{1}'", file, di.FullName);
                fileNames.Add(file.FullName);
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
                //Console.WriteLine(container.ToString());
                foreach (Action action in container.Value.SendResourcesList)
                {
                    SendResourcesParameters parameters = action.GetResourceSendParameters(action.Id);
                    int enabled = parameters.Enabled;
                    //Console.WriteLine(parameters);
                    if (enabled != 1)
                    {
                        continue;
                    }
                    if (!EnoughResources(parameters))
                    {
                        continue;
                    }
                    //Console.WriteLine("send");
                    if (SendResources(parameters))
                    {
                        DateTime now = new DateTime(DateTime.Now.Ticks);
                        Console.WriteLine("{0} Sending [{1}, {2}, {3}, {4}] to ({5}|{6})!",
                                          now.ToString("yyyy-MM-dd HH:mm:ss"),
                                          parameters.WoodAmount,
                                          parameters.ClayAmount,
                                          parameters.IronAmount,
                                          parameters.CropAmount,
                                          parameters.DestinationVillageX,
                                          parameters.DestinationVillageY);
                    }
                }
            }
        }

        private bool EnoughResources(SendResourcesParameters parameters)
        {
            string url = String.Format(CultureInfo.InvariantCulture, "{0}?newdid={1}", serverInfo.Dorf1Url,
                                       parameters.SourceVillageId);
            string pageSource = Http.SendData(url, null, serverInfo.CookieContainer, serverInfo.CookieCollection);
            HtmlParser htmlParser = new HtmlParser(pageSource);
            Village village = new Village(parameters.SourceVillageId, "noName");
            htmlParser.ParseVillageProduction(village);
            if (village.WoodAvailable < parameters.WoodAmount
                || village.ClayAvailable < parameters.ClayAmount
                || village.IronAvailable < parameters.IronAmount
                || village.CropAvailable < parameters.CropAmount)
            {
                return false;
            }
            return true;
        }

        private bool SendResources(SendResourcesParameters parameters)
        {
            //id=33&r1=&r2=&r3=20000&r4=&dname=&x=-16&y=-93&s1.x=27&s1.y=14&s1=ok
            //id=33&r1=172&r2=206&r3=172&r4=100&dname=&x=-15&y=-93&s1.x=35&s1.y=5&s1=ok
            //<input type="hidden" name="id" value="33">
            //<input type="hidden" name="a" value="83117">
            //<input type="hidden" name="sz" value="47406">
            //<input type="hidden" name="kid" value="395278">
            Random rnd = new Random();
            String button = String.Format(CultureInfo.InvariantCulture,
                                          "&s1.x={0}&s1.y={1}&s1=ok",
                                          rnd.Next(0, 79),
                                          rnd.Next(0, 19));
            StringBuilder resources = new StringBuilder();
            resources.Append("&r1=" + parameters.WoodAmount);
            resources.Append("&r2=" + parameters.ClayAmount);
            resources.Append("&r3=" + parameters.IronAmount);
            resources.Append("&r4=" + parameters.CropAmount);
            String postData = String.Format(CultureInfo.InvariantCulture,
                                            "id=33{0}&dname=&x={1}&y={2}{3}",
                                            resources,
                                            parameters.DestinationVillageX,
                                            parameters.DestinationVillageY,
                                            button);
            string url = String.Format(CultureInfo.InvariantCulture, "{0}?newdid={1}&gid=17", serverInfo.BuildUrl,
                                       parameters.SourceVillageId);
            string pageSource = Http.SendData(url, postData, serverInfo.CookieContainer, serverInfo.CookieCollection);
            HtmlParser htmlParser = new HtmlParser(pageSource);
            int sz = htmlParser.ParseMarketPlaceHiddenData();
            if (sz == -1)
            {
                return false;
            }
            //id=33&a=83117&sz=47406&kid=395278&r1=&r2=&r3=20000&r4=&s1.x=24&s1.y=11&s1=ok
            //id=33&a=93284&sz=53492&kid=395279&r1=172&r2=206&r3=172&r4=100&s1.x=26&s1.y=10&s1=ok
            button = String.Format(CultureInfo.InvariantCulture,
                                   "&s1.x={0}&s1.y={1}&s1=ok",
                                   rnd.Next(0, 79),
                                   rnd.Next(0, 19));
            postData = String.Format(CultureInfo.InvariantCulture,
                                     "id=33&a={0}&sz={1}&kid={2}{3}{4}",
                                     parameters.SourceVillageId,
                                     sz,
                                     Misc.ConvertXY(parameters.DestinationVillageX, parameters.DestinationVillageY),
                                     resources,
                                     button);
            Http.SendData(url, postData, serverInfo.CookieContainer, serverInfo.CookieCollection);
            return true;
        }

        private ActionContainer actionContainer;
        private ActionList actionList;
        private readonly List<string> fileNames = new List<string>();
        private readonly ServerInfo serverInfo;
    }
}
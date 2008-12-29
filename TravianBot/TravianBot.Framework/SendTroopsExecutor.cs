using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
                Stream xmlStream = File.OpenRead(fileName);
                actionList = new ActionList();
                using (ActionParser actionParser = new ActionParser(xmlStream))
                {
                    actionList = actionParser.Parse();
                }
                actionContainer = new ActionContainer();
                actionContainer.AddActionList(fileName, actionList);
            }
        }

        public void Process()
        {
            foreach (KeyValuePair<string, ActionList> container in actionContainer.ActionsContainer)
            {
                int i = 0;
                string tempFile = String.Format(CultureInfo.InvariantCulture, "{0}.temp", container.Key);
                string tempContent = Misc.ReadContent(tempFile);
                bool attackIdFound = false;
                foreach (KeyValuePair<string, Action> action in container.Value.ActionsList)
                {
                    ActionParameters @param = action.Value.ActionParameters[i];
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
                            ProcessWithAttack(action);
                        }
                        else
                        {
                            break;
                        }
                        Thread.Sleep(2000);
                    }
                    if (!attackIdFound)
                    {
                        Misc.WriteData(tempFile, "", false);
                    }
                    i++;
                }
            }
        }

        private static void ProcessWithAttack(KeyValuePair<string, Action> action)
        {
            
        }

        private int GetAvailableUnitCount(ActionParameters @param)
        {
            int villageId = @param.VillageId;
            string url = String.Format(CultureInfo.InvariantCulture, "{0}?newdid={1}", serverInfo.Dorf1Url, villageId);
            string pageSource = Http.SendData(url, null, serverInfo.CookieContainer, serverInfo.CookieCollection);
            HtmlParser htmlParser = new HtmlParser(pageSource);
            htmlParser.ParseUnitsInVillage(serverInfo, villageId);
            return serverInfo.GetVillage(villageId).GetUnit(@param.UnitName).UnitCount;
        }

        private ActionContainer actionContainer;
        private ActionList actionList;
        private readonly List<string> fileNames = new List<string>();
        private readonly ServerInfo serverInfo;
    }
}
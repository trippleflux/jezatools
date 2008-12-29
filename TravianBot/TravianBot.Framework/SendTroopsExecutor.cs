using System.Collections.Generic;
using System.IO;

namespace TravianBot.Framework
{
    public class SendTroopsExecutor : IExecutor
    {
        public SendTroopsExecutor()
        {
            //DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\sendtroops");
            DirectoryInfo di = new DirectoryInfo(Misc.GetConfigValue("sendTroopsDirectory"));
            FileInfo[] attackFiles = di.GetFiles("*.xml");
            foreach (FileInfo attackFile in attackFiles)
            {
                fileNames.Add(attackFile.FullName);
            }
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
            foreach (string fileName in fileNames)
            {

            }
        }

        private ActionContainer actionContainer;
        private ActionList actionList;
        private readonly List<string> fileNames = new List<string>();
    }
}
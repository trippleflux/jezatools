using System.Collections.Generic;
using System.IO;

namespace TravianBot.Framework
{
    public class SendTroopsExecutor : IExecutor
    {
        public ActionList ActionList
        {
            get { return actionList; }
        }

        public IList<string> FileNames
        {
            get { return fileNames; }
        }

        public SendTroopsExecutor()
        {
            DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\sendtroops");
            FileInfo[] attackFiles = di.GetFiles("*.xml");
            foreach (FileInfo attackFile in attackFiles)
            {
                fileNames.Add(attackFile.FullName);
            }
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
                ActionContainer actionContainer = new ActionContainer();
                actionContainer.AddActionList(fileName, actionList);
            }
        }

        public void Process()
        {

        }

        private ActionList actionList;
        private readonly List<string> fileNames;
    }
}
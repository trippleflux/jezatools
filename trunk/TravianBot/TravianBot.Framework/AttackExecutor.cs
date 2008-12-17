using System.IO;

namespace TravianBot.Framework
{
    public class AttackExecutor : IExecutor
    {
        /// <summary>
        /// Parses XML file with execution actions.
        /// </summary>
        public void Parse(string fileName)
        {
            FileInfo[] troopSendFiles = GetTroopSendFiles();
            foreach (FileInfo troopSendFile in troopSendFiles)
            {

            }
        }

        public void Process()
        {
            throw new System.NotImplementedException();
        }

        private static FileInfo[] GetTroopSendFiles()
        {
            DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\troopsend");
            return di.GetFiles("*.xml");
        }
    }
}
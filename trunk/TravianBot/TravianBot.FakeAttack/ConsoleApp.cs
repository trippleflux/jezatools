using System;
using System.Collections;
using System.IO;

namespace TravianBot.FakeAttack
{
    public class ConsoleApp
    {
        public void CheckAliance(ArrayList alianceIds)
        {
            foreach (int alianceId in alianceIds)
            {
                if (alianceId > 0)
                {
                    alianceOK = false;
                    break;
                }
            }
        }

        public void ParseConfig()
        {
            FileInfo fileInfo = new FileInfo("FakeAttack.xml");
            using (Stream xmlStream = File.OpenRead(fileInfo.FullName))
            {
                //actionList = new ActionList();
                //using (ActionParser actionParser = new ActionParser(xmlStream))
                //{
                //    actionList = actionParser.Parse();
                //}
            }
        }

        public void Process()
        {
            if(alianceOK)
            {
                ExecuteFakeAttacks();
            }
            else
            {
                SendInfo();
            }
        }

        private static void SendInfo()
        {
            throw new NotImplementedException();
        }

        private static void ExecuteFakeAttacks()
        {
            throw new NotImplementedException();
        }

        private bool alianceOK;
    }
}
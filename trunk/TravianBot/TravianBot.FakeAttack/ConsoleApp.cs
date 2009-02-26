using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using TravianBot.Framework;
using Action=TravianBot.Framework.Action;

namespace TravianBot.FakeAttack
{
    public class ConsoleApp
    {
        public bool CheckAliance(ArrayList alianceIds)
        {
            foreach (int alianceId in alianceIds)
            {
                if (alianceId == serverInfo.AlianceId)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ConnectToserver()
        {
            try
            {
                ShowBanner();
                LoginPageData loginPageData = new LoginPageData(serverInfo);
                bool logedIn = Misc.Login(serverInfo, loginPageData);
                if (logedIn)
                {
                    logedIn = Misc.IsLogedIn(serverInfo, null);
                    if (logedIn)
                    {
                        Misc.UpdateVillages(serverInfo);
                        return true;
                    }
                }
                Console.WriteLine("Not loged in ...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return false;
        }

        public void ParseConfig()
        {
            FileInfo fileInfo = new FileInfo("FakeAttack.xml");
            using (Stream xmlStream = File.OpenRead(fileInfo.FullName))
            {
                actionList = new ActionList();
                using (ActionParser actionParser = new ActionParser(xmlStream))
                {
                    actionList = actionParser.Parse();
                }
            }
        }

        public void Process()
        {
            foreach (Action action in actionList.FakeActionList)
            {
                string id = action.Id;
                FakeParamaters parameters = action.GetFakeActionParameters(id);
                foreach (string villageKoordinates in GetVillages(parameters.UserIdUrl))
                {
                    ExecuteFakeAttack(parameters, villageKoordinates);
                }
            }
        }

        private List<string> GetVillages(string userIdUrl)
        {
            string pageSource = 
                Http.SendData(userIdUrl, null, serverInfo.CookieContainer, serverInfo.CookieCollection);
            //<td>(-33|128)</td>
            const string patternUserVillages = @"([-]?\d+\|[-]?\d+)";
            MatchCollection alianceVillagesCollection =
                Regex.Matches(pageSource, patternUserVillages);
            int villages = alianceVillagesCollection.Count;
            List<string> villageList = new List<string>();
            for (int i = 0; i < villages; i++)
            {
                villageList.Add(alianceVillagesCollection[i].Groups[1].Value.Trim());
            }
            return villageList;
        }

        private static void ExecuteFakeAttack(FakeParamaters fakeParamaters, string villageKoordinates)
        {
            string[] possition = villageKoordinates.Split('|');
            //Console.WriteLine("{0} [{1}]", parameters.UserIdUrl, villageKoordinates);
            throw new NotImplementedException();
        }

        internal static void ShowBanner()
        {
            // ReSharper disable AssignNullToNotNullAttribute
            FileVersionInfo version = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            // ReSharper restore AssignNullToNotNullAttribute
            Console.WriteLine("TravianBot.FakeAttack v{0}", version.FileVersion);
            Console.WriteLine();
        }

        private ActionList actionList;
        readonly ServerInfo serverInfo = new ServerInfo();
    }
}
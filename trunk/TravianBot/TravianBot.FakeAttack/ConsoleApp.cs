using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
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
            const string patternUserVillages = @"<td>\(([-]?\d+\|[-]?\d+)\)</td>";
            MatchCollection villagesCollection = Regex.Matches(pageSource, patternUserVillages);
            int villages = villagesCollection.Count;
            List<string> villageList = new List<string>();
            for (int i = 0; i < villages; i++)
            {
                villageList.Add(villagesCollection[i].Groups[1].Value.Trim());
            }
            return villageList;
        }

        private void ExecuteFakeAttack(FakeParamaters fakeParamaters, string villageKoordinates)
        {
            string[] possition = villageKoordinates.Split('|');
            //Console.WriteLine("{0} [{1}]", fakeParamaters.UserIdUrl, villageKoordinates);
            Console.WriteLine("Attacking {0}", villageKoordinates);
            StringBuilder troops = new StringBuilder();
            for (int t = 0; t < 11; t++)
            {
                troops.AppendFormat("&t{0}={1}", (t + 1), t == fakeParamaters.UnitId ? 1 : 0);
            }
            Random rnd = new Random();
            String postData = String.Format(CultureInfo.InvariantCulture,
                                            "id=39&a={0}&c={1}&kid={2}{3}{4}",
                                            rnd.Next(10001, 99999),
                                            3,
                                            Misc.ConvertXY(Int32.Parse(possition[0]), Int32.Parse(possition[1])),
                                            troops,
                                            String.Format("&s1.x={0}&s1.y={1}&s1=ok", rnd.Next(0, 79), rnd.Next(0, 19)));

            string url = String.Format(CultureInfo.InvariantCulture, "{0}?newdid={1}", serverInfo.SendUnitsUrl, fakeParamaters.VillageId);
            Http.SendData(url, postData, serverInfo.CookieContainer, serverInfo.CookieCollection);
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
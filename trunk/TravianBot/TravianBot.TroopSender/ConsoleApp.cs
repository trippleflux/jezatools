using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using TravianBot.Framework;
using Action=TravianBot.Framework.Action;

namespace TravianBot.TroopSender
{
    public class ConsoleApp
    {
        public void Parse()
        {
            FileInfo fileInfo = new FileInfo("TroopSender.xml");
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
            try
            {
                ShowBanner();

                ServerInfo serverInfo = new ServerInfo();
                LoginPageData loginPageData = new LoginPageData(serverInfo);

                bool logedIn = Misc.Login(serverInfo, loginPageData);

                if (logedIn)
                {
                    int actionCount = 0;
                    int executedActions = 0;
                    Misc.UpdateVillages(serverInfo);
                    foreach (Action action in actionList.TroopSenderList)
                    {
                        string id = action.Id;
                        TroopSenderParamaters parameters = action.GetTroopSenderParameters(id);
                        actionCount = actionList.TroopSenderList.Count;
                        Console.WriteLine("Action with id '{1,2}' will be executed at {0}", parameters.Time, parameters.Id);
                    }
                    int repeatCount = 0;
                    do
                    {
                        if (repeatCount % 60 == 0)
                        {
                            logedIn = Misc.IsLogedIn(serverInfo, null);
                        }

                        if (logedIn)
                        {
                            DateTime now = new DateTime(DateTime.Now.Ticks);
                            string timeNow = now.ToString("yyyy-MM-dd HH:mm:ss");

                            foreach (Action action in actionList.TroopSenderList)
                            {
                                string id = action.Id;
                                TroopSenderParamaters parameters = action.GetTroopSenderParameters(id);
                                if (parameters.Time == timeNow)
                                {
                                    SendTroops(serverInfo, parameters);
                                    executedActions++;
                                    Console.WriteLine("{0} Executing action with id '{1}'. {2} more action(s) pending for execution.", timeNow, parameters.Id, (actionCount - executedActions));
                                }
                            }

                            repeatCount++;
                            if (repeatCount > 100)
                            {
                                repeatCount = 0;
                            }
                            if (actionCount == executedActions)
                            {
                                repeatCount = 9999999;
                                Console.WriteLine("{0} All Actions executed...", timeNow);
                            }
                        }
                        else
                        {
                            Misc.Login(serverInfo, loginPageData);
                        }
                        Thread.Sleep(1000);
                    } while (repeatCount < 1000);
                }
                else
                {
                    Console.WriteLine("Not loged in ...");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void SendTroops(ServerInfo serverInfo,
                               TroopSenderParamaters parameters)
        {
            //kata=15&kata2=11&id=39&a=15822&c=3&kid=395278&t1=0&t2=0&t3=0&t4=0&t5=0&t6=22&t7=0&t8=158&t9=0&t10=0&t11=0&s1.x=33&s1.y=5&s1=ok
            StringBuilder troops = new StringBuilder();
            string[] units = parameters.TroopList.Split(' ');
            for (int t = 0; t < 11; t++)
            {
                troops.AppendFormat("&t{0}={1}", (t + 1), units[t]);
            }
            Random rnd = new Random();
            String postData = String.Format(CultureInfo.InvariantCulture,
                                            "{5}id=39&a={0}&c={1}&kid={2}{3}{4}",
                                            rnd.Next(10001, 99999),
                                            parameters.AttackType,
                                            Misc.ConvertXY(parameters.DestX, parameters.DestY),
                                            troops,
                                            String.Format("&s1.x={0}&s1.y={1}&s1=ok", rnd.Next(0, 79), rnd.Next(0, 19)),
                                            parameters.UseKatas == 1 ? String.Format("kata={0}&kata2={1}&", parameters.KataDest1, parameters.KataDest2) : "");

            string url = String.Format(CultureInfo.InvariantCulture, "{0}?newdid={1}", serverInfo.SendUnitsUrl, parameters.VillageId);
            Http.SendData(url, postData, serverInfo.CookieContainer, serverInfo.CookieCollection);

        }

        internal static void ShowBanner()
        {
            // ReSharper disable AssignNullToNotNullAttribute
            FileVersionInfo version = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            // ReSharper restore AssignNullToNotNullAttribute
            Console.WriteLine("TravianBot.TroopSender v{0}", version.FileVersion);
            Console.WriteLine();
        }

        private ActionList actionList;
    }
}
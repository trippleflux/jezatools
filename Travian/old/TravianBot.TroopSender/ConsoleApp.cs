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
                Thread[] thread = new Thread[actionList.TroopSenderList.Count];

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
                                    //Send.SendTroops(serverInfo, parameters);
                                    Send send = new Send(serverInfo, parameters);
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
using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using TravianBot.Framework;

namespace TravianBot.Runner
{
    public class ConsoleApp
    {
        public void Process()
        {
            try
            {
                ShowBanner();
                //Misc.CreateDB();

                ServerInfo serverInfo = new ServerInfo();
                LoginPageData loginPageData = new LoginPageData(serverInfo);

                bool logedIn = Misc.Login(serverInfo, loginPageData);

                if (logedIn)
                {
                    Misc.UpdateVillages(serverInfo);
                    int repeatCount = 0;
                    do
                    {
                        logedIn = Misc.IsLogedIn(serverInfo, null);

                        if (logedIn)
                        {
                            //DateTime now = new DateTime(DateTime.Now.Ticks);
                            //Console.WriteLine(now.ToLocalTime());

                            if (repeatCount % 600 == 0)
                            {
                                #region update village names and ids

                                Misc.UpdateVillages(serverInfo);

                                #endregion
                            }

                            if (repeatCount % 1 == 0)
                            {
                                #region attacks

                                SendTroopsExecutor sendTroopsExecutor = new SendTroopsExecutor(serverInfo);
                                sendTroopsExecutor.Parse();
                                sendTroopsExecutor.Process();

                                #endregion

                                #region read reports

                                ReportReader reportReader = new ReportReader(serverInfo);
                                string pageSource = Http.SendData(serverInfo.ReportsUrl, null,
                                                                  serverInfo.CookieContainer,
                                                                  serverInfo.CookieCollection);
                                reportReader.Parse(pageSource);
                                reportReader.Process();

                                #endregion
                            }

                            if (repeatCount % 30 == 0)
                            {
                                //Console.WriteLine("resources");
                                SendResourcesExecutor sendResourcesExecutor = new SendResourcesExecutor(serverInfo);
                                sendResourcesExecutor.Parse();
                                sendResourcesExecutor.Process();
                            }

                            repeatCount++;
                            if (repeatCount > 100)
                            {
                                repeatCount = 0;
                            }
                        }
                        else
                        {
                            Misc.Login(serverInfo, loginPageData);
                        }
                        Thread.Sleep(60000);
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
            Console.WriteLine("TravianBot.Runner v{0}", version.FileVersion);
            Console.WriteLine();
        }
    }
}
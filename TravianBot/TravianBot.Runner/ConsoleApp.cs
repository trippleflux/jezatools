using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using TravianBot.Framework;

namespace TravianBot.Runner
{
    public class ConsoleApp
    {
        public ConsoleApp(string[] args)
        {
            this.args = args;
        }

        public string[] Args
        {
            get { return args; }
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
                    int repeatCount = 0;
                    do
                    {
                        logedIn = Misc.IsLogedIn(serverInfo, null);

                        if (logedIn)
                        {
                            //DateTime now = new DateTime(DateTime.Now.Ticks);
                            //Console.WriteLine(now.ToLocalTime());

                            if (repeatCount % 1 == 0)
                            {
                                #region attacks


                                #endregion

                                #region read reports

                                IReader reportReader = new ReportReader(serverInfo);
                                reportReader.Parse();
                                reportReader.Process();

                                #endregion

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

        private readonly string[] args;
    }
}
using System;
using System.Globalization;
using System.Threading;
using mshtml;
using SHDocVw;
using twL;

namespace twC
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                const string serverUrl = "http://s6.travian.si/";
                const string username = "jeza";
                const string password = "kepek";
                const string buildTasks = "tasks.txt";

                ServerInfo si = new ServerInfo
                                    {
                                        ServerUrl = serverUrl,
                                        LoginPage =
                                            String.Format(CultureInfo.InvariantCulture, "{0}login.php", serverUrl),
                                        ResourcesPage =
                                            String.Format(CultureInfo.InvariantCulture, "{0}dorf1.php", serverUrl),
                                        VillagePage =
                                            String.Format(CultureInfo.InvariantCulture, "{0}dorf2.php", serverUrl),
                                        SendUnitsPage =
                                            String.Format(CultureInfo.InvariantCulture, "{0}a2b.php", serverUrl)
                                    };
                PlayerInfo pi = new PlayerInfo
                                    {
                                        Username = username,
                                        Password = password
                                    };

                Events e = new Events();
                int repeatCount = 0;
                do
                {
                    InternetExplorer ie = new InternetExplorerClass();
                    HTMLDocument pageSource = Browser.Login(si, pi, ie);
                    if (pageSource != null)
                    {
                        bool isLogenIn = Browser.IsLogenIn(pageSource, pi);
                        if (!isLogenIn)
                        {
                            Console.WriteLine("Not Loged In...");
                            Console.WriteLine(pageSource.body.innerText);
                        }
                        else
                        {
                            #region Load Build Tasks every minute
                            if (!IO.LoadTasks(buildTasks, e))
                            {
                                Console.WriteLine("File '{0}' Not Found!", buildTasks);
                            }

                            #endregion

                            #region Build every 5 minutes

                            DateTime now = new DateTime(DateTime.Now.Ticks);
                            if (repeatCount%5 == 0)
                            {
                                foreach (var task in e.TaskList)
                                {
                                    BuildTask bt = task as BuildTask;
                                    if (bt != null)
                                    {
                                        if (bt.NextCheck < now)
                                        {
                                            bt.NextCheck = Browser.TryToBuild(ie, bt, si);
                                        }
                                    }
                                }
                            }

                            #endregion

                            #region Attack every minute if units available

                            #endregion
                        }
                    }

                    repeatCount++;
                    if (repeatCount > 100)
                    {
                        repeatCount = 0;
                    }
                    Thread.Sleep(60000);
                } while (repeatCount < 1000);
            }
            catch (Exception exception)
            {
                {
                    Console.WriteLine(exception);
                }
                throw;
            }
        }
    }
}
#region

using System;
using System.Globalization;
using System.Threading;
using mshtml;
using SHDocVw;
using twL;

#endregion

namespace twC
{
    internal class Program
    {
        //[STAThread]
        private static void Main()
        {
            try
            {
                const string serverUrl = "http://s4.travian.si/";
                const string username = "jeza";
                const string password = "kepek";
                const string buildTasks = "c:\\temp\\tasks.txt";

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
                                            String.Format(CultureInfo.InvariantCulture, "{0}a2b.php", serverUrl),
                                        UpgradeBuildingPage =
                                            String.Format(CultureInfo.InvariantCulture, "{0}build.php", serverUrl),
                                    };
                PlayerInfo pi = new PlayerInfo
                                    {
                                        Username = username,
                                        Password = password
                                    };

                Events e = new Events();
                InternetExplorer ie = new InternetExplorerClass();
                HTMLDocument pageSource = Browser.Login(si, pi, ie);
                bool isLogedIn = Browser.GetIsLogenIn(si, pi, ie, pageSource);

                if (isLogedIn)
                {
                    int repeatCount = 0;
                    do
                    {
                        pageSource = Browser.GetPageSource(si.ResourcesPage, ie);
                        isLogedIn = Browser.GetIsLogenIn(si, pi, ie, pageSource);
                        if (isLogedIn)
                        {
                            #region Load And Refresh Build Tasks every 5 minutes

                            if (repeatCount%5 == 0)
                            {
                                if (!IO.LoadTasks(buildTasks, e, ie, si))
                                {
                                    Console.WriteLine("File '{0}' Not Found!", buildTasks);
                                }
                            }

                            #endregion

                            #region Build every 3 minutes

                            DateTime now = new DateTime(DateTime.Now.Ticks);
                            if (repeatCount%3 == 0)
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

                            repeatCount++;
                            if (repeatCount > 100)
                            {
                                repeatCount = 0;
                            }
                        }
                        Thread.Sleep(60000);
                    } while (repeatCount < 1000);
                }
            }
            catch (Exception exception)
            {
                {
                    Console.WriteLine(exception);
                }
                //throw;
            }
        }
    }
}
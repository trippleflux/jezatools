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
                string serverName = Misc.GetConfigValue("serverName");
                string loginUserName = Misc.GetConfigValue("loginUserName");
                string loginPassword = Misc.GetConfigValue("loginPassword");
                string fileBuildTasks = Misc.GetConfigValue("fileBuildTasks");

                ServerInfo si = new ServerInfo
                                    {
                                        ServerUrl = serverName,
                                        LoginPage =
                                            String.Format(CultureInfo.InvariantCulture, "{0}login.php", serverName),
                                        ResourcesPage =
                                            String.Format(CultureInfo.InvariantCulture, "{0}dorf1.php", serverName),
                                        VillagePage =
                                            String.Format(CultureInfo.InvariantCulture, "{0}dorf2.php", serverName),
                                        SendUnitsPage =
                                            String.Format(CultureInfo.InvariantCulture, "{0}a2b.php", serverName),
                                        UpgradeBuildingPage =
                                            String.Format(CultureInfo.InvariantCulture, "{0}build.php", serverName),
                                    };
                PlayerInfo pi = new PlayerInfo
                                    {
                                        Username = loginUserName,
                                        Password = loginPassword
                                    };

                Events e = new Events();
                InternetExplorer ie = new InternetExplorerClass();
                HTMLDocument pageSource = Browser.Login(si, pi, ie);
                bool isLogedIn = Browser.GetIsLogedIn(si, pi, ie, pageSource);

                if (isLogedIn)
                {
					//if (!IO.LoadTasks(fileBuildTasks, e, ie, si))
					//{
					//    Console.WriteLine("File '{0}' Not Found!", fileBuildTasks);
					//}
					int repeatCount = 0;
                    do
                    {
                        pageSource = Browser.GetPageSource(si.ResourcesPage, ie);
                        isLogedIn = Browser.GetIsLogedIn(si, pi, ie, pageSource);
                        if (isLogedIn)
                        {
                            #region Load And Refresh Build Tasks every 30 minutes

                            if (repeatCount%30 == 0)
                            {
                                if (!IO.LoadTasks(fileBuildTasks, e, ie, si))
                                {
                                    Console.WriteLine("File '{0}' Not Found!", fileBuildTasks);
                                }
                            }

                            #endregion

                            #region Build every 3 minutes

                            DateTime now = new DateTime(DateTime.Now.Ticks);
                            //if (repeatCount%3 == 0)
                            {
								Console.WriteLine("{0} Checking tasks...", now.ToString(("yyyy-MM-dd HH:mm:ss")));
								foreach (var task in e.TaskList)
                                {
                                    BuildTask bt = task as BuildTask;
                                    if (bt != null)
                                    {
										Console.WriteLine("Task : {0}", bt);
										if (now.Ticks >= bt.NextCheck.Ticks)
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
				else
                {
					Console.WriteLine("Not Loged In!!!");
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
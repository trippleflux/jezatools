#region

using System;
using System.Globalization;
using System.IO;
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
				String serverName = Misc.GetConfigValue("serverName");
				String loginUserName = Misc.GetConfigValue("loginUserName");
				String loginPassword = Misc.GetConfigValue("loginPassword");
				String fileBuildTasks = Misc.GetConfigValue("fileBuildTasks");
				String fileExtensionForAttacks = Misc.GetConfigValue("fileExtensionForAttacks");
				String fileExtensionForFinishedAttacks = Misc.GetConfigValue("fileExtensionForFinishedAttacks");
				String fileTrainTroops = Misc.GetConfigValue("fileTrainTroops");
				String troopList = Misc.GetConfigValue("troopList");

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

                Attacks attacks = new Attacks
                                      {
                                          FileExtensionForAttacks = fileExtensionForAttacks,
                                          FileExtensionForFinishedAttacks = fileExtensionForFinishedAttacks,
                                          TroopList = troopList,
                                      };

			    Events e = new Events();
				InternetExplorer ie = new InternetExplorerClass();
				HTMLDocument pageSource = Browser.Login(si, pi, ie);
				bool isLogedIn = Browser.GetIsLogedIn(si, pi, ie, pageSource);

				if (isLogedIn)
				{
					int repeatCount = 0;
					do
					{
						pageSource = Browser.GetPageSource(si.ResourcesPage, ie);
						isLogedIn = Browser.GetIsLogedIn(si, pi, ie, pageSource);
						if (isLogedIn)
						{
							DateTime now = new DateTime(DateTime.Now.Ticks);
							#region Load And Refresh Build Tasks every 30 minutes

							if (repeatCount%30 == 0)
							{
								if (!IO.LoadTasks(fileBuildTasks, e, ie, si))
								{
									Console.WriteLine("File '{0}' Not Found!", fileBuildTasks);
								}
							}

							#endregion

							#region Check for build task every minute

							//Console.WriteLine("{0} Checking tasks...", now.ToString(("yyyy-MM-dd HH:mm:ss")));
							foreach (var task in e.TaskList)
							{
								BuildTask bt = task as BuildTask;
								if (bt != null)
								{
									//Console.WriteLine("Task : {0}", bt);
									if (now.Ticks >= bt.NextCheck.Ticks)
									{
										Console.WriteLine("Checking task : {0}", bt);
										bt.NextCheck = Browser.TryToBuild(ie, bt, si);
									}
								}
							}

							#endregion

							#region Attack every minute if units available

							DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory());

							FileInfo[] attackFiles = di.GetFiles("*" + fileExtensionForAttacks);
							//Console.WriteLine("Found {0} Files in {1}", attackFiles.Length, di.Name);
							foreach (FileInfo attackFile in attackFiles)
							{
                                attacks.FileForAttacks = attackFile.FullName;
                                attacks.FileForFinishedAttacks = attacks.FileForAttacks + fileExtensionForFinishedAttacks;
                                if (File.Exists(attacks.FileForAttacks))
								{
                                    if (!IO.Attack(si, ie, attacks))
                                    {
                                        Console.WriteLine("File '{0}' Not Found!", attacks.FileForFinishedAttacks);
                                    }
								}
								else
								{
                                    Console.WriteLine("File '{0}' Not Found!", attacks.FileForAttacks);
								}
							}

							#endregion

							#region Train Troopsevery 60 minutes

							if (repeatCount%60 == 0)
							{
								if(!IO.TrainTroops(si, fileTrainTroops, ie))
								{
									Console.WriteLine("File '{0}' Not Found!", fileTrainTroops);
								}
							}

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
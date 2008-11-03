#region

using System;
using System.Globalization;
using System.IO;
using System.Text;
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
								if (File.Exists(attackFile.FullName))
								{
									String tempFile = attackFile.FullName + fileExtensionForFinishedAttacks;
									if (File.Exists(tempFile))
									{
										String tempAttacks;
										using (StreamReader sr = new StreamReader(tempFile))
										{
											tempAttacks = sr.ReadToEnd();
											sr.Close();
										}

										bool wasFarmFound = false;
										using (StreamReader sr = new StreamReader(attackFile.FullName))
										{
											while (sr.Peek() >= 0)
											{
												String line = sr.ReadLine();
												if ((!line.StartsWith("#")) && (line.Length > 5))
												{
													//destX|destY|attackType|units|unitType|villageID|comment
													String[] sections = line.Split('|');
													Int32 destinationX = Int32.Parse(sections[0].Trim());
													Int32 destinationY = Int32.Parse(sections[1].Trim());
													String attackType = sections[2].Trim();
													String[] unitsList = sections[3].Trim().Split(',');
													Int32 unitType = Int32.Parse(sections[4].Trim());
													Int32 villageID = Int32.Parse(sections[5].Trim());
													Int32 unitsCount = Int32.Parse(unitsList[unitType]);
													String comment = sections[6];
													String tempCheckLine = sections[0] + "|" + sections[1] + "|" + sections[2] + "|" + sections[3];
													if (tempAttacks.IndexOf(tempCheckLine) > -1)
													{
														continue;
													}
													wasFarmFound = true;
													String attackUnit = troopList.Split(',')[unitType];
													string resourcesUrl = String.Format(CultureInfo.InvariantCulture, "{0}?newdid={1}",
													                                    si.ResourcesPage, villageID);
													pageSource = Browser.GetPageSource(resourcesUrl, ie);
													Int32 availableUnits = Browser.GetTroopCountForUnit(pageSource, attackUnit);
													if (availableUnits >= unitsCount)
													{
														Console.WriteLine("We Have " + availableUnits + " " + attackUnit);
														Random rnd = new Random();
														Int32 parA = rnd.Next(10001, 99999);
														StringBuilder troops = new StringBuilder();
														for (int t = 0; t < 11; t++)
														{
															troops.AppendFormat("&t{0}={1}", (t + 1), unitsList[t].Trim());
														}
														String buttonId =
															String.Format("&s1.x={0}&s1.y={1}&s1=ok", rnd.Next(0, 79), rnd.Next(0, 19));
														String parPost =
															String.Format(CultureInfo.InvariantCulture,
															              "id=39&a={0}&c={1}&kid={2}{3}{4}",
															              parA,
															              attackType.Trim(),
															              Misc.CovertXY(destinationX, destinationY),
															              troops,
															              buttonId
																);
														Console.WriteLine("{3} Attack with {0} {1} to {2}", unitsCount, attackUnit, comment, now.ToString("yyyy-MM-dd HH:mm:ss"));
														object flags = null;
														object headers = "Content-Type: application/x-www-form-urlencoded\n\r";
														object name = null;
														object data = Encoding.UTF8.GetBytes(parPost);
														string sendUnitsUrl = String.Format(CultureInfo.InvariantCulture, "{0}?newdid={1}",
														                                    si.SendUnitsPage, villageID);
														ie.Navigate(sendUnitsUrl, ref flags, ref name, ref data, ref headers);
														Browser.WaitForComplete(ie);

														using (StreamWriter sw = new StreamWriter(tempFile, true))
														{
															sw.WriteLine(line);
															sw.Close();
															//Console.WriteLine(line);
														}
														Thread.Sleep(1000);
													}
												}
											}
											sr.Close();
										}
										//Clear temp file
										if (!wasFarmFound)
										{
											using (StreamWriter sw = new StreamWriter(tempFile, false))
											{
												sw.WriteLine();
												sw.Close();
											}
										}
									}
									else
									{
										Console.WriteLine("File '{0}' Not Found!", tempFile);
									}
								}
								else
								{
									Console.WriteLine("File '{0}' Not Found!", attackFile.Name);
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
using System;
using System.Reflection;
using System.Timers;
using WatiN.Core;
using jcTBLib;
using Timer=System.Timers.Timer;

namespace jcTB
{
	public class Program
	{
		static IE ie = new IE();
		static Resources resources = null;

		private static Int32 counter = 0;

		[STAThread]
		private static void Main()
		{
			Version v = Assembly.GetExecutingAssembly().GetName().Version;
			Console.WriteLine("Travian Bot Version {0} Started!", v);
			Console.WriteLine("Type 'help' For Command List");

			try
			{
				//dont connect to internet, just simulate commands
				bool isSimulation = jcTBL.isSimulation;

				bool endCommand = false;
				bool loginOK = true;

				String serverName = jcTBL.GetConfig("urlServerName");
				String loginPage = jcTBL.GetConfig("urlLoginPage");
				String userName = jcTBL.GetConfig("userName");
				String password = jcTBL.GetConfig("password");

				IE.Settings.WaitForCompleteTimeOut = 120;
				IE.Settings.WaitUntilExistsTimeOut = 120;
				ie.AutoClose = true;
				ie.ShowWindow(NativeMethods.WindowShowStyle.Show);

				/// <summary>
				/// Thread For Build Land
				/// </summary>
				Build buildThread = null;

				#region Connect To Server

				if (!isSimulation)
				{
					loginOK = false;

					/* Login To Server */
					Console.WriteLine("Connecting To '{0}' As '{1}'", serverName, userName);
					if (Browser.Login(ie, loginPage, userName, password))
					{
						loginOK = true;
						Console.WriteLine("Login Successful");
					}
					else
					{
						Console.WriteLine("Login Failed!");
						Console.WriteLine("serverName : " + serverName);
						Console.WriteLine("userName   : " + userName);
						Console.WriteLine("password   : " + password);
					}
					/* Login To Server */
				}

				#endregion

				/* Print Resources*/
				resources = new Resources(ie);
				Console.WriteLine(resources);
				/* Print Resources*/

				Resources.ShowNeededResources(serverName, resources,ie);

				Timer myTimerBrowse = new Timer();
				myTimerBrowse.Elapsed += new ElapsedEventHandler(ChangePages);
				myTimerBrowse.Interval = 120000;
				myTimerBrowse.Start();

				do
				{
					String userInput;
					userInput = Console.ReadLine().ToLower();

					#region Quit Program

					if (userInput.Equals("exit") ||
					    userInput.Equals("quit"))
					{
						endCommand = true;
						if (!isSimulation)
						{
							Browser.Logout(ie, serverName);
						}
						ie.Dispose();
					}
					#endregion
					#region Resources

					else if (userInput.Equals("resources"))
					{
						resources = new Resources(ie);
						Console.WriteLine(resources);
						Resources.ShowNeededResources(serverName, resources, ie);
					}
					#endregion
					#region Jobs

					else if (userInput.Equals("jobs"))
					{
						if (jcTBL.BuildThreadIndex < 1)
						{
							Console.WriteLine("I Have Nothing To Do...");
						}
						else
						{
							if (buildThread == null)
							{
								Console.WriteLine("Hm, Thread Stoped?");
							}
							else
							{
								Console.WriteLine("Thread State : " + buildThread.build.ThreadState);
							}
						}
					}
					#endregion
					#region Kill

					else if (userInput.Equals("kill"))
					{
						if (jcTBL.BuildThreadIndex < 1)
						{
							Console.WriteLine("I Have Nothing To Kill...");
						}
						else
						{
							if (buildThread != null)
							{
								Console.WriteLine("Killing " + buildThread.build.Name);
								buildThread.build.Abort();
								// wait for thread to terminate
								buildThread.build.Join();
								jcTBL.BuildThreadIndex--;
							}
						}
					}
					#endregion
					#region Build

					//else if (userInput.Length > 5)
					//{
					//    if (userInput.Substring(0, 5).Equals("build"))
					//    {
					//        if (jcTBL.BuildThreadIndex > 0)
					//        {
					//            Console.WriteLine("Allready Building...");
					//        }
					//        else
					//        {
					//            Int32 returnCode = BuildCheck.CheckCommand(userInput, resources);
					//            switch(returnCode)
					//            {
									
					//                case (int) Codes.BuildCheckCodes.minLevelAllreadyReached:
					//                    {
					//                        Console.WriteLine("Resource Allready At Wanted Level!");
					//                        break;
					//                    }

					//                case (int)Codes.BuildCheckCodes.buildLandWOOD:
					//                    {
					//                        buildThread = new Build(userInput, resources, Codes.ResourceCodes.WOOD, ie);
					//                        jcTBL.BuildThreadIndex++;

					//                        break;
					//                    }

					//                case (int)Codes.BuildCheckCodes.buildLandCLAY:
					//                    {
					//                        buildThread = new Build(userInput, resources, Codes.ResourceCodes.CLAY, ie);
					//                        jcTBL.BuildThreadIndex++;

					//                        break;
					//                    }

					//                case (int)Codes.BuildCheckCodes.buildLandIRON:
					//                    {
					//                        buildThread = new Build(userInput, resources, Codes.ResourceCodes.IRON, ie);
					//                        jcTBL.BuildThreadIndex++;

					//                        break;
					//                    }

					//                case (int)Codes.BuildCheckCodes.buildLandCROP:
					//                    {
					//                        buildThread = new Build(userInput, resources, Codes.ResourceCodes.CROP, ie);
					//                        jcTBL.BuildThreadIndex++;

					//                        break;
					//                    }

					//                default:
					//                    {
					//                        Console.WriteLine("Unknown Command!");
					//                        break;
					//                    }
					//            }
					//        }
					//    }
					//    else
					//    {
					//        Console.WriteLine("Unknown Command!");
					//    }
					//}
					#endregion
					#region Help

					else if (userInput.Equals("help"))
					{
						Console.WriteLine(jcTBL.ShowHelp());
					}
					#endregion

					else
					{
						Console.WriteLine("Unknown Command!");
					}
				} while (loginOK && !endCommand);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception:\n{0}\n", ex.Message);
				Console.WriteLine(ex);
			}
		}

		private static void ChangePages(object sender, ElapsedEventArgs e)
		{
			counter++;
			Console.WriteLine("Current Resources : {0}", jcTBL.GetLevel2String(resources.CurProduction, false));
			if (jcTBL.CanWeBuild(resources, jcTBL.idToBuild))
			{
				String buildURL = String.Format("{0}build.php?id={1}", jcTBL.GetConfig("urlServerName"), jcTBL.idToBuild);
				ie = new IE();
				ie.GoTo(buildURL);
				Console.WriteLine("Building ID {0} [{1}] -> {2}", jcTBL.idToBuild, jcTBL.GetNameFromID(jcTBL.idToBuild), buildURL);
				for (int i = 0; i < ie.Links.Length; i++)
				{
					if (ie.Links[i].Text.StartsWith(jcTBL.GetConfig("updateURLText")))
					{
						ie.Links[i].Click();
					}
				}
			}
			else
			{
				Console.WriteLine("ID {0} [{1}] Is Waiting For Building...",
					jcTBL.idToBuild,
					jcTBL.GetNameFromID(jcTBL.idToBuild));
			}
			//Console.WriteLine("Browsing...");
			ie.GoTo(jcTBL.GetConfig("urlResources"));
			//ie.GoTo(jcTBL.GetConfig("urlTown"));
			if (counter > 10)
			{
				Resources.UpdateNeededResources(false, ie, resources, jcTBL.GetConfig("urlServerName"));
				counter = 0;
				Console.WriteLine("Updating Needed Resources...");
			}
		}
	}
}
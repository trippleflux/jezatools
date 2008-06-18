using System;
using System.Threading;
using System.Timers;
using mshtml;
using SHDocVw;
using Timer=System.Threading.Timer;

namespace jcTBot
{
	internal class Program
	{
		[STAThread]
		public static int Main(string[] args)
		{
			const String loginUrl = @"http://s3.travian.si/login.php";
			const String resourcesUrl = @"http://s3.travian.si/dorf1.php";
			//const String buildingUrl = @"http://s3.travian.si/dorf2.php";
			const String loginUsername = "jezonsky";
			const String loginPassword = "pimpek";

			try
			{
				InternetExplorer ie = new InternetExplorerClass();
				HTMLDocument myDoc;
				String bodyData;
				bool logedIn = false;

				myDoc = Login(ie, loginUrl, loginUsername, loginPassword);

				bodyData = myDoc.body.innerText;
				logedIn = IsLogenIn(bodyData, logedIn);
				//Console.WriteLine(bodyData.Trim());
				//Console.WriteLine("***********");
				//Console.WriteLine(myDoc.body.innerHTML);

				int i = 0;
				do
				{
					if (logedIn)
					{
						Console.WriteLine("LogedIn!");
					}
					else
					{
						Console.WriteLine("Failed To LogIn!!!");
						Console.WriteLine(bodyData);
					}

					Timer timer = new Timer(Tick);
					//System.Timers.Timer myTimerBrowse = new System.Timers.Timer();
					//myTimerBrowse.Elapsed += ChangePages;
					//myTimerBrowse.Interval = 60000;
					//myTimerBrowse.Start();

					//String userInput;
					//userInput = Console.ReadLine().ToLower();
					//#region Quit Program
					//if (userInput.Equals("exit") ||
					//    userInput.Equals("quit"))
					//{
					//    Console.WriteLine("QUIT");
					//    break;
					//}
					//#endregion

					Thread.Sleep(10000);
					Console.WriteLine(i);
					myDoc = Browse(resourcesUrl, ie, myDoc);
					bodyData = myDoc.body.innerText;
					logedIn = IsLogenIn(bodyData, logedIn);
					i++;
					//if (i>80)
					//{
					//    i = 0;
					//}
				} while (true);

				//myTimerBrowse.Stop();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
			finally
			{
				Console.WriteLine("EXIT");
			}
			return 0;
		}

		private static HTMLDocument Browse(String resourcesUrl, InternetExplorer ie, HTMLDocument myDoc)
		{
			object flags = null;
			object headers = null;
			object name = null;
			object data = null;
			ie.Navigate(resourcesUrl, ref flags, ref name, ref data, ref headers);
			WaitForComplete(ie);
			myDoc = (HTMLDocument)ie.Document;
			return myDoc;
		}

		private static bool IsLogenIn(String bodyData, bool logedIn)
		{
			Console.WriteLine("LogIn Check!");
			logedIn = false;
			if (bodyData.Contains("Proizvodnja:"))
			{
				logedIn = true;
			}
			return logedIn;
		}

		private static HTMLDocument Login(InternetExplorer ie, string loginUrl, string loginUsername, string loginPassword)
		{
			HTMLDocument myDoc;
			object nil = null;
			ie.Navigate(loginUrl, ref nil, ref nil, ref nil, ref nil);
			WaitForComplete(ie);

			//Find username textbox
			String loginUsernameTextBoxName = Find.InputTagByType(ie, "text");
			//Console.WriteLine("Username TextBox Name = '" + loginUsernameTextBoxName + "'");
			//String loginUsernameTextBoxValue = Find.TextBoxValue(ie, "text", loginUsernameTextBoxName);
			//Console.WriteLine("Username TextBox Value = '" + loginUsernameTextBoxValue + "'");
			myDoc = (HTMLDocument)ie.Document;
			HTMLInputElement loginUsernameTextBox = (HTMLInputElement)myDoc.all.item(loginUsernameTextBoxName, 0);
			loginUsernameTextBox.value = loginUsername;
			//String loginUsernameTextBoxNewValue = Find.TextBoxValue(ie, "text", loginUsernameTextBoxName);
			//Console.WriteLine("Username TextBox Value = '" + loginUsernameTextBoxNewValue + "'");
			//Find password textbox
			String loginPasswordTextBoxName = Find.InputTagByType(ie, "password");
			//Console.WriteLine("Password TextBox Name = '" + loginPasswordTextBoxName + "'");
			//String loginPasswordTextBoxValue = Find.TextBoxValue(ie, "password", loginPasswordTextBoxName);
			//Console.WriteLine("Password TextBox Value = '" + loginPasswordTextBoxValue + "'");
			myDoc = (HTMLDocument)ie.Document;
			HTMLInputElement loginPasswordTextBox = (HTMLInputElement)myDoc.all.item(loginPasswordTextBoxName, 0);
			loginPasswordTextBox.value = loginPassword;
			//String loginPasswordTextBoxNewValue = Find.TextBoxValue(ie, "password", loginPasswordTextBoxName);
			//Console.WriteLine("Password TextBox Value = '" + loginPasswordTextBoxNewValue + "'");
			//Find login button
			String loginImageButtonName = Find.InputTagByType(ie, "image");
			//Console.WriteLine("Login Image Name = '" + loginImageButtonName + "'");
			myDoc = (HTMLDocument)ie.Document;
			HTMLInputElement loginImageButton = (HTMLInputElement)myDoc.all.item(loginImageButtonName, 0);
			loginImageButton.click();
			WaitForComplete(ie);
			return myDoc;
		}

		private static void WaitForComplete(IWebBrowser2 ieWAIT)
		{
			do
			{
				//Console.WriteLine("-" + i++);
				Thread.Sleep(500);
			} while (ieWAIT.ReadyState != tagREADYSTATE.READYSTATE_COMPLETE);
		}

		static void Tick(object state)
		{
			Console.WriteLine("Tick Ticked at {0:HH:mm:ss.fff}", DateTime.Now);
		}

		private static void ChangePages(object sender, ElapsedEventArgs e)
		{
			Console.WriteLine("ChangePages Ticked at {0:HH:mm:ss.fff}", DateTime.Now);
		}
	}
}
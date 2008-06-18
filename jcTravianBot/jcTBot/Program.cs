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
		public static int Main(string[] args)
		{
			const string loginUrl = @"http://s3.travian.si/login.php";
			const string resourcesUrl = @"http://s3.travian.si/dorf1.php";
			const string buildingUrl = @"http://s3.travian.si/dorf2.php";
			const string loginUsername = "jezonsky";
			const string loginPassword = "pimpek";

			Console.WriteLine("IE");
			InternetExplorer ie = new InternetExplorerClass();
			HTMLDocument myDoc;
			string bodyData;

			myDoc = Login(ie, loginUrl, loginUsername, loginPassword);

			bodyData = myDoc.body.innerText;
			Console.WriteLine(bodyData);
			Console.WriteLine("***********");
			//Console.WriteLine(myDoc.body.innerHTML);

			Timer timer = new Timer(Tick);
			System.Timers.Timer myTimerBrowse = new System.Timers.Timer();
			myTimerBrowse.Elapsed += ChangePages;
			myTimerBrowse.Interval = 5000;
			myTimerBrowse.Start();

			int i = 0;
			do
			{
				Thread.Sleep(10000);
				Console.WriteLine(".");
				object flags = null;
				object headers = null;
				object name = null;
				object data = null;
				ie.Navigate(resourcesUrl, ref flags, ref name, ref data, ref headers);
				WaitForComplete(ie);
				myDoc = (HTMLDocument)ie.Document;
				bodyData = myDoc.body.innerText;
				Console.WriteLine(bodyData);
				Console.WriteLine("***********");
				i++;
			} while (i < 200);

			/*
			// google html source for the I'm Feeling Lucky Button:
			// <INPUT type=submit value="I'm Feeling Lucky" name=btnI>
			//
			HTMLInputElement btnSearch = (HTMLInputElement)myDoc.all.item("btnI", 0);
			btnSearch.click();
			 * */

			Console.WriteLine("END");
			myTimerBrowse.Stop();
			return 0;
		}

		private static HTMLDocument Login(InternetExplorer ie, string loginUrl, string loginUsername, string loginPassword)
		{
			HTMLDocument myDoc;
			object nil = null;
			ie.Navigate(loginUrl, ref nil, ref nil, ref nil, ref nil);
			WaitForComplete(ie);

			//Find username textbox
			String loginUsernameTextBoxName = Find.InputTagByType(ie, "text");
			Console.WriteLine("Username TextBox Name = '" + loginUsernameTextBoxName + "'");
			String loginUsernameTextBoxValue = Find.TextBoxValue(ie, "text", loginUsernameTextBoxName);
			Console.WriteLine("Username TextBox Value = '" + loginUsernameTextBoxValue + "'");
			myDoc = (HTMLDocument)ie.Document;
			HTMLInputElement loginUsernameTextBox = (HTMLInputElement)myDoc.all.item(loginUsernameTextBoxName, 0);
			loginUsernameTextBox.value = loginUsername;
			String loginUsernameTextBoxNewValue = Find.TextBoxValue(ie, "text", loginUsernameTextBoxName);
			Console.WriteLine("Username TextBox Value = '" + loginUsernameTextBoxNewValue + "'");
			//Find password textbox
			String loginPasswordTextBoxName = Find.InputTagByType(ie, "password");
			Console.WriteLine("Password TextBox Name = '" + loginPasswordTextBoxName + "'");
			String loginPasswordTextBoxValue = Find.TextBoxValue(ie, "password", loginPasswordTextBoxName);
			Console.WriteLine("Password TextBox Value = '" + loginPasswordTextBoxValue + "'");
			myDoc = (HTMLDocument)ie.Document;
			HTMLInputElement loginPasswordTextBox = (HTMLInputElement)myDoc.all.item(loginPasswordTextBoxName, 0);
			loginPasswordTextBox.value = loginPassword;
			String loginPasswordTextBoxNewValue = Find.TextBoxValue(ie, "password", loginPasswordTextBoxName);
			Console.WriteLine("Password TextBox Value = '" + loginPasswordTextBoxNewValue + "'");
			//Find login button
			String loginImageButtonName = Find.InputTagByType(ie, "image");
			Console.WriteLine("Login Image Name = '" + loginImageButtonName + "'");
			myDoc = (HTMLDocument)ie.Document;
			HTMLInputElement loginImageButton = (HTMLInputElement)myDoc.all.item(loginImageButtonName, 0);
			loginImageButton.click();
			WaitForComplete(ie);
			return myDoc;
		}

		private static void WaitForComplete(IWebBrowser2 ieWAIT)
		{
			int i = 0;
			do
			{
				Console.WriteLine("-" + i++);
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
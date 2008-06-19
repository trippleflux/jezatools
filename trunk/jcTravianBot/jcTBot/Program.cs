using System;
using System.IO;
using System.Threading;
using mshtml;
using SHDocVw;

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
			const string fileAttacks = @"c:\attacks.txt";
			const string fileResources = @"c:\resources.txt";

			HTMLDocument myDoc;
			try
			{
				InternetExplorer ie = new InternetExplorerClass();

				myDoc = Login(ie, loginUrl, loginUsername, loginPassword);

				String bodyData = myDoc.body.innerText;
				bool logedIn = IsLogenIn(bodyData);

				do
				{
					if (!logedIn)
					{
						Console.Write("Not Loged In!!!");
						Console.WriteLine(bodyData);
						Login(ie, loginUrl, loginUsername, loginPassword);
					}
					else
					{
						using (StreamReader sr = new StreamReader(fileAttacks))
						{
							String line = sr.ReadLine();
							if (line.StartsWith("#"))
							{
								continue;
							}
							String[] sections = line.Split('|');
							String time = sections[0];
							String destinationX = sections[1];
							String destinationZ = sections[2];
							String attackType = sections[3];
							String troops = sections[4];
							String villageID = sections[5];
						}
					}

					Thread.Sleep(60000);
					myDoc = Browse(resourcesUrl, ie);
					bodyData = myDoc.body.innerText;
					logedIn = IsLogenIn(bodyData);

				} while (true);

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

		private static HTMLDocument Browse(String resourcesUrl, IWebBrowser2 ie)
		{
			object flags = null;
			object headers = null;
			object name = null;
			object data = null;
			ie.Navigate(resourcesUrl, ref flags, ref name, ref data, ref headers);
			WaitForComplete(ie);
			HTMLDocument myDoc = (HTMLDocument)ie.Document;
			return myDoc;
		}

		private static bool IsLogenIn(String bodyData)
		{
			//Console.WriteLine("LogIn Check... ");
			bool isLogedIn = false;
			if (bodyData.Contains("Proizvodnja:"))
			{
				isLogedIn = true;
			}
			return isLogedIn;
		}

		private static HTMLDocument Login(InternetExplorer ie, string loginUrl, string loginUsername, string loginPassword)
		{
			object nil = null;
			ie.Navigate(loginUrl, ref nil, ref nil, ref nil, ref nil);
			WaitForComplete(ie);

			//Find username textbox
			String loginUsernameTextBoxName = Find.InputTagByType(ie, "text");
			//Console.WriteLine("Username TextBox Name = '" + loginUsernameTextBoxName + "'");
			//String loginUsernameTextBoxValue = Find.TextBoxValue(ie, "text", loginUsernameTextBoxName);
			//Console.WriteLine("Username TextBox Value = '" + loginUsernameTextBoxValue + "'");
			HTMLDocument myDoc = (HTMLDocument)ie.Document;
			HTMLInputElement loginUsernameTextBox = 
				(HTMLInputElement)myDoc.all.item(loginUsernameTextBoxName, 0);
			loginUsernameTextBox.value = loginUsername;
			//String loginUsernameTextBoxNewValue = Find.TextBoxValue(ie, "text", loginUsernameTextBoxName);
			//Console.WriteLine("Username TextBox Value = '" + loginUsernameTextBoxNewValue + "'");
			//Find password textbox
			String loginPasswordTextBoxName = Find.InputTagByType(ie, "password");
			//Console.WriteLine("Password TextBox Name = '" + loginPasswordTextBoxName + "'");
			//String loginPasswordTextBoxValue = Find.TextBoxValue(ie, "password", loginPasswordTextBoxName);
			//Console.WriteLine("Password TextBox Value = '" + loginPasswordTextBoxValue + "'");
			myDoc = (HTMLDocument)ie.Document;
			HTMLInputElement loginPasswordTextBox = 
				(HTMLInputElement)myDoc.all.item(loginPasswordTextBoxName, 0);
			loginPasswordTextBox.value = loginPassword;
			//String loginPasswordTextBoxNewValue = Find.TextBoxValue(ie, "password", loginPasswordTextBoxName);
			//Console.WriteLine("Password TextBox Value = '" + loginPasswordTextBoxNewValue + "'");
			//Find login button
			String loginImageButtonName = Find.InputTagByType(ie, "image");
			//Console.WriteLine("Login Image Name = '" + loginImageButtonName + "'");
			myDoc = (HTMLDocument)ie.Document;
			HTMLInputElement loginImageButton = 
				(HTMLInputElement)myDoc.all.item(loginImageButtonName, 0);
			loginImageButton.click();
			WaitForComplete(ie);
			return myDoc;
		}

		private static void WaitForComplete(IWebBrowser2 ieWAIT)
		{
			do
			{
				Thread.Sleep(500);
			} while (ieWAIT.ReadyState != tagREADYSTATE.READYSTATE_COMPLETE);
		}

	}
}
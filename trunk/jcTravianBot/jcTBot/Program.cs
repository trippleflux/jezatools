using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using mshtml;
using SHDocVw;

namespace jcTBot
{
	public class Program
	{
		[STAThread]
		public static int Main(string[] args)
		{
			String loginUrl = ConfigurationManager.AppSettings["loginUrl"];
			String resourcesUrl = ConfigurationManager.AppSettings["resourcesUrl"];
			String sendUnitsUrl = ConfigurationManager.AppSettings["sendUnitsUrl"];
			String loginUsername = ConfigurationManager.AppSettings["loginUsername"];
			String loginPassword = ConfigurationManager.AppSettings["loginPassword"];
			String fileAttacks = ConfigurationManager.AppSettings["fileAttacks"];

			try
			{
				InternetExplorer ie = new InternetExplorerClass();

				HTMLDocument myDoc = Login(ie, loginUrl, loginUsername, loginPassword);

				String bodyData = myDoc.body.innerText;
				bool logedIn = IsLogenIn(bodyData);

				do
				{
					//Console.WriteLine("1");
					if (!logedIn)
					{
						Console.Write("Not Loged In!!!");
						Console.WriteLine(bodyData);
						Login(ie, loginUrl, loginUsername, loginPassword);
					}
					else
					{
						//Console.WriteLine("2");
						using (StreamReader sr = new StreamReader(fileAttacks))
						{
							//Console.WriteLine("3");
							while (sr.Peek() >= 0)
							{
								String line = sr.ReadLine();
								//Console.WriteLine(line);
								if ((!line.StartsWith("#")) && (line.Length > 5))
								{
									String[] sections = line.Split('|');
									String time = sections[0];
									//String sourceX = sections[1];
									//String sourceY = sections[2];
									String destinationX = sections[3];
									String destinationY = sections[4];
									String attackType = sections[5];
									String[] troopList = sections[6].Split(',');
									String villageID = sections[7];
									String attackID = sections[8];
									String enabled = sections[10];
									String timenow = DateTime.Now.ToString("HH:mm");
									if ( (enabled.Equals("1")) && (timenow.Equals(time)) )
									{
										Console.WriteLine("timenow=" + timenow);
										Random rnd = new Random();
										Int32 parA = rnd.Next(10001, 99999);
										StringBuilder troops = new StringBuilder();
										for (int t=0;t<11;t++)
										{
											troops.AppendFormat("&t{0}={1}", (t + 1), troopList[t]);
										}
										String parPost = 
											String.Format(CultureInfo.InvariantCulture, 
											"id=39&a={0}&c={1}&kid={2}{3}{4}",
											parA, 
											attackType, 
											CovertXY(Int32.Parse(destinationX), Int32.Parse(destinationY)),
											troops,
											attackID
											);
										Console.WriteLine(parPost);
										object flags = null;
										object headers = "Content-Type: application/x-www-form-urlencoded\n\r";
										object name = null;
										object data = Encoding.ASCII.GetBytes(parPost); 
										ie.Navigate(sendUnitsUrl + villageID, ref flags, ref name, ref data, ref headers);
									}
								}
							}
						}
						Thread.Sleep(60000);
					}

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

		private static Int32 CovertXY(Int32 x, Int32 y)
		{
			return ((x + 401) + ((400 - y) * 801));
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
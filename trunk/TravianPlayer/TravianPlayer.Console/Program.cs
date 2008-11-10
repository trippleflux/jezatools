#region

using System;
using System.IO;
using System.Net;
using System.Text;
using TravianPlayer.Framework;

#endregion

namespace TravianPlayer.Console
{
	internal class Program
	{
		private static void Main()
		{
			const string userName = "jeza";
			const string passWord = "kepek";
			const string serverName = "http://s4.travian.si/";

			ServerInfo serverInfo = new ServerInfo
			                        {
			                        	LoginUrl = (serverName + "login.php"),
			                        	ResourcesUrl = string.Format("{0}dorf1.php?newdid={1}", serverName, 0),
			                        	BuildingsUrl = string.Format("{0}dorf2.php?newdid={1}", serverName, 0),
			                        	SendUnitsUrl = string.Format("{0}a2b.php?newdid={1}", serverName, 0)
			                        };
			CookieCollection cookieCollection = new CookieCollection();
			CookieContainer cookieContainer = new CookieContainer();

			HttpWebResponse httpWebResponse = Http.SendData(serverInfo.LoginUrl, null, cookieContainer);
			string pageSource = GetPageSource(httpWebResponse);

			HtmlParser htmlParser = new HtmlParser();
			UserInfo userInfo = htmlParser.ParseLoginPage(pageSource);
			userInfo.Username = userName;
			userInfo.Password = passWord;
			System.Console.WriteLine(userInfo.TextBoxUserame);
			System.Console.WriteLine(userInfo.TextBoxPassword);

			serverInfo.LoginCredentials =
				String.Format("login={0}&{1}={2}&{3}={4}&{5}={6}",
				              userInfo.HiddenLoginValue,
				              userInfo.TextBoxUserame,
				              userInfo.Username,
				              userInfo.TextBoxPassword,
				              userInfo.Password,
				              userInfo.HiddenName,
				              userInfo.HiddenValue);

			string postData =
				String.Format("w=1152%3A864&{0}&s1.x=48&s1.y=8", serverInfo.LoginCredentials);
			httpWebResponse = Http.SendData(serverInfo.ResourcesUrl, postData, cookieContainer);
			cookieCollection.Add(httpWebResponse.Cookies);
			cookieContainer.Add(cookieCollection);

			System.Console.WriteLine("Cookies: ");
			for (int i = 0; i < cookieCollection.Count; i++)
			{
				System.Console.WriteLine(cookieCollection[i].Name + "=" + cookieCollection[i].Value + ", Expired=" +
				                         cookieCollection[i].Expired);
			}

			httpWebResponse = Http.SendData(serverInfo.BuildingsUrl, null, cookieContainer);
			System.Console.WriteLine(GetPageSource(httpWebResponse));
		}



		private static string GetPageSource(WebResponse httpWebResponse)
		{
			StreamReader loginReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8);
			return loginReader.ReadToEnd();
		}
	}
}
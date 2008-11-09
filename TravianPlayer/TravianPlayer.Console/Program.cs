using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using TravianPlayer.Framework;

namespace TravianPlayer.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			const string userName = "jeza";
			const string passWord = "kepek";
			const string serverName = "http://s4.travian.si/";
			
			CookieContainer cookies = new CookieContainer();
			
			ServerInfo serverInfo = new ServerInfo();
			serverInfo.LoginUrl = serverName + "login.php";
			
			string pageSource = Http.GetPageSource(serverInfo.LoginUrl, cookies);
			
			HtmlParser htmlParser = new HtmlParser();
			UserInfo userInfo = htmlParser.ParseLoginPage(pageSource);
			userInfo.Username = userName;
			userInfo.Password = passWord;
			System.Console.WriteLine(userInfo.TextBoxUserame);
			System.Console.WriteLine(userInfo.TextBoxPassword);

			serverInfo.LoginCredentials =
				String.Format("{0}={1}&{2}={3}",
							  userInfo.TextBoxUserame,
							  userInfo.Username,
							  userInfo.TextBoxPassword,
							  userInfo.Password);
			serverInfo.ResourcesUrl = string.Format("{0}dorf1.php?newdid={1}&{2}", serverName, 0, serverInfo.LoginCredentials);
			serverInfo.BuildingsUrl = string.Format("{0}dorf2.php?newdid={1}&{2}", serverName, 0, serverInfo.LoginCredentials);

			string postData =
				String.Format("w=1152%3A864&login={0}&{1}={2}&{3}={4}&{5}={6}&s1.x=48&s1.y=8",
							  userInfo.HiddenLoginValue,
							  userInfo.TextBoxUserame,
							  userInfo.Username,
							  userInfo.TextBoxPassword,
							  userInfo.Password,
							  userInfo.HiddenName,
							  userInfo.HiddenValue);
			
			pageSource = Http.PostData(serverInfo.ResourcesUrl, postData, cookies);
			//System.Console.WriteLine(pageSource);
			pageSource = Http.GetPageSource(serverInfo.BuildingsUrl, cookies);
			System.Console.WriteLine(pageSource);
		}
	}
}

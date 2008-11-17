﻿#region

using System;
using System.Globalization;
using System.Net;
using System.Threading;
using TravianPlayer.Framework;

#endregion

namespace TravianPlayer.Runner
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			try
			{
				String serverName = Misc.GetConfigValue("serverName");
				String userName = Misc.GetConfigValue("userName");
				String password = Misc.GetConfigValue("password");

				CookieContainer cookieContainer = new CookieContainer();
				CookieCollection cookieCollection = new CookieCollection();
				const string loginUrl = "loginUrl";
				const string resourcesUrl = "resourcesUrl";
				const string buildingsUrl = "buildingsUrl";
				const string sendUnitsUrl = "sendUnitsUrl";
				const string buildUrl = "buildUrl";

				Game gameInfo = new Game();
				gameInfo.AddUrl(loginUrl, String.Format(CultureInfo.InvariantCulture, "{0}login.php", serverName));
				gameInfo.AddUrl(resourcesUrl, String.Format(CultureInfo.InvariantCulture, "{0}dorf1.php", serverName));
				gameInfo.AddUrl(buildingsUrl, String.Format(CultureInfo.InvariantCulture, "{0}dorf2.php", serverName));
				gameInfo.AddUrl(sendUnitsUrl, String.Format(CultureInfo.InvariantCulture, "{0}a2b.php", serverName));
				gameInfo.AddUrl(buildUrl, String.Format(CultureInfo.InvariantCulture, "{0}build.php", serverName));

				string pageSource = Http.SendData(gameInfo.GetUrl(loginUrl), null, cookieContainer, cookieCollection);
				HtmlParser htmlParser = new HtmlParser(pageSource);
				LoginInfo loginInfo = htmlParser.ParseLoginPage();
				loginInfo.Username = userName;
				loginInfo.Password = password;
				gameInfo.AddLoginInfo(loginInfo);

				bool logedIn = Login(gameInfo, resourcesUrl, cookieContainer, cookieCollection);

				if (logedIn)
				{
					int repeatCount = 0;
					do
					{
						logedIn = IsLogedIn(gameInfo, resourcesUrl, cookieContainer, cookieCollection, null);

						if (logedIn)
						{
							DateTime now = new DateTime(DateTime.Now.Ticks);
							Console.WriteLine(now.ToLocalTime());

							repeatCount++;
							if (repeatCount > 100)
							{
								repeatCount = 0;
							}
						}
						else
						{
							Login(gameInfo, resourcesUrl, cookieContainer, cookieCollection);
						}
						Thread.Sleep(60000);
					} while (repeatCount < 1000);
				}
				else
				{
					Console.WriteLine("Not loged in ...");
				}
			}
			catch (Exception)
			{
				Console.WriteLine("Oups...");
				throw;
			}
		}

		private static bool IsLogedIn
			(Game gameInfo,
			 string resourcesUrl,
			 CookieContainer cookieContainer,
			 CookieCollection cookieCollection,
			 string postData)
		{
			string pageSource = Http.SendData(gameInfo.GetUrl(resourcesUrl), postData, cookieContainer, cookieCollection);
			HtmlParser htmlParser = new HtmlParser(pageSource);

			htmlParser.ParseUserId(gameInfo);
			return gameInfo.UserId < 0 ? false : true;
		}

		public static bool Login
			(Game gameInfo,
			 string resourcesUrl,
			 CookieContainer cookieContainer,
			 CookieCollection cookieCollection)
		{
			string postData = String.Format("login={0}&{1}={2}&{3}={4}&{5}={6}",
			                                gameInfo.GetLoginInfo().HiddenLoginValue,
			                                gameInfo.GetLoginInfo().TextBoxUserame,
			                                gameInfo.GetLoginInfo().Username,
			                                gameInfo.GetLoginInfo().TextBoxPassword,
			                                gameInfo.GetLoginInfo().Password,
			                                gameInfo.GetLoginInfo().HiddenName,
			                                gameInfo.GetLoginInfo().HiddenValue);

			return IsLogedIn(gameInfo, resourcesUrl, cookieContainer, cookieCollection, postData);
		}
	}
}
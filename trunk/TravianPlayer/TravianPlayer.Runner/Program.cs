#region

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
		private static void Main()
		{
			try
			{
				String serverName = Misc.GetConfigValue("serverName");
				String userName = Misc.GetConfigValue("userName");
				String password = Misc.GetConfigValue("password");

				const string loginUrl = "loginUrl";
				const string resourcesUrl = "resourcesUrl";
				const string buildingsUrl = "buildingsUrl";
				const string sendUnitsUrl = "sendUnitsUrl";
				const string buildUrl = "buildUrl";

				Game gameInfo = new Game {CookieContainer = new CookieContainer(), CookieCollection = new CookieCollection()};
				gameInfo.AddUrl(loginUrl, String.Format(CultureInfo.InvariantCulture, "{0}login.php", serverName));
				gameInfo.AddUrl(resourcesUrl, String.Format(CultureInfo.InvariantCulture, "{0}dorf1.php", serverName));
				gameInfo.AddUrl(buildingsUrl, String.Format(CultureInfo.InvariantCulture, "{0}dorf2.php", serverName));
				gameInfo.AddUrl(sendUnitsUrl, String.Format(CultureInfo.InvariantCulture, "{0}a2b.php", serverName));
				gameInfo.AddUrl(buildUrl, String.Format(CultureInfo.InvariantCulture, "{0}build.php", serverName));

				string pageSource =
					Http.SendData(gameInfo.GetUrl(loginUrl), null, gameInfo.CookieContainer, gameInfo.CookieCollection);
				HtmlParser htmlParser = new HtmlParser(pageSource);
				LoginInfo loginInfo = htmlParser.ParseLoginPage();
				loginInfo.Username = userName;
				loginInfo.Password = password;
				gameInfo.AddLoginInfo(loginInfo);

				bool logedIn = Login(gameInfo, resourcesUrl, gameInfo.CookieContainer, gameInfo.CookieCollection);

				if (logedIn)
				{
					int repeatCount = 0;
					do
					{
						logedIn = IsLogedIn(gameInfo, resourcesUrl, gameInfo.CookieContainer, gameInfo.CookieCollection, null);

						if (logedIn)
						{
							//DateTime now = new DateTime(DateTime.Now.Ticks);
							//Console.WriteLine(now.ToLocalTime());

							#region attacks

							if (repeatCount%1 == 0)
							{
                                AttackExecutor attackExecutor = new AttackExecutor(gameInfo);
                                attackExecutor.Parse();
							}

							#endregion

							repeatCount++;
							if (repeatCount > 100)
							{
								repeatCount = 0;
							}
						}
						else
						{
							Login(gameInfo, resourcesUrl, gameInfo.CookieContainer, gameInfo.CookieCollection);
						}
						Thread.Sleep(60000);
					} while (repeatCount < 1000);
				}
				else
				{
					Console.WriteLine("Not loged in ...");
				}
			}
			catch (Exception exception)
			{
				Console.WriteLine("Oups...");
                Console.WriteLine(exception.Message);
                Console.WriteLine();
                Console.WriteLine(exception);
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
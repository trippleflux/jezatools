using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text;

namespace jcTBotConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			const string userName = "jezonsky";
			const string passWord = "kepek";
			const string serverName = "http://s3.travian.si";
			string loginPage = String.Format(CultureInfo.InvariantCulture, "{0}/{1}", serverName, "login.php");
			string resourcesPage = String.Format(CultureInfo.InvariantCulture, "{0}/{1}", serverName, "dorf1.php");
			string villagePage = String.Format(CultureInfo.InvariantCulture, "{0}/{1}", serverName, "dorf2.php");
			string sendUnits = String.Format(CultureInfo.InvariantCulture, "{0}/{1}", serverName, "a2b.php");

			string pageSource = Browser.GetPageSource(loginPage);

			LoginFields lf = new LoginFields(pageSource);
			Console.WriteLine(lf.HiddenLoginValue);
			Console.WriteLine(lf.TextLoginName);
			Console.WriteLine(lf.TextPasswordName);
			Console.WriteLine(lf.HiddenName);
			Console.WriteLine(lf.HiddenValue);

			CookieContainer cookies = new CookieContainer();

			String postData =
				String.Format("w=1152%3A864&login={0}&{1}={2}&{3}={4}&{5}={6}&s1.x=48&s1.y=8",
							  lf.HiddenLoginValue,
							  lf.TextLoginName,
							  userName,
							  lf.TextPasswordName,
							  passWord,
							  lf.HiddenName,
							  lf.HiddenValue);
			string resourcesResponse = Browser.PostData(resourcesPage, postData, cookies);
			//Console.WriteLine(resourcesResponse);
			string villageResponse = Browser.PostData(villagePage, postData, cookies);
			//Console.WriteLine(villageResponse);
			const string villageId = "123788";
			string sendUnitsUrl = String.Format(CultureInfo.InvariantCulture, "{0}?newdid={1}", sendUnits, villageId);
			string sendUnitsResponse = Browser.PostData(sendUnitsUrl, postData, cookies);
			//Console.WriteLine(sendUnitsResponse);

			//b=1&t1=&t4=374&t7=&t9=&t2=&t5=&t8=&t10=&t3=&t6=&c=3&dname=&x=-193&y=-224&s1.x=31&s1.y=12&s1=ok
			Random rnd = new Random();
			String buttonCords = String.Format("&s1.x={0}&s1.y={1}&s1=ok", rnd.Next(0, 79), rnd.Next(0, 19));
			postData = String.Format(CultureInfo.InvariantCulture, "b=1&&t1=&t2=&t3=&t4=100&t5=&t6=&t7=&t8=&t9=&t10=&t11={0}", buttonCords);
			sendUnitsUrl = String.Format(CultureInfo.InvariantCulture, "{0}", sendUnits);
			string sendUnitsCheckResponse = Browser.PostData(sendUnitsUrl, postData, cookies);
			Console.WriteLine(sendUnitsCheckResponse);

			//id=39&a=30375&c=3&kid=500032&t1=0&t2=0&t3=0&t4=374&t5=0&t6=0&t7=0&t8=0&t9=0&t10=0&t11=0&s1.x=35&s1.y=14&s1=ok
			Int32 parA = rnd.Next(10001, 99999);
			const int parC = 3;
			const int coordX = -195;
			const int coordY = -225;
			Int32 parKID = ConvertXY2Z(coordX, coordY);
			const string parTroops = "&t1=0&t2=0&t3=0&t4=100&t5=0&t6=0&t7=0&t8=0&t9=0&t10=0&t11=0";
			postData = String.Format(CultureInfo.InvariantCulture, "id=39&a={0}&c={1}&kid={2}{3}{4}", parA, parC, parKID, parTroops, buttonCords);
			Console.WriteLine("{0}", postData);
			string attackResponse = Browser.PostData(sendUnitsUrl, postData, cookies);
			Console.WriteLine("attackResponse: {0}", attackResponse);

		}

		public static Int32 ConvertXY2Z(Int32 x, Int32 y)
		{
			return ((x + 401) + ((400 - y) * 801));
		}
	}
}

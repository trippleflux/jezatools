using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using jcTBotClient;

namespace jcTBotLibrary
{
	class Program
	{
		public static CookieCollection cColl = null;

		[STAThread]
		static void Main(string[] args)
		{
			String loginName = "jezonsky";
			String password = "kepek";
			String loginUrl = "http://s3.travian.si/login.php";
			String dorf1Url = "http://s3.travian.si/dorf1.php";
			CookieContainer myCookieContainer = new CookieContainer();
			string loginContent = GetPageContent(loginUrl, myCookieContainer);
			LoginCredentials loginC = new LoginCredentials(loginContent);
			//Console.WriteLine(loginC.LoginName);
			//Console.WriteLine(loginC.PasswordName);
			//Console.WriteLine(loginC.HiddenName);
			//Console.WriteLine(loginC.HiddenValue);
			//Console.WriteLine(loginC.HiddenLoginValue);
			//w=1152%3A864&login=1220770065&e4a33c4=jezonsky&eb43098=*****&e1fe1de=e697604783&s1.x=48&s1.y=8
			String content = Login(loginName, password, dorf1Url, myCookieContainer, loginC);
			//Console.WriteLine(content);
			Data data = new Data(content, true, false);
			for (int i = 0; i < data.VillagesList.Count; i++)
			{
				Console.WriteLine(data.VillagesList[i]);
			}
			//<a href="logout.php">Odjava</a><br><br>
			//<a href="?newdid=10902">Muta01</a>
		}

		private static string GetPageContent(string pageUrl, CookieContainer myCookieContainer)
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(pageUrl);
			httpWebRequest.CookieContainer = myCookieContainer;
			HttpWebResponse webResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			StreamReader loginReader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8);
			return loginReader.ReadToEnd();
		}

		private static String Login(String loginName, String password, String dorf1Url, CookieContainer myCookieContainer, LoginCredentials loginC)
		{
			String postData =
						 String.Format("w=1152%3A864&login={0}&{1}={2}&{3}={4}&{5}={6}&s1.x=48&s1.y=8",
						 loginC.HiddenLoginValue,
						 loginC.LoginName,
						 loginName,
						 loginC.PasswordName,
						 password,
						 loginC.HiddenName,
						 loginC.HiddenValue);
			//Console.WriteLine(postData);

			UTF8Encoding encoding = new UTF8Encoding();
			byte[] data = encoding.GetBytes(postData);
			HttpWebRequest dorf1Request = (HttpWebRequest)WebRequest.Create(dorf1Url);
			dorf1Request.Method = "POST";
			dorf1Request.ContentType = "application/x-www-form-urlencoded";
			dorf1Request.ContentLength = data.Length;
			dorf1Request.CookieContainer = myCookieContainer;
			Stream dorf1Stream = dorf1Request.GetRequestStream();
			dorf1Stream.Write(data, 0, data.Length);
			dorf1Stream.Close();

			HttpWebResponse dorf1Response = (HttpWebResponse)dorf1Request.GetResponse();
			cColl = myCookieContainer.GetCookies(dorf1Request.RequestUri);
			StreamReader reader = new StreamReader(dorf1Response.GetResponseStream(), Encoding.UTF8);
			return reader.ReadToEnd();
		}
	}
}

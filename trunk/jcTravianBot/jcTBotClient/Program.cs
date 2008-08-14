using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace jcTBotClient
{
	class Program
	{
		public CookieCollection cColl = null;

		[STAThread]
		static void Main(string[] args)
		{
			String loginName = "Vladika";
			String password = "asd123";
			String loginUrl = "http://s3.travian.si/login.php";
			CookieContainer loginCookieContainer = new CookieContainer();
			HttpWebRequest loginRequest = (HttpWebRequest)WebRequest.Create(loginUrl);
			loginRequest.CookieContainer = loginCookieContainer;
			HttpWebResponse loginResponse = (HttpWebResponse)loginRequest.GetResponse();
			StreamReader loginReader = new StreamReader(loginResponse.GetResponseStream(), Encoding.UTF8);
			String loginContent = loginReader.ReadToEnd();
			//<input class="fm fm110" type="text" name="e528e90" value="jezonsky" maxlength="15">
			//<input class="fm fm110" type="password" name="e4519e5" value="******" maxlength="20">
			//<input type="hidden" name="eea0521" value="fd59291e82">
			//w=1280%3A1024&login=1218703254&e528e90=Vladika&e4519e5=******&eea0521=fd59291e82&s1.x=60&s1.y=6&s1=login
			//w=1280%3A1024&login=1218703254&e528e90=Vladika&e4519e5=******&eea0521=fd59291e82&s1.x=60&s1.y=6&s1=login
			/*
			 * <input type="hidden" name="w" value="">
			 * <input type="hidden" name="login" value="1218716929">
			 * 
			 * <input class="fm fm110" type="text" name="e528e90" value="" maxlength="15">
			 * <input class="fm fm110" type="password" name="e4519e5" value="" maxlength="20">
			 * 
			 * <input type="hidden" name="eea0521" value="">
			 * 
			 * http://www.cnblogs.com/minbear/archive/2007/07/13/816879.html
			 * http://www.cnblogs.com/qufo/archive/2007/11/05/949725.html
			 * http://www.netcsharp.cn/archiver/showtopic-755.aspx
			 * 
			 */
			Console.WriteLine(loginContent);
		}
	}
}

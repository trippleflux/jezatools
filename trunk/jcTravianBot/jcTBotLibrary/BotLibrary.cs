using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace jcTBotLibrary
{
	public class BotLibrary
	{
		/// <summary>
		/// Gets the requested page content.
		/// </summary>
		/// <param name="pageUrl">URL of the page</param>
		/// <param name="myCookieContainer">Cookie container</param>
		/// <returns>Page source</returns>
		/// 
		public static string GetPageContent(string pageUrl, CookieContainer myCookieContainer)
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(pageUrl);
			httpWebRequest.CookieContainer = myCookieContainer;
			HttpWebResponse webResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			StreamReader loginReader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8);
			return loginReader.ReadToEnd();
		}


	}
}

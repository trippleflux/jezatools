using System;
using System.IO;
using System.Net;
using System.Text;

namespace jcTBotConsole
{
	public class Browser
	{
		public static string GetPageSource(string pageUrl)
		{
			Console.WriteLine("pageUrl={0}",pageUrl);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(pageUrl);
			httpWebRequest.Method = "GET";
			httpWebRequest.CookieContainer = new CookieContainer();
			HttpWebResponse webResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			StreamReader loginReader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8);
			return loginReader.ReadToEnd();
		}

		public static string PostData(string pageUrl,
		                              string postData,
		                              CookieContainer cookies)
		{
			Console.WriteLine("pageUrl={0}", pageUrl);
			Console.WriteLine("postData={0}", postData);
			ASCIIEncoding encoding = new ASCIIEncoding();
			byte[] data = encoding.GetBytes(postData);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(pageUrl);
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			httpWebRequest.ContentLength = data.Length;
			httpWebRequest.CookieContainer = cookies;
			Stream postStream = httpWebRequest.GetRequestStream();
			postStream.Write(data, 0, data.Length);
			postStream.Close();
			HttpWebResponse webResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			cookies.Add(webResponse.Cookies);
			StreamReader loginReader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8);
			return loginReader.ReadToEnd();
		}
	}
}
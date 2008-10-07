using System;
using System.IO;
using System.Net;
using System.Text;
using log4net;

namespace Library
{
    public class Browser
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (Browser));
// ReSharper disable RedundantDefaultFieldInitializer
        public static CookieCollection cookieCollection = null;
// ReSharper restore RedundantDefaultFieldInitializer

        //private string pageSource;

        //public string PageSource
        //{
        //    get { return pageSource; }
        //    set { pageSource = value; }
        //}

        /// <summary>
        /// Gets page source.
        /// </summary>
        /// <param name="pageUrl">Url of the page</param>
        /// <param name="pageSource">Page source</param>
        /// <returns><see cref="CookieCollection"/></returns>
        /// 
        public CookieCollection GetPageSource(string pageUrl, out String pageSource)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(pageUrl);
            httpWebRequest.Method = "GET";
            httpWebRequest.CookieContainer = new CookieContainer();
            //httpWebRequest.CookieContainer.Add(new Uri(pageUrl), cookieCollection);
            HttpWebResponse webResponse = (HttpWebResponse) httpWebRequest.GetResponse();
            StreamReader loginReader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8);
            pageSource = loginReader.ReadToEnd();
            cookieCollection = httpWebRequest.CookieContainer.GetCookies(httpWebRequest.RequestUri);
            //Log.DebugFormat("PageSource ['{1}']:'{0}'", pageSource, pageUrl);
            //for (int i = 0; i < cookieCollection.Count; i++)
            //{
            //    Log.DebugFormat("cookieCollection[{1}]=['{0}']", cookieCollection[i], i);
            //}
            return cookieCollection;
        }

		public string GetPageSource(string pageUrl)
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(pageUrl);
			httpWebRequest.Method = "GET";
			httpWebRequest.CookieContainer = new CookieContainer();
			httpWebRequest.CookieContainer.Add(new Uri(pageUrl), cookieCollection);
			HttpWebResponse webResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			StreamReader loginReader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8);
			return loginReader.ReadToEnd();
		}

        /// <summary>
        /// logins to server.
        /// </summary>
        /// <param name="pageUrl">Login page.</param>
        /// <param name="sd"><see cref="ServerData"/></param>
        /// <param name="pageContent">Page source</param>
        /// <returns><see cref="CookieCollection"/></returns>
        /// 
        public CookieCollection Login(String pageUrl, ServerData sd, out String pageContent)
        {
            //w=1152%3A864&login=1220770065&e4a33c4=jezonsky&eb43098=*****&e1fe1de=e697604783&s1.x=48&s1.y=8
            String postData =
                String.Format("w=1152%3A864&login={0}&{1}={2}&{3}={4}&{5}={6}&s1.x=48&s1.y=8",
                              sd.HiddenLoginValue,
                              sd.TextboxLoginName,
                              sd.Username,
                              sd.TextboxPasswordName,
                              sd.Password,
                              sd.HiddenName,
                              sd.HiddenValue);
            Log.InfoFormat("postData ['{0}']", postData);
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] data = encoding.GetBytes(postData);
            HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(pageUrl);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.ContentLength = data.Length;
            httpWebRequest.CookieContainer = new CookieContainer();
            Stream dorf1Stream = httpWebRequest.GetRequestStream();
            dorf1Stream.Write(data, 0, data.Length);
            dorf1Stream.Close();

            HttpWebResponse httpWebResponse = (HttpWebResponse) httpWebRequest.GetResponse();
            cookieCollection = httpWebRequest.CookieContainer.GetCookies(httpWebRequest.RequestUri);
            StreamReader reader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8);
            pageContent = reader.ReadToEnd();
            return cookieCollection;
        }

		public string PostData(string pageUrl, string postData)
		{
			UTF8Encoding encoding = new UTF8Encoding();
			byte[] data = encoding.GetBytes(postData);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(pageUrl);
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			httpWebRequest.ContentLength = data.Length;
			httpWebRequest.CookieContainer = new CookieContainer();
			httpWebRequest.CookieContainer.Add(new Uri(pageUrl), cookieCollection);
			HttpWebResponse webResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			StreamReader streamReader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8);
			return streamReader.ReadToEnd();
		}
    }
}
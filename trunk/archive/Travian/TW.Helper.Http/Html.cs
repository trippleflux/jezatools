#region

using System;
using System.Configuration;
using System.Net;

#endregion

namespace TW.Helper.Http
{
    public class Html
    {
        public Html(string url)
        {
            Url = url;
        }

        public string SendData
            (string postData,
             CookieContainer cookieContainer,
             CookieCollection cookieCollection)
        {
            if (Misc.String2Bool(ConfigurationManager.AppSettings["test"]) == false)
            {
                return SendHttpData(postData, cookieContainer, cookieCollection);
            }
            return Misc.SendHttpFake(Url);
        }

        private static string SendHttpData(string postData,
                                    CookieContainer cookieContainer,
                                    CookieCollection cookieCollection)
        {
            throw new NotImplementedException();
        }

        private readonly string Url;
    }
}
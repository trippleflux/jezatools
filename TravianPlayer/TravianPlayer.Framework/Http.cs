using System;
using System.IO;
using System.Net;
using System.Text;

namespace TravianPlayer.Framework
{
    public class Http
    {
        public static HttpWebResponse SendData(string pageUrl, string postData, CookieContainer cookieContainer,
                                               CookieCollection cookieCollection)
        {
            Console.WriteLine("SendData '{1}' to '{0}'", pageUrl, postData);

            HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(pageUrl);
            httpWebRequest.Method = "GET";
            httpWebRequest.UserAgent =
                "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.1.17) Gecko/20080829 Firefox/2.0.0.17 (.NET CLR 3.5.30729)";
            httpWebRequest.CookieContainer = cookieContainer;
            httpWebRequest.KeepAlive = true;

            if (postData != null)
            {
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] data = encoding.GetBytes(postData);

                httpWebRequest.Method = "POST";
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                httpWebRequest.ContentLength = data.Length;

                Stream postStream = httpWebRequest.GetRequestStream();
                postStream.Write(data, 0, data.Length);
                postStream.Close();
            }

            HttpWebResponse httpWebResponse = (HttpWebResponse) httpWebRequest.GetResponse();
            cookieCollection.Add(httpWebResponse.Cookies);
            cookieContainer.Add(cookieCollection);
            return httpWebResponse;
        }

        //public static bool TryToLogin(ServerInfo serverInfo, CookieContainer cookieContainer,
        //                              CookieCollection cookieCollection, HtmlParser htmlParser, UserInfo userInfo)
        //{
        //    HttpWebResponse httpWebResponse =
        //        SendData(serverInfo.LoginUrl, null, cookieContainer, cookieCollection);
        //    string pageSourceOfLoginPage = HtmlParser.GetPageSource(httpWebResponse);

        //    htmlParser.ParseLoginPage(pageSourceOfLoginPage, userInfo);

        //    serverInfo.LoginCredentials =
        //        String.Format("login={0}&{1}={2}&{3}={4}&{5}={6}",
        //                      userInfo.HiddenLoginValue,
        //                      userInfo.TextBoxUserame,
        //                      userInfo.Username,
        //                      userInfo.TextBoxPassword,
        //                      userInfo.Password,
        //                      userInfo.HiddenName,
        //                      userInfo.HiddenValue);

        //    string postData =
        //        String.Format("w=1152%3A864&{0}&s1.x=48&s1.y=8", serverInfo.LoginCredentials);
        //    httpWebResponse = SendData(serverInfo.ResourcesUrl, postData, cookieContainer, cookieCollection);
        //    //System.Console.WriteLine(HtmlParser.GetPageSource(httpWebResponse));
        //    string resourcesPage = HtmlParser.GetPageSource(httpWebResponse);
        //    return htmlParser.IsLogedIn(resourcesPage, userInfo);
        //}
    }
}
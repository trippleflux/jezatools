using System;
using System.IO;
using System.Net;
using System.Text;

namespace TravianBot.Framework
{
    public class Http
    {
        public static string SendData(
            string pageUrl, 
            string postData, 
            CookieContainer cookieContainer,
            CookieCollection cookieCollection)
        {
            Console.WriteLine("SendData '{1}' to '{0}'", pageUrl, postData);

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(pageUrl);
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

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            cookieCollection.Add(httpWebResponse.Cookies);
            cookieContainer.Add(cookieCollection);
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8);
            return streamReader.ReadToEnd();
        }
    }
}
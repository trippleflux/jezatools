#region

using System;
using System.Net;
using System.Threading;
using TravianPlayer.Framework;

#endregion

namespace TravianPlayer.Console
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                const string userName = "jeza";
                const string passWord = "kepek";
                const string serverName = "http://s4.travian.si/";

                ServerInfo serverInfo = new ServerInfo
                                            {
                                                LoginUrl = (serverName + "login.php"),
                                                ResourcesUrl = string.Format("{0}dorf1.php?newdid={1}", serverName, 0),
                                                BuildingsUrl = string.Format("{0}dorf2.php?newdid={1}", serverName, 0),
                                                SendUnitsUrl = string.Format("{0}a2b.php?newdid={1}", serverName, 0)
                                            };
                CookieCollection cookieCollection = new CookieCollection();
                CookieContainer cookieContainer = new CookieContainer();
                HtmlParser htmlParser = new HtmlParser();
                UserInfo userInfo = new UserInfo
                                        {
                                            Username = userName, 
                                            Password = passWord
                                        };

                bool isLogenIn = Http.TryToLogin(serverInfo, cookieContainer, cookieCollection, htmlParser, userInfo);

                System.Console.WriteLine("UserId : {0}", userInfo.UserId);

                if (isLogenIn)
                {
                    System.Console.WriteLine("Cookies: ");
                    for (int i = 0; i < cookieCollection.Count; i++)
                    {
                        System.Console.WriteLine("{0}={1}, Expires on {2}", 
                            cookieCollection[i].Name, 
                            cookieCollection[i].Value, 
                            cookieCollection[i].Expires.ToLocalTime());
                    }

                    int repeatCount = 0;
                    do
                    {
                        HttpWebResponse httpWebResponse = Http.SendData(serverInfo.ResourcesUrl, null, cookieContainer, cookieCollection);
                        isLogenIn = htmlParser.IsLogedIn(HtmlParser.GetPageSource(httpWebResponse), userInfo);

                        if (isLogenIn)
                        {
                            System.Console.WriteLine("Repeat {0}", repeatCount);
                            if (repeatCount > 100)
                            {
                                repeatCount = 0;
                            }
                            repeatCount++;
                        }
                        Thread.Sleep(60000);
                    } while (repeatCount < 150);
                }
                else
                {
                    System.Console.WriteLine("Not loged in...");
                }
            }
            catch (Exception)
            {
                {
                }
                throw;
            }
        }
    }
}
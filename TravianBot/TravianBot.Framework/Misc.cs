#region

using System;
using System.Configuration;
using System.Net;

#endregion

namespace TravianBot.Framework
{
    public class Misc
    {
        public static string GetConfigValue(string configKey)
        {
            string configValue = String.Empty;
            try
            {
                configValue = ConfigurationManager.AppSettings[configKey];
            }
            catch (Exception)
            {
                Console.WriteLine("Key '{0}' Not Found!!!", configKey);
            }
            return configValue;
        }

        public static bool IsLogedIn
            (ServerInfo serverInfo,
             string postData)
        {
            string pageSource = Http.SendData(serverInfo.Dorf1Url, postData, serverInfo.CookieContainer, serverInfo.CookieCollection);
            HtmlParser htmlParser = new HtmlParser(pageSource);

            htmlParser.ParseUserId(serverInfo);
            return serverInfo.UserId < 0 ? false : true;
        }

        public static bool Login
            (ServerInfo serverInfo,
            LoginPageData loginPageData)
        {
            string postData = String.Format("login={0}&{1}={2}&{3}={4}&{5}={6}",
                                            loginPageData.HiddenLoginValue,
                                            loginPageData.TextBoxUserame,
                                            serverInfo.Username,
                                            loginPageData.TextBoxPassword,
                                            serverInfo.Password,
                                            loginPageData.HiddenName,
                                            loginPageData.HiddenValue);

            return IsLogedIn(serverInfo, postData);
        }
    }
}
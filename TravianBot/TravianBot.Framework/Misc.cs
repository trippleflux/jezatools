#region

using System;
using System.Configuration;
using System.IO;
using System.Text;

#endregion

namespace TravianBot.Framework
{
    public class Misc
    {
        public static void WriteData(string fileName, string content, bool append)
        {
            using (StreamWriter sw = new StreamWriter(fileName, append, Encoding.UTF8))
            {
                sw.Write(content);
                sw.Close();
                sw.Dispose();
            }
        }

        public static string ReadContent(string fileName)
        {
            try
            {
                StreamReader sr = new StreamReader(fileName);
                string content = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();
                return content;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File '{0}' not found", fileName);
                return String.Empty;
            }
        }

        public static bool IsNumber(string input)
        {
            for (int c = 0; c < input.Length; c++)
            {
                if (!IsNumber(input[c]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsNumber(char c)
        {
            return Char.IsNumber(c);
        }

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
            string pageSource = Http.SendData(serverInfo.Dorf1Url, postData, serverInfo.CookieContainer,
                                              serverInfo.CookieCollection);
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
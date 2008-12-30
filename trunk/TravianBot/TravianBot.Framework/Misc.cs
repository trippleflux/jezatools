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
        /// <summary>
        /// Return only numbers from string.
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>Parsed string</returns>
        /// 
        public static string GetOnlyNumbers(string input)
        {
            String a = "";
            for (int c = 0; c < input.Length; c++)
            {
                if (IsNumber(input[c]))
                {
                    a += input[c];
                }
            }

            return a;
        }

        public static Int32 ConvertXY(Int32 x, Int32 y)
        {
            return ((x + 401) + ((400 - y) * 801));
        }

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
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string content = sr.ReadToEnd();
                    sr.Close();
                    sr.Dispose();
                    return content;
                }
            }
            catch (FileNotFoundException)
            {
                File.Create(fileName);
                throw new FileNotFoundException("File '{0}' not found", fileName);
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

        /// <summary>
        /// Gets the config value.
        /// </summary>
        /// <param name="configKey">The config key.</param>
        /// <returns></returns>
        public static string GetConfigValue(string configKey)
        {
            try
            {
                return ConfigurationManager.AppSettings[configKey];
            }
            catch (ConfigurationErrorsException)
            {
                throw new ConfigurationErrorsException("Key '" + configKey + "' Not Found!!!");
            }
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

        public static string SendHttpFake(string pageUrl)
        {
            if (pageUrl.EndsWith("berichte.php"))
            {
                return ReadContent(@"..\..\..\Samples\TestFiles\berichte.php");
            }
            if (pageUrl.EndsWith("berichte.php?id=6214004"))
            {
                return ReadContent(@"..\..\..\Samples\TestFiles\6214004");
            }
            if (pageUrl.EndsWith("berichte.php?id=6214497"))
            {
                return ReadContent(@"..\..\..\Samples\TestFiles\6214497");
            }
            if (pageUrl.EndsWith("berichte.php?id=6216733"))
            {
                return ReadContent(@"..\..\..\Samples\TestFiles\6216733");
            }
            if (pageUrl.EndsWith("dorf1.php?newdid=0"))
            {
                return ReadContent(@"..\..\..\Samples\TestFiles\dorf1.php-newdid=0");
            }
            if (pageUrl.EndsWith("dorf1.php?newdid=1"))
            {
                return ReadContent(@"..\..\..\Samples\TestFiles\dorf1.php-newdid=1");
            }
            if (pageUrl.EndsWith("dorf1.php?newdid=3"))
            {
                return ReadContent(@"..\..\..\Samples\TestFiles\dorf1.php-newdid=3");
            }
            if (pageUrl.EndsWith("dorf1.php?newdid=83117"))
            {
                return ReadContent(@"..\..\..\Samples\TestFiles\dorf1.php-newdid=83117");
            }
            return null;
        }

        public static void UpdateVillages(ServerInfo serverInfo)
        {
            serverInfo.Villages.Clear();
            string pageSource = Http.SendData(serverInfo.Dorf1Url, null, serverInfo.CookieContainer,
                                              serverInfo.CookieCollection);
            HtmlParser htmlParser = new HtmlParser(pageSource);
            htmlParser.ParseVillages(serverInfo);
            Console.WriteLine("Updating Villages...");
            Console.WriteLine("Name                Id");
            foreach (Village village in serverInfo.Villages)
            {
                Console.WriteLine("{0,-20}{1}", village.VillageName, village.VillageId);
            }
        }
    }
}
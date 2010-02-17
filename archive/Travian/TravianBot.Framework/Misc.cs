#region

using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
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
                throw new FileNotFoundException("File '" + fileName + "' not found");
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
            if (c.Equals('+') || c.Equals('-'))
            {
                return true;
            }
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
            //Console.WriteLine(pageSource);
            htmlParser.ParseUserId(serverInfo);
            bool uidFound = serverInfo.UserId < 0 ? false : true;
            if (uidFound)
            {
                pageSource = Http.SendData(serverInfo.SpielerUrl + serverInfo.UserId, null, serverInfo.CookieContainer,
                                           serverInfo.CookieCollection);
                htmlParser = new HtmlParser(pageSource);
                htmlParser.ParseAlianceId(serverInfo);
            }
            return uidFound;
        }

        public static bool Login
            (ServerInfo serverInfo,
             LoginPageData loginPageData)
        {
            string postData = String.Format("login={0}&{1}={2}&{3}={4}&{5}={6}&{5}={6}&s1.x=83&s1.y=7&s1=login",
                                            loginPageData.HiddenLoginValue,
                                            "name",
                                            serverInfo.Username,
                                            "password",
                                            serverInfo.Password,
                                            loginPageData.HiddenName,
                                            loginPageData.HiddenValue);
            Console.WriteLine(postData);
            return IsLogedIn(serverInfo, postData);
        }

        public static bool Login35()
        {
            //w=1680%3A1050&login=1242744256&ec852d4=jeza&e4b7736=*********&edcf8e3=9082b30900&edcf8e3=9082b30900&s1.x=83&s1.y=7&s1=login
            //w=1680%3A1050&login=1266431960&name=jezonsky&password=******&s1.x=20&s1.y=4&s1=login
            return false;
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
            Console.WriteLine("User: {1}[{0}]", serverInfo.UserId, serverInfo.Username);
            Console.WriteLine("AlianceId: {0}", serverInfo.AlianceId);
            Console.WriteLine("Villages:");
            Console.WriteLine("Id        Name");
            foreach (Village village in serverInfo.Villages)
            {
                Console.WriteLine("{1,-10}{0}", village.VillageName, village.VillageId);
            }
        }

        public static void SaveData2SQL(Loot loot)
        {
            // Create a connection and a command
            using (DbConnection cnn = new SQLiteConnection("Data Source=loot.db3"))
            using (DbCommand cmd = cnn.CreateCommand())
            {
                // Open the connection. If the database doesn't exist,
                // it will be created automatically
                cnn.Open();
                // Create a table in the database
                //cmd.CommandText = "CREATE TABLE FOO (ID INTEGER PRIMARY KEY, MYVALUE VARCHAR(50))";
                //cmd.ExecuteNonQuery();
                // Create a parameterized insert command
                cmd.CommandText = "INSERT INTO Loot (MYVALUE) VALUES(?)";
                cmd.Parameters.Add(cmd.CreateParameter());
                // Insert 10 rows into the database
                for (int n = 0; n < 10; n++)
                {
                    cmd.Parameters[0].Value = "Value " + n.ToString();
                    cmd.ExecuteNonQuery();
                }
                // Now read them back
                //cmd.CommandText = "SELECT * FROM FOO";
                //using (DbDataReader reader = cmd.ExecuteReader())
                //{
                //    while (reader.Read())
                //    {
                //        Console.WriteLine(String.Format("ID = {0}, MYVALUE = {1}", reader[0],
                //        reader[1]));
                //    }
                //}
            }
        }

        public static void CreateDB()
        {
            // Create a connection and a command
            using (DbConnection cnn = new SQLiteConnection("Data Source=loot.db3"))
            {
                using (DbCommand cmd = cnn.CreateCommand())
                {
                    // Open the connection. If the database doesn't exist,
                    // it will be created automatically
                    cnn.Open();
                    // Create a table in the database
                    cmd.CommandText = "CREATE TABLE FOO (ID INTEGER PRIMARY KEY, MYVALUE VARCHAR(50))";
                    cmd.ExecuteNonQuery();
                }
                cnn.Close();
            }
        }
    }
}
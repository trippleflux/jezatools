using System;
using System.Net;
using Library;
using log4net;

namespace Console
{
    internal class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (Program));
        private static CookieCollection cookieCollection;

        private static void Main()
        {
            Log.Debug("Console started...");
            try
            {
                ServerData sd = new ServerData();
                sd.Servername = "http://s4.travian.si/";
                sd.Username = "jezonsky";
                sd.Password = "kepek";

                Browser b = new Browser();
                cookieCollection = b.GetPageSource(sd.Servername + "login.php");

                Parser p = new Parser();
                p.LoginData(sd, b.PageSource);

                Log.DebugFormat("HiddenLoginValue{0}", sd.HiddenLoginValue);
                Log.DebugFormat("HiddenName{0}", sd.HiddenName);
                Log.DebugFormat("HiddenValue{0}", sd.HiddenValue);
                Log.DebugFormat("Password{0}", sd.Password);
                Log.DebugFormat("Servername{0}", sd.Servername);
                Log.DebugFormat("TextboxLoginName{0}", sd.TextboxLoginName);
                Log.DebugFormat("TextboxLoginValue{0}", sd.TextboxLoginValue);
                Log.DebugFormat("TextboxPasswordName{0}", sd.TextboxPasswordName);
                Log.DebugFormat("TextboxPasswordValue{0}", sd.TextboxPasswordValue);
                Log.DebugFormat("Username{0}", sd.Username);
                //Log.DebugFormat("{0}", b.PageSource);
                Log.Debug("Cookies:");
                for (int i = 0; i < cookieCollection.Count; i++)
                {
                    Log.DebugFormat("{1}='{0}'", cookieCollection[i], i);
                }

                //http://s3.travian.si/dorf1.php
                //http://s3.travian.si/dorf2.php
                //http://s3.travian.si/karte.php
                //http://s3.travian.si/statistiken.php
                //http://s3.travian.si/berichte.php
                //http://s3.travian.si/nachrichten.php
                String pageSource;
                cookieCollection = b.Login(sd.Servername + "dorf1.php", sd, out pageSource);
                Log.DebugFormat("pageSource:\r\n{0}\r\n", pageSource);
                Log.Debug("Cookies:");
                for (int i = 0; i < cookieCollection.Count; i++)
                {
                    Log.DebugFormat("{1}='{0}' Expires on '{2}'", cookieCollection[i], i,
                                    cookieCollection[i].Expires.ToLocalTime());
                }

                //int loopCount = 0;
                //do
                //{
                //    loopCount++;
                //    if (loopCount > 90)
                //    {
                //        loopCount = 0;
                //    }
                //} while (loopCount < 100);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat(ex.Message);
                Log.ErrorFormat(ex.StackTrace);
            }
        }
    }
}
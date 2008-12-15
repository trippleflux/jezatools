using System;
using System.Globalization;
using System.Net;

namespace TravianBot.Framework
{
    public class ServerInfo
    {
        public ServerInfo()
        {
            servername = Misc.GetConfigValue("serverName");
            Username = Misc.GetConfigValue("userName");
            Password = Misc.GetConfigValue("password");

            LoginUrl = String.Format(CultureInfo.InvariantCulture, "{0}login.php", servername);
            Dorf1Url = String.Format(CultureInfo.InvariantCulture, "{0}dorf1.php", servername);
            Dorf2Url = String.Format(CultureInfo.InvariantCulture, "{0}dorf2.php", servername);
            SendUnitsUrl = String.Format(CultureInfo.InvariantCulture, "{0}a2b.php", servername);
            BuildUrl = String.Format(CultureInfo.InvariantCulture, "{0}build.php", servername);
            ReportsUrl = String.Format(CultureInfo.InvariantCulture, "{0}berichte.php", servername);
            CookieContainer = new CookieContainer();
            CookieCollection = new CookieCollection();
        }

        public string Servername
        {
            get { return servername; }
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public string LoginUrl { get; set; }

        public string Dorf1Url { get; set; }

        public string Dorf2Url { get; set; }

        public string SendUnitsUrl { get; set; }

        public string BuildUrl { get; set; }

        public string ReportsUrl { get; set; }

        public CookieContainer CookieContainer { get; set; }

        public CookieCollection CookieCollection { get; set; }

        private readonly string servername;
    }
}
#region

using System;
using WatiN.Core;

#endregion

namespace TW.Helper
{
    public class DefaultPage : GameData
    {
        public DefaultPage(Browser browser)
        {
            this.browser = browser;
        }

        public DefaultPage
            (Browser browser,
             string server,
             string username,
             string password,
             int defaultVillageId)
        {
            this.browser = browser;
            Server = server;
            Username = username;
            Password = password;
            DefaultVillageId = defaultVillageId;
        }

        public Login LoginPage()
        {
            Login loginPage = new Login(browser)
                              {
                                  Server = Server,
                                  Username = Username,
                                  Password = Password,
                                  DefaultVillageId = DefaultVillageId,
                              };
            return loginPage;
        }

        public Dorf1 Dorf1Page(GameData data)
        {
            Dorf1 dorf1Page = new Dorf1(browser, data)
                              {
                                  Server = Server,
                                  DefaultVillageId = DefaultVillageId,
                              };
            return dorf1Page;
        }

        public Map MapPage()
        {
            Map map = new Map(browser)
                      {
                          Server = Server,
                      };
            return map;
        }

        public SendTroops SendTroopsPage()
        {
            SendTroops sendTroops = new SendTroops(browser)
            {
                Server = Server,
            };
            return sendTroops;
        }

        public IReportReader AttackReport(GameData data)
        {
            IReportReader report = new ReportAttack(browser, data)
                                   {
                                       Server = Server,
                                   };
            return report;
        }

        public string Server { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int DefaultVillageId { get; set; }

        #region Page Elements

        //<a href="logout.php">Logout</a>
        private Link Logout
        {
            get { return browser.Link(Find.ByUrl(Server + "logout.php")); }
        }

        private Link Dorf2
        {
            get { return browser.Link(Find.ById("n2")); }
        }

        private Link Karte
        {
            get { return browser.Link(Find.ById("n3")); }
        }

        private Link Statistiken
        {
            get { return browser.Link(Find.ById("n4")); }
        }

        #endregion

        public void LogoutFromGame()
        {
            Console.WriteLine("Logout from game");
            Logout.Click();
        }

        public void ClickDorf2Link()
        {
            Console.WriteLine("Navigating to Village centre");
            Dorf2.Click();
        }

        public void ClickKarteLink()
        {
            Console.WriteLine("Navigating to Map");
            Karte.Click();
        }

        public void ClickStatistikenLink()
        {
            Console.WriteLine("Navigating to Statistics");
            Statistiken.Click();
        }

        public bool IsLogedIn
        {
            get { return Logout.Exists; }
        }

        private readonly Browser browser;
    }
}
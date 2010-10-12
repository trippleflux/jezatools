#region

using System.Configuration;
using log4net;
using TW.Helper;
using WatiN.Core;
using WatiN.Core.Native.Windows;
using Settings=WatiN.Core.Settings;

#endregion

namespace TW.Neighbour
{
    public class ConsoleApp
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (ConsoleApp));

        public ConsoleApp()
        {
            Settings.CloseExistingBrowserInstances = false;
            browser = new IE(server);
            browser.ShowWindow(NativeMethods.WindowShowStyle.Show);
        }

        public void SearchNeighbourhood()
        {
            Log.InfoFormat("Using XML file only : {0}", !useDataBase);
            using (browser)
            {
                DefaultPage browserPage = Login();
                if (isLoggedIn)
                {
                    Map map = browserPage.MapPage();
                    if (neighboursDistance < 2)
                    {
                        map.AddVillagesFromMapAt(centerX, centerY);
                    }
                    else
                    {
                        for (int i = 0; i < neighboursDistance; i++)
                        {
                            if (i != 1)
                            {
                                continue;
                            }
                            int size = 7*i;
                            for (int j = (1 - neighboursDistance); j < neighboursDistance; j++)
                            {
                                for (int k = (1 - neighboursDistance); k < neighboursDistance; k++)
                                {
                                    int distX = size*k;
                                    int distY = size*j;
                                    map.AddVillagesFromMapAt(centerX + distX, centerY + distY);
                                }
                            }
                        }
                    }
                    map.CollectVillagesInfo();
                    map.SaveVillagesToXmlWithStyleSheet();
                    if (useDataBase)
                    {
                        map.SaveVillagesToDb(map.MapVillages);
                    }
                }
            }
        }

        private DefaultPage Login()
        {
            DefaultPage browserPage = new DefaultPage(browser, server, username, password, defaultVillageId);
            browserPage.LoginPage().LoginToGame();
            isLoggedIn = browserPage.IsLogedIn;
            return browserPage;
        }

        private readonly Browser browser;
        private bool isLoggedIn;

        private readonly string server = ConfigurationManager.AppSettings["server"];
        private readonly string username = ConfigurationManager.AppSettings["username"];
        private readonly string password = ConfigurationManager.AppSettings["password"];

        private readonly int neighboursDistance =
            Misc.String2Number(ConfigurationManager.AppSettings["neighboursDistance"]);

        private readonly int centerX = Misc.String2Number(ConfigurationManager.AppSettings["centerX"]);
        private readonly int centerY = Misc.String2Number(ConfigurationManager.AppSettings["centerY"]);
        private const int defaultVillageId = 0;
        private readonly bool useDataBase = Misc.String2Bool(ConfigurationManager.AppSettings["useDataBase"]);
        //private readonly bool removeOazis = Misc.String2Bool(ConfigurationManager.AppSettings["removeOazis"]);
    }
}
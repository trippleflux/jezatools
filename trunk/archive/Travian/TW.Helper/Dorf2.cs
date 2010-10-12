using System;
using System.Globalization;
using WatiN.Core;

namespace TW.Helper
{
    public class Dorf2 : DefaultPage
    {
        public Dorf2(Browser browser) : base(browser)
        {
            this.browser = browser;
        }

        public void ClickRallyPoint(Village village)
        {
            Console.WriteLine("Navigating to RallyPoint in Village '{0}'", village.Name);
            string url = String.Format(CultureInfo.InvariantCulture, "{0}build.php?newdid={1}&gid=16&id=39", Server, village.Id);
            browser.GoTo(url);
        }

        private readonly Browser browser;
    }
}
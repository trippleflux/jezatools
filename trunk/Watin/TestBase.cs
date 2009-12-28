using System.Configuration;
using NUnit.Framework;
using WatiN.Core;

namespace Watin
{
    public class TestBase
    {
        [SetUp]
        public void SetUp()
        {
            if (Browser4Test.Equals("firefox"))
            {
                TestBrowser = new FireFox();
            }
            TestBrowser = new IE();
        }

        [TearDown]
        public void TearDown()
        {
            TestBrowser.Close();
        }

        public Browser TestBrowser;
        private readonly string Browser4Test = ConfigurationManager.AppSettings["browser"];
    }
}
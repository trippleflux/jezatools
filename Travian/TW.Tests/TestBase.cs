using System;
using System.IO;
using MbUnit.Framework;
using WatiN.Core;

namespace TW.Tests
{
    public class TestBase
    {
        protected readonly IBrowserTestManager IeManager = new IeBrowserTestManager();
        protected Browser Browser;

        public static Uri BaseUri
        {
            get { return new Uri(GetTestFilesLocation()); }
        }

        private static string GetTestFilesLocation()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            return Path.Combine(baseDirectory.FullName, "..\\..\\TestFiles\\");
        }

        public void GetBrowser(string page)
        {
            Browser = IeManager.GetBrowser(new Uri(BaseUri, page));
        }

        [SetUp]
        public void SetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
            IeManager.CloseBrowser();
        }
    }
}
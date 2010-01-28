#region

using System;
using NUnit.Framework;
using WatiN.Core;

#endregion

namespace Watin
{
    [Page(UrlRegex = "www.google.*")]
    public class GooglePage : Page, IDisposable
    {
        public Browser TestBrowser { get; set; }

        public GooglePage AssertTextExists(string text)
        {
            Assert.That(TestBrowser.ContainsText(text), Is.True);
            return this;
        }

        public GooglePage IFeelLucky(string text)
        {
            TextBoxSearch.TypeText(text);
            ButtonIFeelLucky.Click();
            return this;
        }

        public GooglePage SearchFor(string text)
        {
            TextBoxSearch.TypeText(text);
            ButtonSearch.Click();
            return this;
        }

        public GooglePage SetBrowser(Browser browser)
        {
            TestBrowser = browser;
            TestBrowser.GoTo(Url);
            return this;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the object.
        /// </summary>
        /// <param name="disposing">If <code>false</code>, cleans up native resources. 
        /// If <code>true</code> cleans up both managed and native resources</param>
        protected virtual void Dispose(bool disposing)
        {
            if (false == Disposed)
            {
                if (disposing)
                {
                    TestBrowser.Dispose();
                }
                Disposed = true;
            }
        }

        private bool Disposed;

        [FindBy(Name = "q")] private TextField TextBoxSearch;

        [FindBy(Name = "btnG")] private Button ButtonSearch;

        [FindBy(Name = "btnI")] private Button ButtonIFeelLucky;

        private const string Url = "http://www.google.com";
    }
}
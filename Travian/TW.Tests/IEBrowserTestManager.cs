using System;
using WatiN.Core;

namespace TW.Tests
{
    public class IeBrowserTestManager : IBrowserTestManager
    {
        private IE ie;

        public Browser CreateBrowser(Uri uri)
        {
            return new IE(uri);
        }

        public Browser GetBrowser(Uri uri)
        {
            if (ie == null)
            {
                ie = (IE)CreateBrowser(uri);
            }

            return ie;
        }

        public void CloseBrowser()
        {
            if (ie == null) return;
            ie.Close();
            ie = null;
            if (IE.InternetExplorers().Count == 0) return;

            //foreach (var explorer in IE.InternetExplorersNoWait())
            //{
            //    Console.WriteLine(explorer.Title + " (" + explorer.Url + ")");
            //    explorer.Close();
            //}
            //throw new Exception("Expected no open IE instances.");
        }
    }
}
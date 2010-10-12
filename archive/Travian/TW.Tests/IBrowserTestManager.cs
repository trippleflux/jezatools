#region

using System;
using WatiN.Core;

#endregion

namespace TW.Tests
{
    public interface IBrowserTestManager
    {
        Browser CreateBrowser(Uri uri);
        Browser GetBrowser(Uri uri);
        void CloseBrowser();
    }
}
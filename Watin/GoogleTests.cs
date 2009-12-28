#region

using NUnit.Framework;

#endregion

namespace Watin
{
    [TestFixture]
    public class GoogleTests : TestBase
    {
        [Test]
        public void Search()
        {
            using (GooglePage google = TestBrowser.Page<GooglePage>())
            {
                google
                    .SetBrowser(TestBrowser)
                    .SearchFor("Watin")
                    .AssertTextExists("Watin");
            }
        }

        [Test]
        public void IFeelLucky()
        {
            using (GooglePage google= TestBrowser.Page<GooglePage>())
            {
                google
                    .SetBrowser(TestBrowser)
                    .IFeelLucky("Watin")
                    .AssertTextExists("WatiN  Overview");
            }
        }
    }
}
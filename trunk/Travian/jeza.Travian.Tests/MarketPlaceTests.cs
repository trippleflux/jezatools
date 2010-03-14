#region

using HtmlAgilityPack;
using jeza.Travian.Framework;
using jeza.Travian.Parser;
using MbUnit.Framework;

#endregion

namespace jeza.Travian.Tests
{
    [TestFixture]
    internal class MarketPlaceTests : TestsBase
    {
        [Test]
        public void Idle()
        {
            DeserializeLanguage();
            Language language = Languages.GetLanguage("sl-SI");
            Assert.IsNotNull(language, "Language is null!");
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load("..\\..\\Test Files\\Marketplace.idle.php.html");
            HtmlParser htmlParser = new HtmlParser(htmlDocument, language);
            MarketPlace marketPlace = htmlParser.MarketPlace();
            Assert.IsNotNull(marketPlace, "NULL");
            Assert.AreEqual(3, marketPlace.AvailableMerchants, "AvailableMerchants");
            Assert.AreEqual(6, marketPlace.TotalMerchants, "TotalMerchants");
            Assert.AreEqual(750, marketPlace.TotalCarry, "TotalCarry");
        }
    }
}
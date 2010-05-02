#region

using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using jeza.Travian.Framework;
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

        [Test]
        public void IncommingTransport()
        {
            DeserializeLanguage();
            Language language = Languages.GetLanguage("sl-SI");
            Assert.IsNotNull(language, "Language is null!");
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load("..\\..\\Test Files\\Marketplace.php.html");
            HtmlParser htmlParser = new HtmlParser(htmlDocument, language);
            MarketPlace marketPlace = htmlParser.MarketPlace();
            Assert.IsNotNull(marketPlace, "NULL");
            Assert.AreEqual(11, marketPlace.AvailableMerchants, "AvailableMerchants");
            Assert.AreEqual(15, marketPlace.TotalMerchants, "TotalMerchants");
            Assert.AreEqual(750, marketPlace.TotalCarry, "TotalCarry");
            Assert.AreEqual(2, marketPlace.TotalIncommingTransports, "TotalIncommingTransports");
            Assert.AreEqual(3750, marketPlace.TotalIncommingWood, "TotalIncommingWood");
            Assert.AreEqual(750, marketPlace.TotalIncommingClay, "TotalIncommingClay");
            Assert.AreEqual(750, marketPlace.TotalIncommingIron, "TotalIncommingIron");
            Assert.AreEqual(750, marketPlace.TotalIncommingCrop, "TotalIncommingCrop");
        }

        [Test]
        public void CalculatorDestinationBellowPercent()
        {
            DeserializeLanguage();
            Language language = Languages.GetLanguage("sl-SI");
            Assert.IsNotNull(language, "Language is null!");
            
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load("..\\..\\Test Files\\Marketplace.php.html");
            HtmlParser htmlParser = new HtmlParser(htmlDocument, language);
            MarketPlace marketPlaceDestination = htmlParser.MarketPlace();
            Assert.IsNotNull(marketPlaceDestination, "NULL");
            Village destinationVillage = new Village();
            destinationVillage.AddId(123).AddName("01");
            Production productionDestination = htmlParser.GetProduction();
            Assert.IsNotNull(productionDestination, "NULL");
            destinationVillage.UpdateProduction(productionDestination);
            
            htmlDocument = new HtmlDocument();
            htmlDocument.Load("..\\..\\Test Files\\Marketplace.idle.php.html");
            htmlParser = new HtmlParser(htmlDocument, language);
            MarketPlace marketPlaceSource = htmlParser.MarketPlace();
            Assert.IsNotNull(marketPlaceSource, "NULL");
            Village sourceVillage = new Village();
            sourceVillage.AddId(321).AddName("02");
            Production productionSource = htmlParser.GetProduction();
            Assert.IsNotNull(productionSource, "NULL");
            sourceVillage.UpdateProduction(productionSource);

            DateTime dt = new DateTime(DateTime.Now.Ticks);
            MarketPlaceQueue queue = new MarketPlaceQueue
                {
                    DestinationVillage = destinationVillage,
                    SourceVillage = sourceVillage,
                    Goods = 80,
                    SendWood = true,
                    SendClay = true,
                    SendIron = true,
                    SendCrop = true,
                    SendGoodsType = SendGoodsType.DestinationBellowPercent,
                    LastSend = dt.AddDays(-1),
                    RepeatMinutes = 10,
                };

            MarketPlaceCalculator calculator = new MarketPlaceCalculator
                {
                    Destination = destinationVillage,
                    Source = sourceVillage,
                    MarketPlaceDestination = marketPlaceDestination,
                    MarketPlaceSource = marketPlaceSource,
                    Queue = queue,
                };
            calculator.Calculate();
            Assert.AreEqual("&r1=0&r2=1246&r3=1004&r4=0", calculator.PostParameters, "PostParameters");
            Assert.IsTrue(calculator.TimeToSend(dt), "Last send time");
        }

        [Test]
        public void CalculatorSourceOverPercent()
        {
            DeserializeLanguage();
            Language language = Languages.GetLanguage("sl-SI");
            Assert.IsNotNull(language, "Language is null!");

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load("..\\..\\Test Files\\Marketplace.php.html");
            HtmlParser htmlParser = new HtmlParser(htmlDocument, language);
            MarketPlace marketPlaceDestination = htmlParser.MarketPlace();
            Assert.IsNotNull(marketPlaceDestination, "NULL");
            Village destinationVillage = new Village();
            destinationVillage.AddId(123).AddName("01");
            Production productionDestination = htmlParser.GetProduction();
            Assert.IsNotNull(productionDestination, "NULL");
            destinationVillage.UpdateProduction(productionDestination);

            htmlDocument = new HtmlDocument();
            htmlDocument.Load("..\\..\\Test Files\\Marketplace.idle.php.html");
            htmlParser = new HtmlParser(htmlDocument, language);
            MarketPlace marketPlaceSource = htmlParser.MarketPlace();
            Assert.IsNotNull(marketPlaceSource, "NULL");
            Village sourceVillage = new Village();
            sourceVillage.AddId(321).AddName("02");
            Production productionSource = htmlParser.GetProduction();
            Assert.IsNotNull(productionSource, "NULL");
            sourceVillage.UpdateProduction(productionSource);

            DateTime dt = new DateTime(DateTime.Now.Ticks);
            MarketPlaceQueue queue = new MarketPlaceQueue
            {
                DestinationVillage = destinationVillage,
                SourceVillage = sourceVillage,
                Goods = 50,
                GoodsToSend = 750,
                SendWood = true,
                SendClay = true,
                SendIron = true,
                SendCrop = true,
                SendGoodsType = SendGoodsType.SourceOverPercent,
                LastSend = dt.AddHours(-2),
                RepeatMinutes = 10,
            };

            MarketPlaceCalculator calculator = new MarketPlaceCalculator
            {
                Destination = destinationVillage,
                Source = sourceVillage,
                MarketPlaceDestination = marketPlaceDestination,
                MarketPlaceSource = marketPlaceSource,
                Queue = queue,
            };
            calculator.CalculateSourceOver();
            Assert.AreEqual("&r1=750&r2=750&r3=0&r4=750", calculator.PostParameters, "PostParameters");
            Assert.IsTrue(calculator.TimeToSend(dt), "Last send time");
        }

        [Test]
        public void HiddenFields()
        {
            MarketPlaceCalculator calculator = new MarketPlaceCalculator
            {
                Destination = new Village(),
                Source = new Village(),
                MarketPlaceDestination = new MarketPlace(),
                MarketPlaceSource = new MarketPlace(),
                Queue = new MarketPlaceQueue(),
            };
            DeserializeLanguage();
            Language language = Languages.GetLanguage("sl-SI");
            Assert.IsNotNull(language, "Language is null!");

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load("..\\..\\Test Files\\Marketplace.php.html");
            calculator.GetHiddenValues(htmlDocument);
            Assert.AreEqual(new Dictionary<string, string> {{"id", "33"}}, calculator.HiddenValues);
        }
    }
}
#region

using System.Collections.Generic;
using HtmlAgilityPack;
using jeza.Travian.Framework;
using jeza.Travian.Parser;
using MbUnit.Framework;

#endregion

namespace jeza.Travian.Tests
{
    public class MapTests
    {
        [Test]
        public void ParseMap()
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load("..\\..\\Test Files\\karte.php.html");
            HtmlParser htmlParser = new HtmlParser(htmlDocument);
            List<Valley> valleys = htmlParser.GetVillagesFromMap();
            Assert.IsNotNull(valleys, "valleys is null!");
            Assert.AreEqual(4, valleys.Count, "Valleys count!");
        }

        [Test]
        public void ParseOases()
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load("..\\..\\Test Files\\karte.php.html");
            HtmlParser htmlParser = new HtmlParser(htmlDocument);
            List<Valley> oases = htmlParser.GetOasesFromMap();
            Assert.AreEqual(7, oases.Count, "Oases count!");
        }
        [Test]
        public void VillageInfo()
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load("..\\..\\Test Files\\village.php.html");
            HtmlParser htmlParser = new HtmlParser(htmlDocument);
            Valley valley = htmlParser.GetVillageDetails();
            Assert.IsNotNull(valley, "valley is null!");
            Assert.AreEqual("gajo123", valley.VillageName, "VillageName!");
            Assert.AreEqual(-80, valley.X, "X coordinate!");
            Assert.AreEqual(67, valley.Y, "Y coordinate!");
            Assert.AreEqual("allianz.php?aid=0", valley.AllianceUrl, "Alliance url!");
            Assert.AreEqual("", valley.AllianceName, "Alliance name!");
            Assert.AreEqual("novakm", valley.PlayerName, "Player name!");
            Assert.AreEqual("spieler.php?uid=11436", valley.PlayerUrl, "Player url!");
            Assert.AreEqual(36, valley.VillagePopulation, "Village Population!");
        }
    }
}
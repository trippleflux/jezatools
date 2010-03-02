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
            List<Neighborhood> neighborhood = htmlParser.GetVillagesFromMap();
            Assert.IsNotNull(neighborhood, "Neighborhood is null!");
            Assert.AreEqual(4, neighborhood.Count, "Villages count!");
        }

        [Test]
        public void ParseOases()
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load("..\\..\\Test Files\\karte.php.html");
            HtmlParser htmlParser = new HtmlParser(htmlDocument);
            List<Oases> oases = htmlParser.GetOasesFromMap();
            Assert.AreEqual(7, oases.Count, "Oases count!");
        }
        [Test]
        public void VillageInfo()
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load("..\\..\\Test Files\\village.php.html");
            HtmlParser htmlParser = new HtmlParser(htmlDocument);
            Neighborhood village = htmlParser.GetVillageDetails();
            Assert.IsNotNull(village, "village is null!");
            Assert.AreEqual("gajo123", village.VillageName, "VillageName!");
            Assert.AreEqual(-80, village.X, "X coordinate!");
            Assert.AreEqual(67, village.Y, "Y coordinate!");
            Assert.AreEqual("allianz.php?aid=0", village.AllianceUrl, "Alliance url!");
            Assert.AreEqual("", village.AllianceName, "Alliance name!");
            Assert.AreEqual("novakm", village.PlayerName, "Player name!");
            Assert.AreEqual("spieler.php?uid=11436", village.PlayerUrl, "Player url!");
            Assert.AreEqual(36, village.VillagePopulation, "Village Population!");
        }
    }
}
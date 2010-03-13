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
            Assert.AreEqual("gajo123", valley.Name, "Name!");
            Assert.AreEqual(267054, valley.VillageId, "Vilalge id!");
            Assert.AreEqual(-80, valley.X, "X coordinate!");
            Assert.AreEqual(67, valley.Y, "Y coordinate!");
            Assert.AreEqual("allianz.php?aid=0", valley.AllianceUrl, "Alliance url!");
            Assert.AreEqual(0, valley.AllianceId, "Alliance Id!");
            Assert.AreEqual("", valley.Alliance, "Alliance name!");
            Assert.AreEqual("novakm", valley.Player, "Player name!");
            Assert.AreEqual("spieler.php?uid=11436", valley.PlayerUrl, "Player url!");
            Assert.AreEqual(11436, valley.PlayerId, "User id!");
            Assert.AreEqual(36, valley.Population, "Village Population!");
        }

        [Test]
        public void UnoccupiedOasisInfo()
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load("..\\..\\Test Files\\karte.unoccupied.oases.php.html");
            HtmlParser htmlParser = new HtmlParser(htmlDocument);
            Valley valley = htmlParser.GetOasesDetails();
            Assert.IsNotNull(valley, "valley is null!");
            Assert.AreEqual(-85, valley.X, "X coordinate!");
            Assert.AreEqual(61, valley.Y, "Y coordinate!");
            Assert.AreEqual("+25% zeleza na uro", valley.Name, "Name");
            Assert.AreEqual("Nezasedena pokrajina", valley.Alliance, "Alliance");
            Assert.AreEqual(0, valley.AllianceId, "Alliance Id");
            Assert.AreEqual("Nezasedena pokrajina", valley.Player, "Player");
            Assert.AreEqual(0, valley.PlayerId, "Player Id");
            Assert.AreEqual(ValleyType.UnoccupiedOasis, valley.ValleyType, "ValleyType.UnoccupiedOasis");
        }

        [Test]
        public void OccupiedOasisInfo()
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load("..\\..\\Test Files\\karte.ocupied.oases.php.html");
            HtmlParser htmlParser = new HtmlParser(htmlDocument);
            Valley valley = htmlParser.GetOasesDetails();
            Assert.IsNotNull(valley, "valley is null!");
            Assert.AreEqual(-85, valley.X, "X coordinate!");
            Assert.AreEqual(59, valley.Y, "Y coordinate!");
            Assert.AreEqual("Thor[+25% zita na uro]", valley.Name, "Name");
            Assert.AreEqual("LegacyTM", valley.Alliance, "Alliance");
            Assert.AreEqual("Olaf", valley.Player, "Player");
            Assert.AreEqual(ValleyType.OccupiedOasis, valley.ValleyType, "ValleyType.UnoccupiedOasis");
        }
    }
}
#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using HtmlAgilityPack;
using jeza.Travian.Framework;
using jeza.Travian.Parser;
using MbUnit.Framework;

#endregion

namespace jeza.Travian.Tests
{
    [TestFixture]
    public class TroopsTests
    {
        [Test]
        public void HtmlParser()
        {
            DeserializeLanguage();
            Language language = languages.GetLanguage("sl-SI");
            Assert.IsNotNull(language, "Language is null!");
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load("..\\..\\Test Files\\RallyPoint.php.html");
            HtmlParser htmlParser = new HtmlParser(htmlDocument, language);
            List<TroopMovement> troopMovements = htmlParser.TroopMovements(new Village().AddId(1).AddName("02"));
            Assert.IsNotNull(troopMovements, "TroopMovement is null!");
            Village village = new Village();
            village.SetTroopMovements(troopMovements);
            Assert.AreEqual(23, village.TroopMovementCount, "Troop movement count!");
            Assert.Sorted(village.TroopMovement, SortOrder.Increasing, new TroopMovementComparer());
            village.ClearTroopMovementsList();
            Assert.AreEqual(0, village.TroopMovementCount, "Troop movement count!");
        }

        [Test]
        public void TroopMovements()
        {
            Tribes tribes = new Tribes();
            TroopUnit unit = tribes.GetUnit("unit u21");
            Assert.IsNotNull(unit, "Unit not found!");
            Assert.AreEqual(unit.Name, "Phalanx", "Unit not found!");
            unit.AddTroopCount(123).AddName("Falanga");
            Assert.AreEqual(unit.Name, "Falanga", "Unit not found!");
            Troops troops = new Troops();
            troops.AddTroopUnit(unit);
            unit = tribes.GetUnit("unit u22");
            unit.AddTroopCount(321).AddName("Mecevalec");
            troops.AddTroopUnit(unit);

            TroopMovement troopMovement = new TroopMovement();
            DateTime arrivalDateTime = new DateTime(9999, 12, 31, 1, 2, 3);
            const string villageNameDestination = "01";
            const string villageNameSource = "00";
            const string urlDestination = "http://speed.travian.com/karte.php?id=123";
            const string urlSource = "http://asd.php";
            troopMovement
                .AddTroops(troops)
                .SetDate(arrivalDateTime)
                .SetType(TroopMovementType.AttackOutgoing)
                .SetDestination(villageNameDestination, urlDestination)
                .SetSource(villageNameSource, urlSource);

            Assert.IsNotNull(troopMovement, "TroopMovement");
            Assert.AreEqual(TroopMovementType.AttackOutgoing, troopMovement.Type, "Type");
            Assert.AreEqual(arrivalDateTime, troopMovement.DateTime, "arrivalDateTime");
            Assert.AreEqual(villageNameDestination, troopMovement.DestinationVillageName, "villageNameDestination");
            Assert.AreEqual(urlDestination, troopMovement.DestinationVillageUrl, "urlDestination");
            Assert.AreEqual(villageNameSource, troopMovement.SourceVillageName, "villageNameSource");
            Assert.AreEqual(urlSource, troopMovement.SourceVillageUrl, "urlSource");
            Assert.AreEqual(troops, troopMovement.Troops, "troops");
        }

        [Test]
        public void GaulsTroopsData()
        {
            Gauls gauls = new Gauls();
            gauls.Phalanx.AddTroopCount(11);
            gauls.Swordsman.AddTroopCount(22);
            Troops troops = new Troops();
            troops.AddTroopUnit(gauls.Phalanx).AddTroopUnit(gauls.Swordsman);

            Assert.IsNotNull(troops.TroopsList, "Troop list is null!");
            Assert.AreEqual(2, troops.TroopsList.Count, "Count!");
            Assert.AreEqual(11, troops.GetTroopCount("unit u21"), "Phalanx!");
            Assert.AreEqual(22, troops.GetTroopCount("unit u22"), "Swordsman!");
            Assert.AreEqual(0, troops.GetTroopCount("unit u23"), "Pathfinder!");
            Assert.AreNotEqual(gauls.Ram, troops.GetTroopInfo("unit u21"), "TroopInfo!");
            Assert.AreEqual(gauls.Phalanx, troops.GetTroopInfo("unit u21"), "TroopInfo!");
            Assert.AreEqual(gauls.Swordsman, troops.GetTroopInfo("unit u22"), "TroopInfo!");
        }

        [Test]
        public void RomansTroopsData()
        {
            Romans romans = new Romans();
            romans.BatteringRam.AddTroopCount(11);
            romans.Imperian.AddTroopCount(22);
            Troops troops = new Troops();
            troops.AddTroopUnit(romans.BatteringRam).AddTroopUnit(romans.Imperian);

            Assert.IsNotNull(troops.TroopsList, "Troop list is null!");
            Assert.AreEqual(2, troops.TroopsList.Count, "Count!");
            Assert.AreEqual(11, troops.GetTroopCount("unit u7"), "BatteringRam!");
            Assert.AreEqual(22, troops.GetTroopCount("unit u3"), "Imperian!");
            Assert.AreEqual(0, troops.GetTroopCount("unit u23"), "Pathfinder!");
            Assert.AreNotEqual(romans.Hero, troops.GetTroopInfo("unit u7"), "TroopInfo!");
            Assert.AreEqual(romans.Imperian, troops.GetTroopInfo("unit u3"), "TroopInfo!");
            Assert.AreEqual(romans.BatteringRam, troops.GetTroopInfo("unit u7"), "TroopInfo!");
        }

        [Test]
        public void TeutonsTroopsData()
        {
            Teutons teutons = new Teutons();
            teutons.Axeman.AddTroopCount(11);
            teutons.Paladin.AddTroopCount(22);
            Troops troops = new Troops();
            troops.AddTroopUnit(teutons.Axeman).AddTroopUnit(teutons.Paladin);

            Assert.IsNotNull(troops.TroopsList, "Troop list is null!");
            Assert.AreEqual(2, troops.TroopsList.Count, "Count!");
            Assert.AreEqual(11, troops.GetTroopCount("unit u13"), "Axeman!");
            Assert.AreEqual(22, troops.GetTroopCount("unit u15"), "Paladin!");
            Assert.AreEqual(0, troops.GetTroopCount("unit u23"), "Pathfinder!");
            Assert.AreNotEqual(teutons.Hero, troops.GetTroopInfo("unit u17"), "TroopInfo!");
            Assert.AreEqual(teutons.Axeman, troops.GetTroopInfo("unit u13"), "TroopInfo!");
            Assert.AreEqual(teutons.Paladin, troops.GetTroopInfo("unit u15"), "TroopInfo!");
        }

        [Test]
        public void Swordsman()
        {
            Gauls gauls = new Gauls();
            Assert.AreEqual("Swordsman", gauls.Swordsman.Name, "Name");
            Assert.AreEqual("unit u22", gauls.Swordsman.ClassAttribute, "Class");
            Assert.AreEqual(0, gauls.Swordsman.Count, "Count");
            Assert.AreEqual("t2", gauls.Swordsman.SendTroopsTextBoxAttribute, "Send TextBox");
            gauls.Swordsman.AddTroopCount(123);
            Assert.AreEqual(123, gauls.Swordsman.Count, "Count");
        }

        private void DeserializeLanguage()
        {
            using (FileStream fileStream = new FileStream("Language.xml", FileMode.Open))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Languages));
                languages = (Languages)xmlSerializer.Deserialize(fileStream);
            }
        }

        private Languages languages = new Languages();
    }
}
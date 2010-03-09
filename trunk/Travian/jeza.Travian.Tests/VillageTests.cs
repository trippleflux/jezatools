#region

using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using jeza.Travian.Framework;
using jeza.Travian.Parser;
using MbUnit.Framework;

#endregion

namespace jeza.Travian.Tests
{
    [TestFixture]
    public class VillageTests
    {
        [Test]
        public void ParseResources()
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load("..\\..\\Test Files\\dorf1.php.html");
            HtmlParser htmlParser = new HtmlParser(htmlDocument);
            Village village = new Village();
            village.AddId(123).AddName("01");
            List<Buildings> buildings = htmlParser.GetResourceBuildings(village);
            Assert.IsNotNull(buildings, "NULL");
            Assert.AreEqual(18, buildings.Count, "COUNT");
        }

        [Test]
        public void ParseCenterBuildings()
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load("..\\..\\Test Files\\dorf2.php.html");
            HtmlParser htmlParser = new HtmlParser(htmlDocument);
            Village village = new Village();
            village.AddId(123).AddName("01");
            List<Buildings> buildings = htmlParser.GetCenterBuildings(village);
            Assert.IsNotNull(buildings, "NULL");
            Assert.AreEqual(22, buildings.Count, "COUNT");
        }

        [Test]
        public void ParseAvailableVillages()
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load("..\\..\\Test Files\\dorf1.php.html");
            HtmlParser htmlParser = new HtmlParser(htmlDocument);
            List<Village> villages = htmlParser.GetAvailableVillages();
            Assert.IsNotNull(villages, "villages is null!");
            Assert.AreEqual(2, villages.Count, "Villages count!");
            Assert.AreEqual(-82, villages[0].CoordinateX, "CoordinateX!");
            Assert.AreEqual(64, villages[0].CoordinateY, "CoordinateY!");

            htmlDocument.Load("..\\..\\Test Files\\dorf1.php.1.village.html");
            htmlParser = new HtmlParser(htmlDocument);
            villages = htmlParser.GetAvailableVillages();
            Assert.IsNotNull(villages, "villages is null!");
            Assert.AreEqual(1, villages.Count, "Villages count!");
            Assert.AreEqual(0, villages[0].CoordinateX, "CoordinateX!");
            Assert.AreEqual(0, villages[0].CoordinateY, "CoordinateY!");
        }

        /// <summary>
        /// Tests if village is properly updated.
        /// </summary>
        [Test]
        public void VillageData()
        {
            Production production = new Production();
            const int warehouse = 3100;
            const int granary = 4000;
            production
                .UpdateWarehouse(warehouse)
                .UpdateGranary(granary)
                .UpdateTotals(132, 213, 11, 223)
                .UpdatePerHour(100, 200, 300, 400);
            Assert.IsNotNull(production, "Production is null!");

            TroopUnit phalanx = new TroopUnit();
            phalanx.AddName("Phalanx").AddHtmlClassName("unit u23").AddTroopCount(11);
            TroopUnit axeman = new TroopUnit();
            axeman.AddName("Axeman").AddHtmlClassName("unit u3").AddTroopCount(22);
            Troops troops = new Troops();
            troops.AddTroopUnit(phalanx).AddTroopUnit(axeman);
            Assert.IsNotNull(troops.TroopsList, "Troop list is null!");

            const int villageId = 0;
            const string villageName = "asds";
            const int coordinateX = 13;
            const int coordinateY = -131;
            Village village = new Village();
            village
                .AddId(villageId)
                .AddName(villageName)
                .UpdateCoordinates(coordinateX, coordinateY)
                .UpdateProduction(production)
                .UpdateTroopsInVillage(troops);

            Assert.IsNotNull(village.Production, "Production is null!");
            Assert.IsNotNull(village.TroopsAvailable, "TroopsAvailable is null!");
            Assert.AreEqual(production, village.Production, "Village production!");
            Assert.AreEqual(troops, village.TroopsAvailable, "Village troops!");
            Assert.AreEqual(warehouse, village.Production.Warehouse, "Warehouse!");
            Assert.AreEqual(granary, village.Production.Granary, "Granary!");
            Assert.AreEqual(coordinateX, village.CoordinateX, "CoordinateX!");
            Assert.AreEqual(coordinateY, village.CoordinateY, "CoordinateY!");
            village
                .AddTroopsMovement(new TroopMovement()
                                       .AddTroops(new Troops().AddTroopUnit(new TroopUnit("unit11", 12)))
                                       .AddTroops(new Troops().AddTroopUnit(new TroopUnit("unit12", 13)))
                                       .AddTroops(new Troops().AddTroopUnit(new TroopUnit("unit13", 14)))
                                       .AddTroops(new Troops().AddTroopUnit(new TroopUnit("unit14", 15)))
                                       .SetDate(new DateTime(2222, 12, 1, 1, 1, 1))
                                       .SetType(TroopMovementType.AttackIncomming))
                .AddTroopsMovement(new TroopMovement()
                                       .AddTroops(new Troops().AddTroopUnit(new TroopUnit("unit31", 1201)))
                                       .AddTroops(new Troops().AddTroopUnit(new TroopUnit("unit32", 1202)))
                                       .AddTroops(new Troops().AddTroopUnit(new TroopUnit("unit33", 1203)))
                                       .AddTroops(new Troops().AddTroopUnit(new TroopUnit("unit34", 1204)))
                                       .AddTroops(new Troops().AddTroopUnit(new TroopUnit("unit35", 1205)))
                                       .AddTroops(new Troops().AddTroopUnit(new TroopUnit("unit36", 1206)))
                                       .SetDate(new DateTime(2222, 10, 1, 1, 1, 1))
                                       .SetType(TroopMovementType.AttackOutgoing))
                .AddTroopsMovement(new TroopMovement()
                                       .AddTroops(new Troops().AddTroopUnit(new TroopUnit("unit21", 121)))
                                       .AddTroops(new Troops().AddTroopUnit(new TroopUnit("unit22", 122)))
                                       .AddTroops(new Troops().AddTroopUnit(new TroopUnit("unit23", 123)))
                                       .SetDate(new DateTime(2222, 11, 1, 1, 1, 1))
                                       .SetType(TroopMovementType.AttackOutgoing))
                .AddTroopsMovement(new TroopMovement()
                                       .AddTroops(new Troops().AddTroopUnit(new TroopUnit("unit4", 12000)))
                                       .SetDate(new DateTime(2222, 9, 1, 1, 1, 1))
                                       .SetType(TroopMovementType.ReinforcementIncomming))
                ;

            Assert.IsNotNull(village.TroopMovement, "Troop movement!");
            Assert.AreEqual(4, village.TroopMovementCount, "Troop movement count!");
            Assert.AreEqual(2, village.OwnAttacks, "Own attacks!");
            Assert.Sorted(village.TroopMovement, SortOrder.Increasing, new TroopMovementComparer());
            village.ClearTroopMovementsList();
            Assert.AreEqual(0, village.TroopMovementCount, "Troop movement count!");
        }
    }
}
using jeza.Travian.Framework;
using MbUnit.Framework;

namespace jeza.Travian.Tests
{
    [TestFixture]
    public class VillageTests
    {
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
        }
    }
}
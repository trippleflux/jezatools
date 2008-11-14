using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using TravianPlayer.Framework;

namespace TravianPlayer.Tests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void VillageInfo()
        {
            const int userId = 8875;
            int villageId = 0;
            string villageName = "00";
            Village village = new Village(villageId, villageName);

            Game game = new Game();
            game.AddVillage(village);
            Assert.IsNotNull(game.Villages);
            Assert.AreEqual(1, game.GetVillagesCount);
            Assert.AreEqual("00", game.GetVillageName(0));
            game.UserId = userId;
            Assert.AreEqual(8875, game.UserId);

            villageId = 1;
            villageName = "01";
            village = new Village(villageId, villageName);
            game.AddVillage(village);
            Assert.IsNotNull(game.Villages);
            Assert.AreEqual(2, game.GetVillagesCount);
            Assert.AreEqual("01", game.GetVillageName(1));

            int buildingId = 1;
            string buildingName = "Gozdar";
            int buildingLevel = 5;
            
            Building building = new Building(buildingId, buildingName, buildingLevel);
            village.AddBuilding(building);
            Assert.IsNotNull(village.Buildings);
            Assert.AreEqual(1, village.GetBuildingsCount);
            Assert.AreEqual(5, village.GetBuildingsLevel(1));
            Assert.AreEqual("Gozdar", village.GetBuildingsName(1));

            buildingId = 2;
            buildingName = "Barake";
            buildingLevel = 4;

            building = new Building(buildingId, buildingName, buildingLevel);
            village.AddBuilding(building);
            Assert.IsNotNull(village.Buildings);
            Assert.AreEqual(2, village.GetBuildingsCount);
            Assert.AreEqual(4, village.GetBuildingsLevel(2));
            Assert.AreEqual("Barake", village.GetBuildingsName(2));

            buildingId = 2;
            buildingName = "Zid";
            buildingLevel = 5;
            building = new Building(buildingId, buildingName, buildingLevel);

            village.ChangeVillageData(2, building);
            Assert.AreEqual("Zid", village.GetBuildingsName(2));
            Assert.AreEqual(5, village.GetBuildingsLevel(2));
        }
    }
}

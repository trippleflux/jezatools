#region

using System;
using System.Collections.Generic;
using MbUnit.Framework;
using TW.Helper;

#endregion

namespace TW.Tests
{
    [TestFixture]
    public class Dorf1 : TestBase
    {
        [Test]
        public void Production()
        {
            GetBrowser("dorf1.html");
            gameData = new GameData();
            village = new Village(0, "00");
            dorf1Page = new Helper.Dorf1(Browser, gameData) { Village = village };
            dorf1Page.ParseProduction();
            Production production = gameData.GetProduction4Village(village);
            Assert.IsNotNull(production, "Production is null!");
            Assert.AreEqual(167, production.Wood);
            Assert.AreEqual(459, production.Clay);
            Assert.AreEqual(782, production.Iron);
            Assert.AreEqual(670, production.Crop);
            Assert.AreEqual(8, production.WoodPerHour);
            Assert.AreEqual(16, production.ClayPerHour);
            Assert.AreEqual(24, production.IronPerHour);
            Assert.AreEqual(-22, production.CropPerHour);
            Assert.AreEqual(2300, production.WarehouseCapacity);
            Assert.AreEqual(1200, production.GranaryCapacity);
        }

        [Test]
        public void TroopMovements()
        {
            GetBrowser("dorf1.html");
            gameData = new GameData();
            village = new Village(0, "00");
            dorf1Page = new Helper.Dorf1(Browser, gameData) { Village = village };
            dorf1Page.ParseTroopMovements();
            List<TroopMovements> troopMovements = gameData.GetTroopMovements4Village(village);
            Assert.AreEqual(1, troopMovements[0].Number);
            Assert.AreEqual(5, troopMovements[1].Number);
            Assert.AreEqual(3, troopMovements[2].Number);
            Assert.AreEqual(new TimeSpan(0, 3, 53), troopMovements[0].ArrivalTime);
            Assert.AreEqual(new TimeSpan(0, 3, 43), troopMovements[1].ArrivalTime);
            Assert.AreEqual(new TimeSpan(0, 2, 12), troopMovements[2].ArrivalTime);
            Assert.AreEqual(TroopMovementType.AttackIncoming, troopMovements[0].Type);
            Assert.AreEqual(TroopMovementType.ReinforcementIncomming, troopMovements[1].Type);
            Assert.AreEqual(TroopMovementType.AttackOutgoing, troopMovements[2].Type);
            Assert.AreEqual(new TimeSpan(0, 2, 12), dorf1Page.NextCheck);
            Assert.IsFalse(dorf1Page.RemoveTroops);
        }

        [Test]
        public void IncommingAttack()
        {
            GetBrowser("dorf1.attack.html");
            gameData = new GameData();
            village = new Village(0, "00");
            dorf1Page = new Helper.Dorf1(Browser, gameData)
                        {
                            Village = village,
                            RemoveTroopsTimeSpan = new TimeSpan(0, 1, 0),
                        };
            dorf1Page.ParseTroopMovements();
            List<TroopMovements> troopMovements = gameData.GetTroopMovements4Village(village);
            Assert.AreEqual(1, troopMovements[0].Number);
            Assert.AreEqual(5, troopMovements[1].Number);
            Assert.AreEqual(3, troopMovements[2].Number);
            Assert.AreEqual(new TimeSpan(0, 0, 53), troopMovements[0].ArrivalTime);
            Assert.AreEqual(new TimeSpan(0, 0, 44), troopMovements[1].ArrivalTime);
            Assert.AreEqual(new TimeSpan(0, 2, 12), troopMovements[2].ArrivalTime);
            Assert.AreEqual(TroopMovementType.AttackIncoming, troopMovements[0].Type);
            Assert.AreEqual(TroopMovementType.ReinforcementIncomming, troopMovements[1].Type);
            Assert.AreEqual(TroopMovementType.AttackOutgoing, troopMovements[2].Type);
            Assert.AreEqual(new TimeSpan(0, 0, 53), dorf1Page.NextCheck);
            Assert.IsTrue(dorf1Page.RemoveTroops);
        }

        [Test]
        public void IncommingAttack2()
        {
            GetBrowser("dorf1.attack.html");
            gameData = new GameData();
            village = new Village(0, "00");
            dorf1Page = new Helper.Dorf1(Browser, gameData)
            {
                Village = village,
                RemoveTroopsTimeSpan = new TimeSpan(0, 0, 27),
            };
            dorf1Page.ParseTroopMovements();
            List<TroopMovements> troopMovements = gameData.GetTroopMovements4Village(village);
            Assert.AreEqual(1, troopMovements[0].Number);
            Assert.AreEqual(5, troopMovements[1].Number);
            Assert.AreEqual(3, troopMovements[2].Number);
            Assert.AreEqual(new TimeSpan(0, 0, 53), troopMovements[0].ArrivalTime);
            Assert.AreEqual(new TimeSpan(0, 0, 44), troopMovements[1].ArrivalTime);
            Assert.AreEqual(new TimeSpan(0, 2, 12), troopMovements[2].ArrivalTime);
            Assert.AreEqual(TroopMovementType.AttackIncoming, troopMovements[0].Type);
            Assert.AreEqual(TroopMovementType.ReinforcementIncomming, troopMovements[1].Type);
            Assert.AreEqual(TroopMovementType.AttackOutgoing, troopMovements[2].Type);
            Assert.AreEqual(new TimeSpan(0, 0, 27), dorf1Page.NextCheck);
            Assert.IsFalse(dorf1Page.RemoveTroops);
        }

        [Test]
        public void IncommingAttack3()
        {
            GetBrowser("dorf1.attack.html");
            gameData = new GameData();
            village = new Village(0, "00");
            dorf1Page = new Helper.Dorf1(Browser, gameData)
            {
                Village = village,
                RemoveTroopsTimeSpan = new TimeSpan(0, 0, 53),
            };
            dorf1Page.ParseTroopMovements();
            List<TroopMovements> troopMovements = gameData.GetTroopMovements4Village(village);
            Assert.AreEqual(1, troopMovements[0].Number);
            Assert.AreEqual(5, troopMovements[1].Number);
            Assert.AreEqual(3, troopMovements[2].Number);
            Assert.AreEqual(new TimeSpan(0, 0, 53), troopMovements[0].ArrivalTime);
            Assert.AreEqual(new TimeSpan(0, 0, 44), troopMovements[1].ArrivalTime);
            Assert.AreEqual(new TimeSpan(0, 2, 12), troopMovements[2].ArrivalTime);
            Assert.AreEqual(TroopMovementType.AttackIncoming, troopMovements[0].Type);
            Assert.AreEqual(TroopMovementType.ReinforcementIncomming, troopMovements[1].Type);
            Assert.AreEqual(TroopMovementType.AttackOutgoing, troopMovements[2].Type);
            Assert.AreEqual(new TimeSpan(0, 0, 53), dorf1Page.NextCheck);
            Assert.AreEqual(53000, dorf1Page.NextCheck.TotalMilliseconds);
            Assert.IsTrue(dorf1Page.RemoveTroops);
        }

        private GameData gameData;
        private Village village;
        private Helper.Dorf1 dorf1Page;
    }
}
#region

using jeza.Travian.Framework;
using MbUnit.Framework;

#endregion

namespace jeza.Travian.Tests
{
    [TestFixture]
    public class TroopsTests
    {
        [Test]
        public void TroopMovements()
        {
            Troops troops = new Troops();
            TroopUnit unit = new TroopUnit();
            unit.AddName("Falanga").AddHtmlClassName("unit u11").AddTroopCount(123);
            troops.AddTroopUnit(unit);
            unit = new TroopUnit();
            unit.AddName("sekira").AddHtmlClassName("unit u12").AddTroopCount(1234);
            troops.AddTroopUnit(unit);
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
    }
}
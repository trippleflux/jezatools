using System;
using MbUnit.Framework;
using TW.Helper;

namespace TW.Tests
{
    [TestFixture]
    public class Units
    {
        [Test]
        public void GetTextBox()
        {
            Gauls gauls = new Gauls();
            Assert.AreEqual("t1", gauls.GetTextBoxName("Phalanx"));
            Assert.AreEqual("t6", gauls.GetTextBoxName("Haeduan"));
            Assert.AreEqual("t9", gauls.GetTextBoxName("unit u29"));
            Assert.AreEqual("t10", gauls.GetTextBoxName("Settler"));
            Console.WriteLine(gauls.UnitList());

            Romans romans = new Romans();
            Assert.AreEqual("t1", romans.GetTextBoxName("Phalanx"));
            Assert.AreEqual("t6", romans.GetTextBoxName("EquitesCaesaris"));
            Console.WriteLine(romans.UnitList());

            Teutons teutons = new Teutons();
            Assert.AreEqual("t1", teutons.GetTextBoxName("EquitesCaesaris"));
            Assert.AreEqual("t4", teutons.GetTextBoxName("Scout"));
            Console.WriteLine(teutons.UnitList());
        }
    }
}
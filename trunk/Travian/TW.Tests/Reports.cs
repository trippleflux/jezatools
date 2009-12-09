#region

using System;
using MbUnit.Framework;
using TW.Helper;

#endregion

namespace TW.Tests
{
    [TestFixture]
    public class Reports : TestBase
    {
        [Test]
        public void SaveReportPrisoners()
        {
            GetBrowser("berichte.prisoners.html");
            GameData gameData = new GameData();
            gameData.GameSettings("en-EN");
            ReportAttack reportAttack = new ReportAttack(Browser, gameData);
            Report report = new Report("url", "report text") {Date = DateTime.Now, Id = 123456, };
            reportAttack.ParseDate(report);
            reportAttack.ParseAttackerInfo(report);
            reportAttack.ParseDefenderInfo(report);
            reportAttack.AddReport(report);
            reportAttack.Save();
        }

        [Test]
        public void ParseDeletedReinforces()
        {
            GetBrowser("berichte.deleted.nature.html");
            GameData gameData = new GameData();
            gameData.GameSettings("en-EN");
            ReportAttack reportAttack = new ReportAttack(Browser, gameData);
            Report report = new Report("1", "asds");
            reportAttack.ParseAttackerInfo(report);
            Assert.AreEqual(47554, report.AttackerId);
            Assert.AreEqual("strauss", report.AttackerName);
            Assert.AreEqual(347827, report.AttackerVillageId);
            Assert.AreEqual("01", report.AttackerVillageName);
            Assert.AreEqual(Tribes.Teutons, report.TribeAttacker);
            reportAttack.ParseDefenderInfo(report);
            Assert.AreEqual(49903, report.DefenderId);
            Assert.AreEqual("Nature", report.DefenderName);
            Assert.AreEqual(0, report.DefenderVillageId);
            Assert.AreEqual("[?]", report.DefenderVillageName);
            Assert.AreEqual(Tribes.Nature, report.TribeDefender);
        }

        [Test]
        public void ParseDeleted()
        {
            GetBrowser("berichte.deleted.html");
            GameData gameData = new GameData();
            gameData.GameSettings("en-EN");
            ReportAttack reportAttack = new ReportAttack(Browser, gameData);
            Report report = new Report("1", "asds");
            reportAttack.ParseAttackerInfo(report);
            Assert.AreEqual(47554, report.AttackerId);
            Assert.AreEqual("strauss", report.AttackerName);
            Assert.AreEqual(347827, report.AttackerVillageId);
            Assert.AreEqual("01", report.AttackerVillageName);
            Assert.AreEqual(Tribes.Teutons, report.TribeAttacker);
            reportAttack.ParseDefenderInfo(report);
            Assert.AreEqual(0, report.DefenderId);
            Assert.AreEqual("???", report.DefenderName);
            Assert.AreEqual(0, report.DefenderVillageId);
            Assert.AreEqual("???", report.DefenderVillageName);
            Assert.AreEqual(Tribes.Romans, report.TribeDefender);
        }

        [Test]
        public void ParsePrisoners()
        {
            GetBrowser("berichte.prisoners.html");
            GameData gameData = new GameData();
            gameData.GameSettings("en-EN");
            ReportAttack reportAttack = new ReportAttack(Browser, gameData);
            Report report = new Report("1", "asds");
            reportAttack.ParseAttackerInfo(report);
            Assert.AreEqual(12465, report.AttackerId);
            Assert.AreEqual("jeza", report.AttackerName);
            Assert.AreEqual(398445, report.AttackerVillageId);
            Assert.AreEqual("00", report.AttackerVillageName);
            Assert.AreEqual(Tribes.Teutons, report.TribeAttacker);
            Assert.AreEqual(10, report.Troops[0]);
            Assert.AreEqual(0, report.Casualties[0]);
            Assert.AreEqual(3, report.Prisoners[0]);
            Assert.AreEqual(0, report.Goods[0]);
        }

        [Test]
        public void ParseAttacker()
        {
            GetBrowser("berichte.reinforcement.html");
            GameData gameData = new GameData();
            gameData.GameSettings("sl-SI");
            ReportAttack reportAttack = new ReportAttack(Browser, gameData);
            Report report = new Report("1", "asds");
            reportAttack.ParseAttackerInfo(report);
            Assert.AreEqual(1445, report.AttackerId);
            Assert.AreEqual("Ukrajinec", report.AttackerName);
            Assert.AreEqual(304805, report.AttackerVillageId);
            Assert.AreEqual("U.", report.AttackerVillageName);
            Assert.AreEqual(Tribes.Romans, report.TribeAttacker);
            Assert.AreEqual(4620, report.Troops[2]);
            Assert.AreEqual(4620, report.Casualties[2]);
            Assert.AreEqual(0, report.Goods[2]);
        }

        [Test]
        public void ParseDefender()
        {
            GetBrowser("berichte.reinforcement.html");
            GameData gameData = new GameData();
            gameData.GameSettings("sl-SI");
            ReportAttack reportAttack = new ReportAttack(Browser, gameData);
            Report report = new Report("1", "asds");
            reportAttack.ParseDefenderInfo(report);
            Assert.AreEqual(1782, report.DefenderId);
            Assert.AreEqual("Cleaner", report.DefenderName);
            Assert.AreEqual(280730, report.DefenderVillageId);
            Assert.AreEqual("WW Vasica", report.DefenderVillageName);
            Assert.AreEqual(Tribes.Teutons, report.TribeDefender);
            Assert.AreEqual(236057, report.TroopsDefender[1]);
            Assert.AreEqual(472, report.CasualtiesDefender[1]);
            Assert.AreEqual(14552, report.TroopsDefender[4]);
            Assert.AreEqual(29, report.CasualtiesDefender[4]);
            Assert.AreEqual(13, report.TroopsDefender[10]);
            Assert.AreEqual(0, report.CasualtiesDefender[10]);
        }

        [Test]
        public void ParseDefenderUnknown()
        {
            GetBrowser("berichte.unknown.html");
            GameData gameData = new GameData();
            gameData.GameSettings("sl-SI");
            ReportAttack reportAttack = new ReportAttack(Browser, gameData);
            Report report = new Report("1", "asds");
            reportAttack.ParseDefenderInfo(report);
            Assert.AreEqual(9188, report.DefenderId);
            Assert.AreEqual("ROZLE", report.DefenderName);
            Assert.AreEqual(341581, report.DefenderVillageId);
            Assert.AreEqual("ηєω ωιѕ∂σм", report.DefenderVillageName);
            Assert.AreEqual(Tribes.Teutons, report.TribeDefender);
            Assert.AreEqual(0, report.TroopsDefender[1]);
            Assert.AreEqual(0, report.CasualtiesDefender[1]);
        }

        [Test]
        public void ParseReport()
        {
            GetBrowser("berichte.raid.html");
            GameData gameData = new GameData();
            gameData.GameSettings("en-EN");
            ReportAttack reportAttack = new ReportAttack(Browser, gameData);
            Report report = new Report("1", "asds");
            reportAttack.ParseAttackerInfo(report);
            Assert.AreEqual(14837, report.AttackerId);
            Assert.AreEqual("zenix", report.AttackerName);
            Assert.AreEqual(412073, report.AttackerVillageId);
            Assert.AreEqual("[S&D] Cthol mishrak", report.AttackerVillageName);
            Assert.AreEqual(Tribes.Teutons, report.TribeAttacker);
            Assert.AreEqual(3, report.Troops[4]);
            Assert.AreEqual(0, report.Casualties[0]);
            Assert.AreEqual(0, report.Goods[0]);
            Assert.AreEqual(21, report.Goods[1]);
            Assert.AreEqual(0, report.Goods[2]);
            Assert.AreEqual(0, report.Goods[3]);
            reportAttack.ParseDefenderInfo(report);
            Assert.AreEqual(12465, report.DefenderId);
            Assert.AreEqual("jeza", report.DefenderName);
            Assert.AreEqual(398445, report.DefenderVillageId);
            Assert.AreEqual("00", report.DefenderVillageName);
            Assert.AreEqual(Tribes.Teutons, report.TribeDefender);
            Assert.AreEqual(3, report.TroopsDefender[1]);
            Assert.AreEqual(2, report.CasualtiesDefender[1]);
        }
    }
}
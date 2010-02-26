#region

using jeza.Travian.Framework;
using MbUnit.Framework;

#endregion

namespace jeza.Travian.Tests
{
    [TestFixture]
    public class AccountTests
    {
        /// <summary>
        /// Test if account is properly set with data.
        /// </summary>
        [Test]
        public void Account()
        {
            Account account = new Account();
            const string accountName = "kekec";
            const int accountId = 123;
            const Tribes accountTribe = Tribes.Gauls;
            account.AddName(accountName).AddId(accountId).AddTribe(accountTribe);
            Assert.IsNotNull(account, "Account is null!");
            Assert.AreEqual(accountName, account.Name);
            Assert.AreEqual(accountId, account.Id);
            Assert.AreEqual(accountTribe, account.Tribe);

            Village firstVillage = new Village();
            const int firstVillageId = 0;
            const string firstVillageName = "01";
            firstVillage.AddId(firstVillageId).AddName(firstVillageName);
            account.AddVillage(firstVillage);
            Assert.IsNotNull(account.Villages, "Village list!");
            Assert.AreEqual(1, account.Villages.Count, "Village list count!");
            Assert.AreEqual(firstVillageId, account.Villages[0].Id, "Village id!");
            Assert.AreEqual(firstVillageName, account.Villages[0].Name, "Village name!");

            Village secondVillage = new Village();
            const int secondVillageId = 1324;
            const string secondVillageName = "02";
            secondVillage.AddId(secondVillageId).AddName(secondVillageName);
            Production production = new Production();
            production
                .UpdateWarehouse(3100)
                .UpdateGranary(4000)
                .UpdateTotals(132, 213, 11, 223)
                .UpdatePerHour(100, 200, 300, 400);
            secondVillage.UpdateProduction(production);
            account.AddVillage(secondVillage);

            Assert.AreEqual(2, account.Villages.Count, "Village list count!");

            Village firstAccountVillage = account.GetVillage(firstVillageId);
            Assert.IsNotNull(firstAccountVillage, "Village not found!");
            Assert.AreEqual(firstVillageId, firstAccountVillage.Id, "Village id!");
            Assert.AreEqual(firstVillageName, firstAccountVillage.Name, "Village name!");
            Assert.IsNull(firstAccountVillage.Production, "Village production!");
            Assert.IsNull(firstAccountVillage.TroopsAvailable, "Village troops!");

            Village secondAccountVillage = account.GetVillage(secondVillageId);
            Assert.IsNotNull(secondAccountVillage, "Village not found!");
            Assert.AreEqual(secondVillageId, secondAccountVillage.Id, "Village id!");
            Assert.AreEqual(secondVillageName, secondAccountVillage.Name, "Village name!");
            Assert.AreEqual(production, secondAccountVillage.Production, "Village production!");
            Assert.IsNull(secondAccountVillage.TroopsAvailable, "Village troops!");

            Gauls gauls = new Gauls();
            TroopUnit phalanx = gauls.Phalanx.AddTroopCount(123);
            TroopUnit haeduan = gauls.Haeduan.AddTroopCount(13);
            Romans romans = new Romans();
            TroopUnit legionnaire = romans.Legionnaire.AddTroopCount(2222);
            TroopUnit praetorian = romans.Praetorian.AddTroopCount(45632);
            Teutons teutons = new Teutons();
            TroopUnit spearman = teutons.Spearman.AddTroopCount(5123);
            Troops troops = new Troops();
            troops
                .AddTroopUnit(phalanx).AddTroopUnit(haeduan)
                .AddTroopUnit(legionnaire).AddTroopUnit(praetorian)
                .AddTroopUnit(spearman);
            secondAccountVillage.UpdateTroopsInVillage(troops);
            Assert.IsNull(firstAccountVillage.TroopsAvailable, "Village troops!"); 
            Assert.IsNotNull(secondAccountVillage.TroopsAvailable, "Village troops!");
            Assert.AreEqual(13, secondAccountVillage.TroopsAvailable.GetTroopCount("unit u26"), "Haeduan count!");
        }
    }
}
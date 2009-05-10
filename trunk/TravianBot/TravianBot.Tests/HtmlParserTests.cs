using NUnit.Framework;
using TravianBot.Framework;

namespace TravianBot.Tests
{
    [TestFixture]
    public class HtmlParserTests
    {
        [Test]
        public void ParseAttackRang()
        {
            string pageSource = Misc.ReadContent("..\\..\\..\\Samples\\TestFiles\\statistiken.attack.php");
            HtmlParser htmlParser = new HtmlParser(pageSource);
            PlayerData playerData = new PlayerData();
            htmlParser.ParseAttackRang(playerData, "jeza");
            Assert.AreEqual("jeza", playerData.Name);
            Assert.AreEqual(18145, playerData.AttackPoints);
            Assert.AreEqual(23, playerData.AttackRang);
            Assert.AreEqual(2242, playerData.Population);
            Assert.AreEqual(4, playerData.VillageCount);
        }

        [Test]
        public void Merchants()
        {
            string pageSource = Misc.ReadContent("..\\..\\..\\Samples\\TestFiles\\build.php-newdid=73913-gid=17");
            HtmlParser htmlParser = new HtmlParser(pageSource);
            Marketplace marketplace = new Marketplace();
            const int villageId = 73913;
            marketplace.VillageId = villageId;
            htmlParser.ParseMarketplace(marketplace);
            Assert.AreEqual(13, marketplace.AvailableMerchants);
            Assert.AreEqual(20, marketplace.TotalMerchants);
            Assert.AreEqual(2000, marketplace.TotalCarry);
            Village village = new Village(villageId, "some name");
            htmlParser.ParseVillageProduction(village);
            Assert.AreEqual(6911, village.WoodAvailable);
            Assert.AreEqual(1000, village.WoodProduction);
            Assert.AreEqual(5059, village.ClayAvailable);
            Assert.AreEqual(1000, village.ClayProduction);
            Assert.AreEqual(1987, village.IronAvailable);
            Assert.AreEqual(1200, village.IronProduction);
            Assert.AreEqual(19258, village.CropAvailable);
            Assert.AreEqual(121, village.CropProduction);
            Assert.AreEqual(80000, village.CapacityWarehouse);
            Assert.AreEqual(80000, village.CapacityGranary);
        }
    }
}
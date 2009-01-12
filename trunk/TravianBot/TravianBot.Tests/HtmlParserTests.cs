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
    }
}
using System.IO;
using MbUnit.Framework;
using TravianPlayer.Framework;

namespace TravianPlayer.Tests
{
    [TestFixture]
    public class HtmlParserTests
    {
        [Test]
        public void LoginInfo()
        {
            string pageSource = File.ReadAllText(@"TestFiles\login.php");
            HtmlParser htmlParser = new HtmlParser(pageSource);
            Game gameData = htmlParser.ParseLoginData();
            LoginInfo li = gameData.GetLoginData();
            Assert.AreEqual("e96a122", li.TextBoxUserame);
            Assert.AreEqual("e56e857", li.TextBoxPassword);
        }
    }
}
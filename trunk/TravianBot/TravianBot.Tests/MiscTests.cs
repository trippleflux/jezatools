using System.IO;
using NUnit.Framework;
using TravianBot.Framework;

namespace TravianBot.Tests
{
    [TestFixture]
    public class MiscTests
    {
        [Test]
        public void IsCharNumber()
        {
            Assert.IsFalse(Misc.IsNumber('a'));
            Assert.IsTrue(Misc.IsNumber('1'));
        }

        [Test]
        public void IsStringNumber()
        {
            Assert.IsFalse(Misc.IsNumber("asd"));
            Assert.IsFalse(Misc.IsNumber("asd111"));
            Assert.IsTrue(Misc.IsNumber("123"));
        }

        [Test]
        public void ReadContent()
        {
            string pageSource = Misc.ReadContent(@"..\..\..\TestFiles\berichte.php");
            Assert.IsNotNull(pageSource);
        }

        [Test]
        [ExpectedException(typeof (FileNotFoundException))]
        public void FileNotFound()
        {
            const string fileName = "nema.txt";
            Misc.ReadContent(fileName);
        }

        [Test]
        public void ReadConfigValue()
        {
            string configValue = Misc.GetConfigValue("serverName");
            Assert.IsNotNull(configValue);
        }

        [Test]
        public void ConfigValueNotFound()
        {
            string configValue = Misc.GetConfigValue("beeeeee");
            Assert.IsNull(configValue);
        }
    }
}
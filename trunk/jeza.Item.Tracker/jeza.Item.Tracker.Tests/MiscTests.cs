using System.Collections.Generic;
using jeza.Item.Tracker.Settings;
using NUnit.Framework;

namespace jeza.Item.Tracker.Tests
{
    [TestFixture]
    public class MiscTests
    {
        [Test]
        public void SerializeSettings()
        {
            Settings.Settings settings = new Settings.Settings
                                         {
                                             Languages = new List<Language> {Misc.GetLanguageSlovenian()},
                                         };
            XmlSerialization xmlSerialization = new XmlSerialization();
            xmlSerialization.Serialize(settings, FileName);
        }

        [Test]
        public void DeserializeSettings()
        {
            XmlSerialization xmlSerialization = new XmlSerialization();
            Settings.Settings settings = xmlSerialization.Deserialize(new Settings.Settings(), FileName);
            Assert.IsNotNull(settings);
        }

        [Test]
        public void String2Decimal()
        {
            Assert.AreEqual(0M, "0".String2Decimal());
            Assert.AreEqual(0M, "0.0".String2Decimal());
            Assert.AreEqual(0.1M, "0,1".String2Decimal());
            Assert.AreEqual(0.1M, "0.1".String2Decimal());
            Assert.AreEqual(0.123M, "0,123".String2Decimal());
            Assert.AreEqual(0.123M, "0.123".String2Decimal());
            Assert.AreEqual(10.123M, "10.123".String2Decimal());
            Assert.AreEqual(10.123M, "10,123".String2Decimal());
        }

        [Test]
        public void DecimalToString()
        {
            Assert.AreEqual("0.000", 0M.DecimalToString());
            Assert.AreEqual("0.123", 0.123M.DecimalToString());
            Assert.AreEqual("1.000", 1M.DecimalToString());
            Assert.AreEqual("1.000", 1.00M.DecimalToString());
            Assert.AreEqual("1.234", 1.234M.DecimalToString());
            Assert.AreEqual("1000.000", 1000.000M.DecimalToString());
            Assert.AreEqual("1.000", 1.0M.DecimalToString());
        }

        private const string FileName = "..\\..\\..\\settings.xml";
    }
}
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
            Assert.AreEqual(0M, Misc.String2Decimal("0"));
            Assert.AreEqual(0M, Misc.String2Decimal("0.0"));
            Assert.AreEqual(0.1M, Misc.String2Decimal("0,1"));
            Assert.AreEqual(0.1M, Misc.String2Decimal("0.1"));
            Assert.AreEqual(0.123M, Misc.String2Decimal("0,123"));
            Assert.AreEqual(0.123M, Misc.String2Decimal("0.123"));
            Assert.AreEqual(10.123M, Misc.String2Decimal("10.123"));
            Assert.AreEqual(10.123M, Misc.String2Decimal("10,123"));
        }

        private const string FileName = "..\\..\\..\\settings.xml";
    }
}
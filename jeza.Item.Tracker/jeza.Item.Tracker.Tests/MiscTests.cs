using System.Collections.Generic;
using NUnit.Framework;

namespace jeza.Item.Tracker.Tests
{
    [TestFixture]
    public class MiscTests
    {
        [Test]
        public void SerializeSettings()
        {
            Settings settings = new Settings
                                    {
                                        Languages = new List<Language> {Misc.GetLanguageSlovenian()},
                                    };
            Misc.Serialize(settings, FileName);
        }

        [Test]
        public void DeserializeSettings()
        {
            Settings settings = Misc.Deserialize(new Settings(), FileName);
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
        }

        private const string FileName = "..\\..\\..\\..\\..\\..\\settings.xml";
    }
}
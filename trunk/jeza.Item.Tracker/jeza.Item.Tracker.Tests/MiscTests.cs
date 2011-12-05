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

        private const string FileName = "..\\..\\..\\..\\..\\..\\settings.xml";
    }
}
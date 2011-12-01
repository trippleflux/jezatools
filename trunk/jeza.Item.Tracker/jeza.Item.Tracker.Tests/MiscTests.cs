using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace jeza.Item.Tracker.Tests
{
    [TestClass]
    public class MiscTests
    {
        [TestMethod]
        public void SerializeSettings()
        {
            Settings settings = new Settings
                                    {
                                        Languages = new List<Language> {Misc.GetLanguageSlovenian()},
                                    };
            Misc.Serialize(settings, FileName);
        }

        [TestMethod]
        public void DeserializeSettings()
        {
            Settings settings = Misc.Deserialize(new Settings(), FileName);
            Assert.IsNotNull(settings);
        }

        private const string FileName = "..\\..\\..\\..\\..\\..\\settings.xml";
    }
}
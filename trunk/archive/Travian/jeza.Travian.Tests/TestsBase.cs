using System.IO;
using System.Xml.Serialization;
using jeza.Travian.Framework;

namespace jeza.Travian.Tests
{
    public class TestsBase
    {
        protected Languages Languages = new Languages();

        protected void DeserializeLanguage()
        {
            using (FileStream fileStream = new FileStream("Language.xml", FileMode.Open))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Languages));
                Languages = (Languages)xmlSerializer.Deserialize(fileStream);
            }
        }
    }
}
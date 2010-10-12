using System.Xml.Serialization;

namespace jeza.Travian.Framework
{
    [XmlRoot("languages", IsNullable = false)]
    public class Languages
    {
        [XmlElement(ElementName = "language")]
        public Language[] Language { get; set; }

        public Language GetLanguage(string languageId)
        {
            foreach (Language language in Language)
            {
                if (language.Id.Equals(languageId))
                {
                    return language;
                }
            }
            return null;
        }
    }

    public class Language
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlElement(ElementName = "rallyPoint")]
        public RallyPoint RallyPoint { get; set; }

        [XmlElement(ElementName = "marketPlace")]
        public MarketPlaceSet MarketPlace { get; set; }
    }

    public class MarketPlaceSet
    {
        [XmlElement(ElementName = "TotalCarry")]
        public string TotalCarry { get; set; }

        [XmlElement(ElementName = "IncommingTransport")]
        public string IncommingTransport { get; set; }
    }

    public class RallyPoint
    {
        [XmlElement(ElementName = "AttackOut")]
        public string AttackOut { get; set; }

        [XmlElement(ElementName = "AttackIn")]
        public string AttackIn { get; set; }

        [XmlElement(ElementName = "RaidOut")]
        public string RaidOut { get; set; }

        [XmlElement(ElementName = "RaidIn")]
        public string RaidIn { get; set; }

        [XmlElement(ElementName = "ReinforcementIn")]
        public string ReinforcementIn { get; set; }

        [XmlElement(ElementName = "ReinforcementBack")]
        public string ReinforcementBack { get; set; }

        [XmlElement(ElementName = "ReinforcementOut")]
        public string ReinforcementOut { get; set; }

        [XmlElement(ElementName = "Scout")]
        public string Scout { get; set; }
    }
}
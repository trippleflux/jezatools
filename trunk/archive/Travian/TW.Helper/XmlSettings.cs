using System.Xml.Serialization;

namespace TW.Helper
{
    [XmlRoot(ElementName = "settings")]
    public class XmlSettings
    {
        [XmlElement(ElementName = "language")]
        public Settings[] Language { get; set; }

        [XmlIgnore]
        public bool LanguageSpecified { get; set; }
    }

    public class Settings
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlIgnore]
        public bool IdSpecified { get; set; }

        [XmlElement(ElementName = "reports")]
        public XmlReports Reports { get; set; }

        [XmlIgnore]
        public bool ReportsSpecified { get; set; }
    }

    public class XmlReports
    {
        [XmlElement(ElementName = "rowAttackerTroops")]
        public string RowAttackerTroops { get; set; }

        [XmlIgnore]
        public bool RowAttackerTroopsSpecified{ get; set;}

        [XmlElement(ElementName = "rowAttackerCasualties")]
        public string RowAttackerCasualties { get; set; }

        [XmlIgnore]
        public bool RowAttackerCasualtiesSpecified { get; set; }

        [XmlElement(ElementName = "rowAttackerPrisoners")]
        public string RowAttackerPrisoners { get; set; }

        [XmlIgnore]
        public bool RowAttackerPrisonersSpecified { get; set; }

        [XmlElement(ElementName = "rowAttackerInformation")]
        public string RowAttackerInformation { get; set; }

        [XmlIgnore]
        public bool RowAttackerInformationSpecified { get; set; }

        [XmlElement(ElementName = "rowAttackerBounty")]
        public string RowAttackerBounty { get; set; }

        [XmlIgnore]
        public bool RowAttackerBountySpecified { get; set; }

        [XmlElement(ElementName = "rowDefenderTroops")]
        public string RowDefenderTroops { get; set; }

        [XmlIgnore]
        public bool RowDefenderTroopsSpecified { get; set; }

        [XmlElement(ElementName = "rowDefenderCasualties")]
        public string RowDefenderCasualties { get; set; }

        [XmlIgnore]
        public bool RowDefenderCasualtiesSpecified { get; set; }

        [XmlElement(ElementName = "nameOfCurrentDay")]
        public string NameOfCurrentDay { get; set; }

        [XmlIgnore]
        public bool NameOfCurrentDaySpecified { get; set; }

        [XmlElement(ElementName = "nameOfPreviousDay")]
        public string NameOfPreviousDay { get; set; }

        [XmlIgnore]
        public bool NameOfPreviousDaySpecified { get; set; }
    }
}
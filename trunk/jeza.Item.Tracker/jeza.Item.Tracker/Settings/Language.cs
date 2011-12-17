using System.Xml.Serialization;

namespace jeza.Item.Tracker.Settings
{
    public class Language
    {
        [XmlAttribute]
        public string Culture { get; set; }

        [XmlElement]
        public TabOrders TabOrders { get; set; }

        [XmlElement]
        public TabItems TabItems { get; set; }

        [XmlElement]
        public TabItemTypes TabItemTypes { get; set; }

        [XmlElement]
        public TabItemStatus TabItemStatus { get; set; }

        [XmlElement]
        public TabPersonInfo TabPersonInfo { get; set; }

        [XmlElement]
        public TabReports TabReports { get; set; }

        [XmlElement]
        public TabBank TabBank { get; set; }
    }
}
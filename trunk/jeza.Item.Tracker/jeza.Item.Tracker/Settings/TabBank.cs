using System.Xml.Serialization;

namespace jeza.Item.Tracker.Settings
{
    public class TabBank
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlElement]
        public string GroupBoxItemsStatus { get; set; }

        [XmlElement]
        public string LabelItemsStatusName { get; set; }

        [XmlElement]
        public string LabelItemStatusDescription { get; set; }

        [XmlElement]
        public string LabelItemStatusList { get; set; }

        [XmlElement]
        public string ButtonItemStatusSelect { get; set; }

        [XmlElement]
        public string ButtonItemStatusSave { get; set; }

        [XmlElement]
        public string ButtonItemStatusNew { get; set; }

        [XmlElement]
        public string ButtonItemStatusUpdate { get; set; }

        [XmlElement]
        public string ButtonItemStatusDelete { get; set; }
    }
}
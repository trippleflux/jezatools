using System.Xml.Serialization;

namespace jeza.Item.Tracker.Settings
{
    public class TabItemTypes
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlElement]
        public string GroupBoxItemType { get; set; }

        [XmlElement]
        public string LabelItemTypeName { get; set; }

        [XmlElement]
        public string LabelItemTypeDescription { get; set; }

        [XmlElement]
        public string LabelItemTypeList { get; set; }

        [XmlElement]
        public string ButtonItemTypeListSelect { get; set; }

        [XmlElement]
        public string ButtonItemTypeListSave { get; set; }

        [XmlElement]
        public string ButtonItemTypeListNew { get; set; }

        [XmlElement]
        public string ButtonItemTypeListUpdate { get; set; }

        [XmlElement]
        public string ButtonItemTypeListDelete { get; set; }
    }
}
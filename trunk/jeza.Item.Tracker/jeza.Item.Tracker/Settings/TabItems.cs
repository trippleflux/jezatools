using System.Xml.Serialization;

namespace jeza.Item.Tracker.Settings
{
    public class TabItems
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlElement]
        public string GroupBoxItems { get; set; }

        [XmlElement]
        public string LabelItemsName { get; set; }

        [XmlElement]
        public string LabelItemsDescription { get; set; }

        [XmlElement]
        public string LabelItemsType { get; set; }

        [XmlElement]
        public string LabelItemsImage { get; set; }

        [XmlElement]
        public string LabelItemsList { get; set; }

        [XmlElement]
        public string ButtonItemsPictureBoxSelect { get; set; }

        [XmlElement]
        public string ButtonItemsSelect { get; set; }

        [XmlElement]
        public string ButtonItemsSave { get; set; }

        [XmlElement]
        public string ButtonItemsNew { get; set; }

        [XmlElement]
        public string ButtonItemsUpdate { get; set; }

        [XmlElement]
        public string ButtonItemsDelete { get; set; }
    }
}
using System.Xml.Serialization;

namespace jeza.Item.Tracker.Settings
{
    public class TabOrders
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlElement]
        public string LabelOrdersPersonInfo { get; set; }

        [XmlElement]
        public string LabelOrdersItemType { get; set; }

        [XmlElement]
        public string LabelOrdersItem { get; set; }

        [XmlElement]
        public string LabelOrdersItemStatus { get; set; }

        [XmlElement]
        public string LabelOrdersItemCount { get; set; }

        [XmlElement]
        public string LabelOrdersPrice { get; set; }

        [XmlElement]
        public string LabelOrdersTax { get; set; }

        [XmlElement]
        public string LabelOrdersPostage { get; set; }

        [XmlElement]
        public string LabelOrdersLegalEntity { get; set; }

        [XmlElement]
        public string LabelOrdersPicture { get; set; }

        [XmlElement]
        public string LabelOrdersList { get; set; }

        [XmlElement]
        public string ButtonOrdersSum { get; set; }

        [XmlElement]
        public string ButtonOrdersSelect { get; set; }

        [XmlElement]
        public string ButtonOrdersSave { get; set; }

        [XmlElement]
        public string ButtonOrdersNew { get; set; }

        [XmlElement]
        public string ButtonOrdersUpdate { get; set; }

        [XmlElement]
        public string ButtonOrdersDelete { get; set; }
    }
}
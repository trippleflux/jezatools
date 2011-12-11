using System.Xml.Serialization;

namespace jeza.Item.Tracker.Settings
{
    public class TabPersonInfo
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlElement]
        public string LabelPersonInfoName { get; set; }

        [XmlElement]
        public string LabelPersonInfoSurName { get; set; }

        [XmlElement]
        public string LabelPersonInfoNickName { get; set; }

        [XmlElement]
        public string LabelPersonInfoDescription { get; set; }

        [XmlElement]
        public string LabelPersonInfoAddress { get; set; }

        [XmlElement]
        public string LabelPersonInfoCity { get; set; }

        [XmlElement]
        public string LabelPersonInfoPostNumber { get; set; }

        [XmlElement]
        public string LabelPersonInfoEmail { get; set; }

        [XmlElement]
        public string LabelPersonInfoTelephone { get; set; }

        [XmlElement]
        public string LabelPersonInfoTelephoneMobile { get; set; }

        [XmlElement]
        public string LabelPersonInfoFax { get; set; }

        [XmlElement]
        public string LabelPersonInfoList { get; set; }

        [XmlElement]
        public string ButtonPersonInfoSelect { get; set; }

        [XmlElement]
        public string ButtonPersonInfoSave { get; set; }

        [XmlElement]
        public string ButtonPersonInfoNew { get; set; }

        [XmlElement]
        public string ButtonPersonInfoUpdate { get; set; }

        [XmlElement]
        public string ButtonPersonInfoDelete { get; set; }
    }
}
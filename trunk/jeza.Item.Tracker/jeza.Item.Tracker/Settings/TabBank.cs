using System.Xml.Serialization;

namespace jeza.Item.Tracker.Settings
{
    public class TabBank
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlElement]
        public string GroupBoxBank { get; set; }

        [XmlElement]
        public string LabelBankName { get; set; }

        [XmlElement]
        public string LabelBankOwner { get; set; }

        [XmlElement]
        public string LabelBankAccountNumber { get; set; }

        [XmlElement]
        public string LabelBankList { get; set; }

        [XmlElement]
        public string ButtonBankSave { get; set; }

        [XmlElement]
        public string ButtonBankNew { get; set; }

        [XmlElement]
        public string ButtonBankUpdate { get; set; }

        [XmlElement]
        public string ButtonBankDelete { get; set; }
    }
}
using System.Collections.Generic;
using System.Xml.Serialization;

namespace jeza.Travian.Framework
{
    public class ValleyTypeList
    {
        [XmlElement(ElementName = "valleyItem")]
        public List<ValleyItem> Items { get; set; }
    }

    public class ValleyItem
    {
        [XmlAttribute(AttributeName = "villageId")]
        public int VillageId { get; set; }

        [XmlAttribute(AttributeName = "valleyType")]
        public ValleyType ValleyType { get; set; }

        [XmlAttribute(AttributeName = "valleyNotes")]
        public string ValleyNotes { get; set; }
    }
}
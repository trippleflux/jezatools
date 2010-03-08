using System.Xml.Serialization;

namespace jeza.Travian.Framework
{
    public class ValleyTypeList
    {
        [XmlElement(ElementName = "valleyItem")]
        public ValleyItem[] Item { get; set; }
    }

    public class ValleyItem
    {
        [XmlElement(ElementName = "villageId")]
        public string VillageId { get; set; }

        [XmlElement(ElementName = "valleyType")]
        public ValleyType ValleyType { get; set; }
    }
}
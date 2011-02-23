using System.Xml.Serialization;

namespace jeza.ioFTPD.Framework
{
    [XmlRoot(ElementName = "task")]
    public class ArchiveTask
    {
        [XmlElement(ElementName = "actionType")]
        public ArchiveType ArchiveType { get; set; }

        [XmlElement(ElementName = "status")]
        public ArchiveStatus ArchiveStatus { get; set; }

        [XmlElement(ElementName = "source")]
        public string Source { get; set; }

        [XmlElement(ElementName = "destination")]
        public string Destination { get; set; }
    }
}
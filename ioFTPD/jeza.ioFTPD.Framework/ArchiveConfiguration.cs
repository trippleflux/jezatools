using System.Xml.Serialization;

namespace jeza.ioFTPD.Framework
{
    [XmlRoot("tasks", IsNullable = false)]
    public class ArchiveConfiguration
    {
        [XmlElement(ElementName = "task")]
        public ArchiveTask[] ArchiveTasks { get; set; }
    }
}
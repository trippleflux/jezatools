using System.Xml.Serialization;

namespace jeza.ioFTPD.Framework.Archive
{
    [XmlRoot(Constants.XmlRootElementForConfiguration, IsNullable = false)]
    public class ArchiveConfiguration
    {
        [XmlElement(ElementName = Constants.XmlElementNameArchiveTask)]
        public ArchiveTask[] ArchiveTasks { get; set; }
    }
}
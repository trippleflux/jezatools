using System.Xml.Serialization;
using jeza.ioFTPD.Framework.Archive;
using jeza.ioFTPD.Framework.Manager;

namespace jeza.ioFTPD.Framework
{
    [XmlRoot(Constants.XmlRootElementForConfiguration, IsNullable = false)]
    public class TaskConfiguration
    {
        [XmlElement(ElementName = Constants.XmlElementNameArchiveTask)]
        public ArchiveTask[] ArchiveTasks { get; set; }

        [XmlElement(ElementName = Constants.XmlElementNameWeeklyTask)]
        public WeeklyTask[] WeeklyTasks { get; set; }

        [XmlElement(ElementName = Constants.XmlElementNameNewDayTask)]
        public NewDayTask[] NewDayTasks { get; set; }
    }
}
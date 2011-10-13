using System.Xml.Serialization;

namespace jeza.ioFTPD.Framework.Manager
{
    [XmlRoot(Constants.XmlRootElementForConfiguration, IsNullable = false)]
    public class ManagerConfiguration
    {
        [XmlElement(ElementName = Constants.XmlElementNameWeeklyTask)]
        public WeeklyTask[] WeeklyTask { get; set; }

        [XmlElement(ElementName = Constants.XmlElementNameNewDayTask)]
        public NewDayTask[] NewDayTask { get; set; }
    }
}

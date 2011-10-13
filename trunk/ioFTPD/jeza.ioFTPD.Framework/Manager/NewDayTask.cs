using System.Xml.Serialization;

namespace jeza.ioFTPD.Framework.Manager
{
    public class NewDayTask
    {
        [XmlElement(ElementName = Constants.XmlElementNameNewDayTaskStatus, IsNullable = false)]
        public NewDayTaskStatus WeeklyTaskStatus { get; set; }

        [XmlElement(ElementName = Constants.XmlElementNameNewDayTaskType)]
        public NewDayTaskType WeeklyTaskType { get; set; }

        [XmlElement(ElementName = Constants.XmlElementNameNewDayTaskPath)]
        public string Path { get; set; }

        [XmlElement(ElementName = Constants.XmlElementNameNewDayTaskFolderFormat)]
        public string FolderFormat { get; set; }

        [XmlElement(ElementName = Constants.XmlElementNameNewDayTaskSymlink)]
        public string Symlink { get; set; }

        [XmlElement(ElementName = Constants.XmlElementNameNewDayTaskMode)]
        public int Mode { get; set; }

        [XmlElement(ElementName = Constants.XmlElementNameNewDayTaskUserId)]
        public int UserId { get; set; }

        [XmlElement(ElementName = Constants.XmlElementNameNewDayTaskGroupId)]
        public int GroupId { get; set; }
    }
}
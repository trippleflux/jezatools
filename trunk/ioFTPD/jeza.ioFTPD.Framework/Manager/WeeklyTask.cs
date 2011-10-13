using System;
using System.Xml.Serialization;

namespace jeza.ioFTPD.Framework.Manager
{
    public class WeeklyTask
    {
        [XmlElement(ElementName = Constants.XmlElementNameWeeklyTaskStatus, IsNullable = false)]
        public WeeklyTaskStatus WeeklyTaskStatus { get; set; }

        [XmlElement(ElementName = Constants.XmlElementNameWeeklyTaskType)]
        public WeeklyTaskType WeeklyTaskType { get; set; }

        [XmlElement(ElementName = Constants.XmlElementNameWeeklyTaskUserId)]
        public int Uid { get; set; }

        [XmlElement(ElementName = Constants.XmlElementNameWeeklyTaskCredits)]
        public UInt64 Credits { get; set; }

        [XmlElement(ElementName = Constants.XmlElementNameWeeklyTaskNotes)]
        public string Notes { get; set; }

        [XmlElement(ElementName = Constants.XmlElementNameWeeklyTaskCreator)]
        public string Creator { get; set; }

        [XmlElement(ElementName = Constants.XmlElementNameWeeklyTaskDateTimeStart)]
        public DateTime DateTimeStart { get; set; }

        [XmlElement(ElementName = Constants.XmlElementNameWeeklyTaskDateTimeStop)]
        public DateTime DateTimeStop { get; set; }
    }
}
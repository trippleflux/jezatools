using System;
using System.Xml.Serialization;

namespace jeza.ioFTPD.Framework.Manager
{
    public class NewDayTask
    {
        [XmlElement(ElementName = Constants.XmlElementNameNewDayTaskStatus, IsNullable = false)]
        public NewDayTaskStatus Status { get; set; }

        [XmlElement(ElementName = Constants.XmlElementNameNewDayTaskRealPath)]
        public string RealPath { get; set; }

        [XmlElement(ElementName = Constants.XmlElementNameNewDayTaskVirtualPath)]
        public string VirtualPath { get; set; }

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

        [XmlElement(ElementName = Constants.XmlElementNameNewDayTaskCultureInfo)]
        public string CultureInfo { get; set; }

        [XmlElement(ElementName = Constants.XmlElementNameNewDayTaskFirstDayOfWeek)]
        public DayOfWeek FirstDayOfWeek { get; set; }

        [XmlElement(ElementName = Constants.XmlElementNameNewDayTaskLogFormat)]
        public string LogFormat { get; set; }

        public override string ToString()
        {
            return string.Format("Status: {0}, RealPath: {1}, VirtualPath: {2}, FolderFormat: {3}, Symlink: {4}, Mode: {5}, UserId: {6}, GroupId: {7}, CultureInfo: {8}, FirstDayOfWeek: {9}", Status, RealPath, VirtualPath, FolderFormat, Symlink, Mode, UserId, GroupId, CultureInfo, FirstDayOfWeek);
        }
    }
}
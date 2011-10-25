using System;
using System.Xml.Serialization;

namespace jeza.ioFTPD.Framework.Manager
{
    public class NewDayTask
    {
        [XmlElement(ElementName = Constants.XmlElementNameNewDayTaskStatus, IsNullable = false)]
        public NewDayTaskStatus Status { get; set; }

        [XmlElement(ElementName = Constants.XmlElementNameNewDayTaskType)]
        public NewDayTaskType Type { get; set; }

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

        public override string ToString()
        {
            return string.Format("Status: {0}, Type: {1}, RealPath: {2}, VirtualPath: {3}, FolderFormat: {4}, Symlink: {5}, Mode: {6}, UserId: {7}, GroupId: {8}, CultureInfo: {9}, FirstDayOfWeek: {10}", Status, Type, RealPath, VirtualPath, FolderFormat, Symlink, Mode, UserId, GroupId, CultureInfo, FirstDayOfWeek);
        }
    }
}
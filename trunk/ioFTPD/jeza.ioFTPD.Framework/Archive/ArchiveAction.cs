using System;
using System.Xml.Serialization;

namespace jeza.ioFTPD.Framework.Archive
{
    public class ArchiveAction
    {
        /// <summary>
        /// Gets or sets the id for the action <see cref="ArchiveActionAttribute"/>.
        /// </summary>
        /// <value>The id.</value>
        [XmlAttribute(AttributeName = Constants.XmlElementNameArchiveTaskActionId)]
        public ArchiveActionAttribute Id { get; set; }

        /// <summary>
        /// Gets or sets the value for the action.
        /// </summary>
        /// <example>
        /// <list type="bullet">
        /// <item><c>id=TotalUsedSpace</c>:<c>value=123000000</c> Action wil start executing when total space on the drive is over 123000000 bytes.</item>
        /// <item><c>id=TotalFreeSpace</c>:<c>value=123000000</c> Action wil start executing when total FREE space on the drive is below 123000000 bytes.</item>
        /// <item><c>id=TotalFolderCount</c>:<c>value=123</c> Action wil start executing when total fodler count is over 123.</item>
        /// <item><c>id=DateOlder</c>:<c>value=12</c> Action wil start executing on folders that are older that 12 days.</item>
        /// </list>
        /// </example>
        /// <value>The value.</value>
        [XmlElement(ElementName = Constants.XmlElementNameArchiveTaskActionValue)]
        public UInt64 Value { get; set; }

        /// <summary>
        /// Gets or sets the min folder action. How many folders should the script move/delete at once.
        /// </summary>
        /// <value>The min folder action.</value>
        [XmlElement(ElementName = Constants.XmlElementNameArchiveTaskActionMinFolder)]
        public int MinFolderAction { get; set; }

        public override string ToString()
        {
            return string.Format("[Id: {0}, Value: {1}, MinFolderAction: {2}]", Id, Value, MinFolderAction);
        }
    }
}
using System.Xml.Serialization;

namespace jeza.ioFTPD.Framework.Archive
{
    public class ArchiveTask
    {
        /// <summary>
        /// Gets or sets the type of the archive <see cref="ArchiveType"/>.
        /// </summary>
        /// <value>The type of the archive.</value>
        [XmlElement(ElementName = Constants.XmlElementNameArchiveTaskType)]
        public ArchiveType ArchiveType { get; set; }

        /// <summary>
        /// Gets or sets the archive status <see cref="ArchiveStatus"/>.
        /// </summary>
        /// <value>The archive status.</value>
        [XmlElement(ElementName = Constants.XmlElementNameArchiveTaskStatus)]
        public ArchiveStatus ArchiveStatus { get; set; }

        /// <summary>
        /// Gets or sets the reg expression for skiping matching folders.
        /// </summary>
        /// <value>
        /// The reg expression.
        /// </value>
        [XmlElement(ElementName = Constants.XmlElementNameArchiveTaskRegExExclude)]
        public string RegExpressionExclude { get; set; }

        /// <summary>
        /// Gets or sets the reg expression for including matching folders.
        /// </summary>
        /// <value>
        /// The reg expression include.
        /// </value>
        [XmlElement(ElementName = Constants.XmlElementNameArchiveTaskRegExInclude)]
        public string RegExpressionInclude { get; set; }

        /// <summary>
        /// Gets or sets the source folder for archiving.
        /// </summary>
        /// <value>The source.</value>
        [XmlElement(ElementName = Constants.XmlElementNameArchiveTaskSource)]
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the source virtual folder for archiving.
        /// </summary>
        /// <value>The source.</value>
        [XmlElement(ElementName = Constants.XmlElementNameArchiveTaskSourceVirtual)]
        public string SourceVirtual { get; set; }

        /// <summary>
        /// Gets or sets the destination folder where to move folders if <see cref="ArchiveType"/> is set to Move.
        /// </summary>
        /// <value>The destination.</value>
        [XmlElement(ElementName = Constants.XmlElementNameArchiveTaskDestination)]
        public string Destination { get; set; }

        /// <summary>
        /// Gets or sets the destination virtual folder where to move folders if <see cref="ArchiveType"/> is set to Move.
        /// </summary>
        /// <value>The destination.</value>
        [XmlElement(ElementName = Constants.XmlElementNameArchiveTaskDestinationVirtual)]
        public string DestinationVirtual { get; set; }

        /// <summary>
        /// Gets or sets the action <see cref="ArchiveActionAttribute"/>.
        /// </summary>
        /// <value>The action.</value>
        [XmlElement(ElementName = Constants.XmlElementNameArchiveTaskAction)]
        public ArchiveAction Action { get; set; }

        /// <summary>
        /// String to log for MIRC anounce.
        /// </summary>
        [XmlElement(ElementName = Constants.XmlElementNameArchiveTaskLogFormat)]
        public string LogFormat { get; set; }

        public override string ToString()
        {
            return string.Format("ArchiveType: {0}, ArchiveStatus: {1}, Source: '{2}', Destination: '{3}', Action: {4}, LogFormat: '{5}'", ArchiveType, ArchiveStatus, Source, Destination, Action, LogFormat);
        }
    }
}
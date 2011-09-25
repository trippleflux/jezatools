using System.Xml.Serialization;

namespace jeza.ioFTPD.Framework
{
    public class ArchiveTask
    {
        /// <summary>
        /// Gets or sets the type of the archive <see cref="ArchiveType"/>.
        /// </summary>
        /// <value>The type of the archive.</value>
        [XmlElement(ElementName = "actionType")]
        public ArchiveType ArchiveType { get; set; }

        /// <summary>
        /// Gets or sets the archive status <see cref="ArchiveStatus"/>.
        /// </summary>
        /// <value>The archive status.</value>
        [XmlElement(ElementName = "status")]
        public ArchiveStatus ArchiveStatus { get; set; }

        /// <summary>
        /// Skip directoris that staarts with any of those strings.
        /// </summary>
        [XmlElement(ElementName = "skipPattern")]
        public string[] SkipPattern = new string[] {".", "_"};

        /// <summary>
        /// Gets or sets the source folder for archiving.
        /// </summary>
        /// <value>The source.</value>
        [XmlElement(ElementName = "source")]
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the destination folder where to move folders if <see cref="ArchiveType"/> is set to Move.
        /// </summary>
        /// <value>The destination.</value>
        [XmlElement(ElementName = "destination")]
        public string Destination { get; set; }

        /// <summary>
        /// Gets or sets the action <see cref="ArchiveActionAttribute"/>.
        /// </summary>
        /// <value>The action.</value>
        [XmlElement(ElementName = "action")]
        public ArchiveAction Action { get; set; }

        public override string ToString()
        {
            return string.Format("ArchiveType: {0}, ArchiveStatus: {1}, Source: {2}, Destination: {3}, Action: {4}", ArchiveType, ArchiveStatus, Source, Destination, Action);
        }
    }
}
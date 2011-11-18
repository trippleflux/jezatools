using System;
using System.Xml.Serialization;

namespace jeza.ioFTPD.Framework.Manager
{
    public class RequestTask
    {
        [XmlElement(ElementName = Constants.XmlElementNameRequestTaskName)]
        public string Name { get; set; }

        [XmlElement(ElementName = Constants.XmlElementNameRequestTaskDateAdded)]
        public DateTime DateAdded { get; set; }

        [XmlElement(ElementName = Constants.XmlElementNameRequestTaskCreator)]
        public string Username { get; set; }

        [XmlElement(ElementName = Constants.XmlElementNameRequestTaskGroupname)]
        public string Groupname { get; set; }
    }
}
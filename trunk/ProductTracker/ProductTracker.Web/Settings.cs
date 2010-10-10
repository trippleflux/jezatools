#region

using System.Collections.Generic;
using System.Xml.Serialization;

#endregion

namespace ProductTracker.Web
{
    [XmlRoot(ElementName = "settings")]
    public class Settings
    {
        public Settings()
        {
            Page = new List<Page>();
        }

        [XmlElement(ElementName = "page")]
        public List<Page> Page { get; set; }
    }

    public class Page
    {
        public Page()
        {
            Setting = new List<Setting>();
        }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlElement(ElementName = "setting")]
        public List<Setting> Setting { get; set; }
    }

    public class Setting
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }
}
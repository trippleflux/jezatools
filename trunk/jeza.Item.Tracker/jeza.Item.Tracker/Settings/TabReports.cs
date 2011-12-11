using System.Xml.Serialization;

namespace jeza.Item.Tracker.Settings
{
    public class TabReports
    {
        [XmlAttribute]
        public string Name { get; set; }
    }
}
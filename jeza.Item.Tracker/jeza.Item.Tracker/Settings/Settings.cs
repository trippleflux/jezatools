using System.Collections.Generic;
using System.Xml.Serialization;

namespace jeza.Item.Tracker.Settings
{
    [XmlRoot]
    public class Settings
    {
        [XmlArray]
        public List<Language> Languages { get; set; }
    }
}
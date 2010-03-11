using System.Collections.Generic;
using System.Xml.Serialization;

namespace jeza.Travian.Framework
{
    public class Actions
    {
        public Actions()
        {
            BuildQueue = new List<BuildQueue>();
        }

        [XmlElement(ElementName = "buildQueues")]
        public List<BuildQueue> BuildQueue { get; set; }
    }
}
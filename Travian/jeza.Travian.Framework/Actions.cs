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

        //[XmlElement(ElementName = "buildQueue")]
        public List<BuildQueue> BuildQueue { get; set; }
    }
}
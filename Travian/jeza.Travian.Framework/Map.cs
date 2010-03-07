#region

using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

#endregion

namespace jeza.Travian.Framework
{
    public class Map
    {
        public void DeserializeValleys()
        {
            if (File.Exists(ValleysXml))
            {
                using (FileStream fileStream = new FileStream(ValleysXml, FileMode.Open))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Valley>));
                    valleys = (List<Valley>)xmlSerializer.Deserialize(fileStream);
                }
            }
            else
            {
                SerializeValleys();
            }
        }

        public void SerializeValleys()
        {
            using(TextWriter textWriter = new StreamWriter(ValleysXml))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Valley>));
                xmlSerializer.Serialize(textWriter, valleys);
            }
        }

        public List<Valley> Valleys
        {
            get { return valleys; }
        }

        /// <summary>
        /// Adds the villageto the list.
        /// </summary>
        /// <param name="valley">The valley.</param>
        public void AddVillage(Valley valley)
        {
            valleys.Add(valley);
        }

        /// <summary>
        /// Adds the villages.
        /// </summary>
        /// <param name="valleyList">The valleyList.</param>
        public void AddVillages(List<Valley> valleyList)
        {
            valleys.AddRange(valleyList);
        }

        private List<Valley> valleys = new List<Valley>();
        const string ValleysXml = "Valleys.xml";
    }
}
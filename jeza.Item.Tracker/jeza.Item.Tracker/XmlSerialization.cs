using System;
using System.IO;
using System.Xml.Serialization;

namespace jeza.Item.Tracker
{
    public class XmlSerialization
    {
        /// <summary>
        /// Deserializes the specified XML object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlObject">The XML object.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public T Deserialize<T>
            (T xmlObject,
             string fileName)
        {
            if (File.Exists(fileName))
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    return (T)xmlSerializer.Deserialize(fileStream);
                }
            }
            throw new Exception("Failed to deserialize configuration!");
        }

        public void Serialize<T>
            (T xmlObject,
             string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (TextWriter textWriter = new StreamWriter(fileName))
            {
                xmlSerializer.Serialize(textWriter, xmlObject);
            }
        }
    }
}
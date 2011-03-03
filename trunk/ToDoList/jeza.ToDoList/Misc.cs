using System.IO;
using System.Xml.Serialization;

namespace jeza.ToDoList
{
    public class Misc
    {
        public static void Serialize<T>(T xmlObject, string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof (T));
            using (TextWriter textWriter = new StreamWriter(fileName))
            {
                xmlSerializer.Serialize(textWriter, xmlObject);
            }
        }

        public static T Deserialize<T>(string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof (T));
            using (TextReader textReader = new StreamReader(fileName))
            {
                return (T) xmlSerializer.Deserialize(textReader);
            }
        }
    }
}
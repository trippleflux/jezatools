using System.IO;
using System.Xml;

namespace TravianBot.Framework
{
    public class TroopSendXmlParser : ActionParser
    {
        public TroopSendXmlParser(Stream xmlSendTroopsStream)
        {
            this.xmlSendTroopsStream = xmlSendTroopsStream;
        }

        public TroopSendXmlParser(string fileName)
        {
            xmlSendTroopsStream = File.OpenRead(fileName);
        }

        public override ActionList Parse()
        {
            XmlReaderSettings xmlReaderSettings =
                new XmlReaderSettings
                    {
                        IgnoreComments = true,
                        IgnoreProcessingInstructions = true,
                        IgnoreWhitespace = true,
                    };

            ActionList actionList = new ActionList();

            using (XmlReader xmlReader = XmlReader.Create(xmlSendTroopsStream, xmlReaderSettings))
            {
                xmlReader.Read();

                while (false == xmlReader.EOF)
                {
                    switch (xmlReader.NodeType)
                    {
                        case XmlNodeType.Element:
                            {
                                if (xmlReader.Name != "actions")
                                    throw new XmlException("<actions> (root) element expected.");

                                ReadAction(actionList, xmlReader);

                                break;
                            }

                        case XmlNodeType.XmlDeclaration:
                            {
                                xmlReader.Read();
                                break;
                            }

                        default:
                            {
                                throw new XmlException();
                            }
                    }
                }
            }
            return actionList;
        }

        private readonly Stream xmlSendTroopsStream;
    }
}
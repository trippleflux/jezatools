using System;
using System.IO;
using System.Xml;

namespace TravianBot.Framework
{
    public class ActionParser : IDisposable
    {
        public ActionParser(Stream xmlStream)
        {
            this.xmlStream = xmlStream;
        }

        public ActionParser(string fileName)
        {
            xmlStream = File.OpenRead(fileName);
        }

        public ActionList Parse()
        {
            XmlReaderSettings xmlReaderSettings =
                new XmlReaderSettings
                    {
                        IgnoreComments = true,
                        IgnoreProcessingInstructions = true,
                        IgnoreWhitespace = true,
                    };

            ActionList actionList = new ActionList();

            using (XmlReader xmlReader = XmlReader.Create(xmlStream, xmlReaderSettings))
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

        public static void ReadAction(ActionList actionList, XmlReader xmlReader)
        {
            xmlReader.Read();
            while (xmlReader.NodeType != XmlNodeType.EndElement)
            {
                switch (xmlReader.Name)
                {
                    case "attackAction":
                        {
                            Action action = new Action();
                            // ReSharper disable UseObjectOrCollectionInitializer
                            ActionParameters actionParameters = new ActionParameters();
                            // ReSharper restore UseObjectOrCollectionInitializer
                            actionParameters.Id = ReadAttribute(xmlReader, "id");
                            actionParameters.Enabled = Int32.Parse(ReadAttribute(xmlReader, "enabled"));
                            actionParameters.CoordinateX = Int32.Parse(ReadAttribute(xmlReader, "coordinateX"));
                            actionParameters.CoordinateY = Int32.Parse(ReadAttribute(xmlReader, "coordinateY"));
                            actionParameters.SendTroopType = Int32.Parse(ReadAttribute(xmlReader, "sendTroopType"));
                            actionParameters.UnitCount = Int32.Parse(ReadAttribute(xmlReader, "unitCount"));
                            actionParameters.UnitId = Int32.Parse(ReadAttribute(xmlReader, "unitId"));
                            actionParameters.UnitName = ReadAttribute(xmlReader, "unitName");
                            actionParameters.VillageId = Int32.Parse(ReadAttribute(xmlReader, "villageId"));
                            actionParameters.Comment = ReadAttribute(xmlReader, "comment");
                            action.AddActionParameters(actionParameters);
                            actionList.AddAction(actionParameters.Id, action);
                            xmlReader.Read();
                            break;
                        }

                    default:
                        {
                            throw new NotSupportedException(xmlReader.Name + " not supported");
                        }
                }
            }
            xmlReader.Read();
        }

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or
        /// resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the object.
        /// </summary>
        /// <param name="disposing">If <code>false</code>, cleans up native resources. 
        /// If <code>true</code> cleans up both managed and native resources</param>
        protected virtual void Dispose(bool disposing)
        {
            if (false == disposed)
            {
                if (disposing)
                {
                }

                disposed = true;
            }
        }

        private bool disposed;

        #endregion

        private static string ReadAttribute(XmlReader xmlReader, string attributeName)
        {
            return xmlReader.GetAttribute(attributeName);
        }

        private readonly Stream xmlStream;
    }
}
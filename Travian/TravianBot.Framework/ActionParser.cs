#region

using System;
using System.IO;
using System.Xml;

#endregion

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
                            {
                                throw new XmlException("<actions> (root) element expected.");
                            }

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

        public static void ReadAction
            (ActionList actionList,
             XmlReader xmlReader)
        {
            xmlReader.Read();
            while (xmlReader.NodeType != XmlNodeType.EndElement)
            {
                switch (xmlReader.Name)
                {
                    case "attackAction":
                    {
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
                        actionParameters.PlayerName = ReadAttribute(xmlReader, "playername");
                        actionParameters.Population = Int32.Parse(ReadAttribute(xmlReader, "population"));
                        actionParameters.VillageName = ReadAttribute(xmlReader, "villagename");
                        actionParameters.Aliance = ReadAttribute(xmlReader, "aliance");
                        Action action = new Action(actionParameters.Id);
                        action.AddActionParameters(actionParameters);
                        actionList.AddAction(actionParameters.Id, action);
                        xmlReader.Read();
                        break;
                    }

                    case "trooSenderAction":
                    {
                        TroopSenderParamaters troopSenderParamaters = new TroopSenderParamaters();
                        troopSenderParamaters.Id = ReadAttribute(xmlReader, "id");
                        troopSenderParamaters.Time = ReadAttribute(xmlReader, "time");
                        troopSenderParamaters.UseKatas = Int32.Parse(ReadAttribute(xmlReader, "useKatas"));
                        troopSenderParamaters.KataDest1 = Int32.Parse(ReadAttribute(xmlReader, "kataDest1"));
                        troopSenderParamaters.KataDest2 = Int32.Parse(ReadAttribute(xmlReader, "kataDest2"));
                        troopSenderParamaters.TroopList = ReadAttribute(xmlReader, "troopList");
                        troopSenderParamaters.DestX = Int32.Parse(ReadAttribute(xmlReader, "destX"));
                        troopSenderParamaters.DestY = Int32.Parse(ReadAttribute(xmlReader, "destY"));
                        troopSenderParamaters.VillageId = Int32.Parse(ReadAttribute(xmlReader, "villageId"));
                        troopSenderParamaters.AttackType = Int32.Parse(ReadAttribute(xmlReader, "attackType"));
                        Action action = new Action(troopSenderParamaters.Id);
                        action.AddTroopSenderParameters(troopSenderParamaters);
                        actionList.AddTroopSenderAction(action);
                        xmlReader.Read();
                        break;
                    }

                    case "fakeAttack":
                    {
                        FakeParamaters fakeParamaters = new FakeParamaters();
                        fakeParamaters.Id = ReadAttribute(xmlReader, "id");
                        fakeParamaters.VillageId = Int32.Parse(ReadAttribute(xmlReader, "villageId"));
                        fakeParamaters.UnitId = Int32.Parse(ReadAttribute(xmlReader, "unitId"));
                        fakeParamaters.UserIdUrl = ReadAttribute(xmlReader, "uid");
                        Action action = new Action(fakeParamaters.Id);
                        action.AddFakeParameters(fakeParamaters);
                        actionList.AddFakeAction(action);
                        xmlReader.Read();
                        break;
                    }

                    case "sendResources":
                    {
                        SendResourcesParameters sendResourcesParameters = new SendResourcesParameters();
                        sendResourcesParameters.Id = ReadAttribute(xmlReader, "id");
                        sendResourcesParameters.Enabled = Int32.Parse(ReadAttribute(xmlReader, "enabled"));
                        sendResourcesParameters.SourceVillageId = Int32.Parse(ReadAttribute(xmlReader, "sourceVillageId"));
                        sendResourcesParameters.DestinationVillageX = Int32.Parse(ReadAttribute(xmlReader, "destX"));
                        sendResourcesParameters.DestinationVillageY = Int32.Parse(ReadAttribute(xmlReader, "destY"));
                        sendResourcesParameters.WoodAmount = Int32.Parse(ReadAttribute(xmlReader, "woodAmount"));
                        sendResourcesParameters.ClayAmount = Int32.Parse(ReadAttribute(xmlReader, "clayAmount"));
                        sendResourcesParameters.IronAmount = Int32.Parse(ReadAttribute(xmlReader, "ironAmount"));
                        sendResourcesParameters.CropAmount = Int32.Parse(ReadAttribute(xmlReader, "cropAmount"));
                        Action action = new Action(sendResourcesParameters.Id);
                        action.AddSendResourcesParameters(sendResourcesParameters);
                        actionList.AddSendResourcesAction(action);
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

        private static string ReadAttribute
            (XmlReader xmlReader,
             string attributeName)
        {
            return xmlReader.GetAttribute(attributeName);
        }

        private readonly Stream xmlStream;
    }
}
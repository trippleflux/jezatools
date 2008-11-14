using System;
using System.Xml;

namespace TravianPlayer.Framework
{
    public class XmlSendTroopsParser : IActionParser
    {
        public XmlSendTroopsParser(string sendTroopsList)
        {
            this.sendTroopsList = sendTroopsList;
        }

        public TaskList Parse()
        {
            TaskList attackList = new TaskList();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(sendTroopsList);

            if (xmlDocument.DocumentElement != null)
            {
                foreach (XmlNode attackNode in xmlDocument.DocumentElement.ChildNodes)
                {
                    if (!attackNode.Name.Equals("attackAction"))
                    {
                        throw new NotImplementedException("Unknown node '" + attackNode.Name + "'");
                    }
                    Action action = new Action();
                    ActionParameters actionParameters = new ActionParameters();
                    foreach (XmlAttribute attribute in attackNode.Attributes)
                    {
                        string attributeName = attribute.Name;
                        int attributeValue = 0;
                        if (!attributeName.Equals("comment"))
                        {
                            attributeValue = Int32.Parse(attribute.Value);
                        }

                        switch (attributeName)
                        {
                            case "id":
                                {
                                    actionParameters.Id = attributeValue;
                                    break;
                                }
                            case "villageId":
                                {
                                    actionParameters.VillageId = attributeValue;
                                    break;
                                }
                            case "coordX":
                                {
                                    actionParameters.CoordX = attributeValue;
                                    break;
                                }
                            case "coordY":
                                {
                                    actionParameters.CoordY = attributeValue;
                                    break;
                                }
                            case "attackType":
                                {
                                    actionParameters.AttackType = attributeValue;
                                    break;
                                }
                            case "attackUnit":
                                {
                                    actionParameters.AttackUnit = attributeValue;
                                    break;
                                }
                            case "troopCount":
                                {
                                    actionParameters.TroopCount = attributeValue;
                                    break;
                                }
                            default:
                                {
                                    actionParameters.Comment = attribute.Value;
                                    break;
                                }
                        }
                    }
                    action.AddActionParameters(actionParameters);
                    attackList.AddAction(actionParameters.Id, action);
                }
            }
            return attackList;
        }

        private readonly string sendTroopsList;
    }
}
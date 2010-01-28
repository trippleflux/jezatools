using System;
using System.IO;
using System.Text;
using System.Xml;
using NUnit.Framework;
using TravianBot.Framework;

namespace TravianBot.Tests
{
    [TestFixture]
    public class ActionParserTests
    {
        [Test]
        public void ParseAttacksXmlFile()
        {
            const string fileName = @"..\..\..\Samples\TestFiles\AttackActions.xml";
            ActionList actionList;
            using (ActionParser actionParser = new ActionParser(fileName))
            {
                actionList = actionParser.Parse();
            }
            Assert.IsNotNull(actionList.ActionsList);
            Assert.AreEqual(4, actionList.ActionsList.Count);
            Assert.AreEqual(
                "[user3][village3][aliance3]", 
                actionList.GetAction("3").GetActionParameters("3").Comment);
        }

        [Test]
        public void ParseTroopSendXmlFile()
        {
            const string fileName = @"..\..\..\Samples\TestFiles\SendTroops.xml";
            ActionList actionList;
            using (ActionParser actionParser = new ActionParser(fileName))
            {
                actionList = actionParser.Parse();
            }
            Assert.IsNotNull(actionList.TroopSenderList);
            Assert.AreEqual(4, actionList.TroopSenderList.Count);
            Assert.AreEqual("2009-01-19 20:55:02", actionList.GetTroopSenderAction("3").GetTroopSenderParameters("3").Time);
        }

        [Test]
        public void ParseFakeSendXmlFile()
        {
            const string fileName = @"..\..\..\Samples\FakeAttack\FakeAttack.xml";
            ActionList actionList;
            using (ActionParser actionParser = new ActionParser(fileName))
            {
                actionList = actionParser.Parse();
            }
            Assert.IsNotNull(actionList.FakeActionList);
            Assert.AreEqual(3, actionList.FakeActionList.Count);
        }

        [Test]
        public void ParseSendResourcesXmlFile()
        {
            const string fileName = @"..\..\..\Samples\sendmerchants\ResourceSending.xml";
            ActionList actionList;
            using (ActionParser actionParser = new ActionParser(fileName))
            {
                actionList = actionParser.Parse();
            }
            Assert.IsNotNull(actionList.SendResourcesList);
            Assert.AreEqual(3, actionList.SendResourcesList.Count);
            Assert.AreEqual(1111, actionList.GetSendResourcesAction("2").GetResourceSendParameters("2").WoodAmount);
            Assert.AreEqual(2222, actionList.GetSendResourcesAction("2").GetResourceSendParameters("2").ClayAmount);
            Assert.AreEqual(33, actionList.GetSendResourcesAction("1").GetResourceSendParameters("1").IronAmount);
            Assert.AreEqual(44444, actionList.GetSendResourcesAction("3").GetResourceSendParameters("3").CropAmount);
            Assert.AreEqual(0, actionList.GetSendResourcesAction("1").GetResourceSendParameters("1").DestinationVillageX);
            Assert.AreEqual(-1, actionList.GetSendResourcesAction("1").GetResourceSendParameters("1").DestinationVillageY);
        }

        [Test, ExpectedException(typeof(NotSupportedException))]
        public void NotSupportedElement()
        {
            const string xml = "<actions><action></action></actions>";

            byte[] bytes = Encoding.UTF8.GetBytes(xml);
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                using (ActionParser actionParser = new ActionParser(stream))
                {
                    actionParser.Parse();
                }
            }
        }

        [Test, ExpectedException(typeof(XmlException))]
        public void WrongRootElement()
        {
            const string xml = "<act1ons><attackAction></attackAction></act1ons>";

            byte[] bytes = Encoding.UTF8.GetBytes(xml);
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                using (ActionParser actionParser = new ActionParser(stream))
                {
                    actionParser.Parse();
                }
            }
        }
    }
}
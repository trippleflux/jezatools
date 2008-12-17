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
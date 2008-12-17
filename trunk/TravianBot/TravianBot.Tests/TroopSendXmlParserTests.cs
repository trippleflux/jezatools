using NUnit.Framework;
using TravianBot.Framework;

namespace TravianBot.Tests
{
    [TestFixture]
    public class TroopSendXmlParserTests
    {
        [Test]
        public void ParseXml()
        {
            const string fileName = @"..\..\..\Samples\TestFiles\AttackActions.xml";
            ActionList actionList;
            using (ActionParser actionParser = new TroopSendXmlParser(fileName))
            {
                actionList = actionParser.Parse();
            }
            Assert.IsNotNull(actionList.ActionsList);
            Assert.AreEqual(4, actionList.ActionsList.Count);
            Assert.AreEqual(
                "[user3][village3][aliance3]", 
                actionList.GetAction("3").GetActionParameters("3").Comment);
        }
    }
}
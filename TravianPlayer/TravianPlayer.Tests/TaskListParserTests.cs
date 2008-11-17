using MbUnit.Framework;
using TravianPlayer.Framework;

namespace TravianPlayer.Tests
{
    [TestFixture]
    public class TaskListParserTests
    {
        [Test]
        public void AttackListParser()
        {
            XmlSendTroopsParser xmlSendTroopsParser = new XmlSendTroopsParser(
@"<sendTroops>
<attackAction id=""1"" villageId=""12354"" coordX=""0"" coordY=""0"" attackType=""3"" attackUnit=""3"" attackUnitName=""Metalcev sekir"" troopCount=""10"" comment=""some fancy text about village info""></attackAction>
<attackAction id=""2"" villageId=""12345"" coordX=""-10"" coordY=""-75"" attackType=""3"" attackUnit=""3"" attackUnitName=""Metalcev sekir"" troopCount=""10"" comment=""some fancy text about village info 2""></attackAction>
<attackAction id=""3"" villageId=""12345"" coordX=""-100"" coordY=""-5"" attackType=""3"" attackUnit=""3"" attackUnitName=""Metalcev sekir"" troopCount=""100"" comment=""some fancy text about village info 3""></attackAction>
</sendTroops>");

            TaskList attackList = xmlSendTroopsParser.Parse();
            Assert.AreEqual(3, attackList.GetActionCount);

            Action action = attackList.GetAction(1);
            ActionParameters actionParameters = action.GetActionParameters(1);
            Assert.AreEqual(1, actionParameters.Id);
            Assert.AreEqual(12354, actionParameters.VillageId);
            Assert.AreEqual(3, actionParameters.AttackUnit);

            action = attackList.GetAction(3);
            actionParameters = action.GetActionParameters(3);
            Assert.AreEqual(3, actionParameters.Id);
            Assert.AreEqual(12345, actionParameters.VillageId);
            Assert.AreEqual(3, actionParameters.AttackType);
            Assert.AreEqual(100, actionParameters.TroopCount);
        }
    }
}
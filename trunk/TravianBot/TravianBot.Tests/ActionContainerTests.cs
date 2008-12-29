using NUnit.Framework;
using TravianBot.Framework;

namespace TravianBot.Tests
{
    [TestFixture]
    public class ActionContainerTests
    {
        [Test]
        public void ActionContainerTest()
        {
            Action action = new Action("1");
            ActionParameters actionParameters = new ActionParameters();
            actionParameters.Id = "1";
            action.AddActionParameters(actionParameters);
            ActionList actionList = new ActionList();
            actionList.AddAction("1", action);
            ActionContainer actionContainer = new ActionContainer();
            actionContainer.AddActionList("C:\\asd.xml", actionList);

            Assert.IsNotNull(actionContainer.ActionsContainer);
            Assert.AreEqual(1, actionContainer.ActionsContainer.Count);
            Assert.IsNotNull(actionList.ActionsList);
            Assert.AreEqual(1, actionList.ActionsList.Count);
            Assert.IsNull(actionList.GetAction("99"));
            Assert.IsNotNull(actionList.GetAction("1"));
            Assert.AreEqual("1", actionList.GetAction("1").GetActionParameters("1").Id);
            Assert.AreEqual("1", actionContainer.GetActionList("C:\\asd.xml").GetAction("1").GetActionParameters("1").Id);
        }
    }
}
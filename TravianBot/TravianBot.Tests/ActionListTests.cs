using NUnit.Framework;
using TravianBot.Framework;

namespace TravianBot.Tests
{
    [TestFixture]
    public class ActionListTests
    {
        [Test]
        public void ActionsListTest()
        {
            Action action = new Action();
// ReSharper disable UseObjectOrCollectionInitializer
            ActionParameters actionParameters = new ActionParameters();
// ReSharper restore UseObjectOrCollectionInitializer
            actionParameters.Id = "1";
            action.AddActionParameters(actionParameters);
            ActionList actionList = new ActionList();
            actionList.AddAction("1", action);
            Assert.IsNotNull(actionList.ActionsList);
            Assert.AreEqual(1, actionList.ActionsList.Count);
            Assert.IsNull(actionList.GetAction("99"));
            Assert.IsNotNull(actionList.GetAction("1"));
            Assert.AreEqual("1", actionList.GetAction("1").GetActionParameters("1").Id);
        }
    }
}
using NUnit.Framework;
using TravianBot.Framework;

namespace TravianBot.Tests
{
    [TestFixture]
    public class ActionTests
    {
        [Test]
        public void ActionTest()
        {
            Action action = new Action("0");
// ReSharper disable UseObjectOrCollectionInitializer
            ActionParameters actionParameters = new ActionParameters();
// ReSharper restore UseObjectOrCollectionInitializer
            actionParameters.Id = "0";
            action.AddActionParameters(actionParameters);
            Assert.IsNotNull(action.ActionParameters);
            Assert.AreEqual(1, action.ActionParameters.Count);
            Assert.IsNull(action.GetActionParameters("99"));
            Assert.IsNotNull(action.GetActionParameters("0"));
            Assert.AreEqual("0", action.GetActionParameters("0").Id);
        }

        [Test]
        public void TroopSenderTest()
        {
            Action action = new Action("0");
            TroopSenderParamaters actionParameters = new TroopSenderParamaters();
            actionParameters.Id = "0";
            action.AddTroopSenderParameters(actionParameters);
            Assert.IsNotNull(action.TroopSenderParameters);
            Assert.AreEqual(1, action.TroopSenderParameters.Count);
            Assert.IsNull(action.GetTroopSenderParameters("99"));
            Assert.IsNotNull(action.GetTroopSenderParameters("0"));
            Assert.AreEqual("0", action.GetTroopSenderParameters("0").Id);
        }
    }
}
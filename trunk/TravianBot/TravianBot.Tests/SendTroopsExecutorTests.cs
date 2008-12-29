using NUnit.Framework;
using TravianBot.Framework;

namespace TravianBot.Tests
{
    [TestFixture]
    public class SendTroopsExecutorTests
    {
        [Test]
        public void TeSendTroopsExecutor()
        {
            ServerInfo serverInfo = new ServerInfo();
            SendTroopsExecutor sendTroopsExecutor = new SendTroopsExecutor(serverInfo);
            sendTroopsExecutor.Parse();
            Assert.IsNotNull(sendTroopsExecutor.ActionList);
            Assert.IsNotNull(sendTroopsExecutor.ActionContainer);
            Assert.IsNotNull(sendTroopsExecutor.ActionContainer.ActionsContainer.Count);
            Assert.AreEqual(1, sendTroopsExecutor.ActionContainer.ActionsContainer.Count);
            Assert.AreEqual(4, sendTroopsExecutor.ActionList.ActionsList.Count);
            Assert.AreEqual("asd", sendTroopsExecutor.ActionList.ActionsList["1"].GetActionParameters("1").PlayerName);
        }
    }
}

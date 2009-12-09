using NUnit.Framework;
using TravianBot.Framework;

namespace TravianBot.Tests
{
    [TestFixture]
    public class SendResourcesExecutorTests
    {
        [Test]
        public void SendTroopsExecutorParser()
        {
            ServerInfo serverInfo = new ServerInfo();
            SendResourcesExecutor sendResourcesExecutor = new SendResourcesExecutor(serverInfo);
            sendResourcesExecutor.Parse();
            Assert.IsNotNull(sendResourcesExecutor.ActionList);
            Assert.IsNotNull(sendResourcesExecutor.ActionContainer);
            Assert.IsNotNull(sendResourcesExecutor.ActionContainer.ActionsContainer.Count);
            Assert.AreEqual(1, sendResourcesExecutor.ActionContainer.ActionsContainer.Count);
            Assert.AreEqual(3, sendResourcesExecutor.ActionList.SendResourcesList.Count);
            Assert.AreEqual(-1, sendResourcesExecutor.ActionList.GetSendResourcesAction("1").GetResourceSendParameters("1").DestinationVillageY);
        }

        [Test]
        public void SendTroopsExecutorProcess()
        {
            ServerInfo serverInfo = new ServerInfo();
            serverInfo.Villages.Add(new Village(0, "01"));
            serverInfo.Villages.Add(new Village(1, "01"));
            serverInfo.Villages.Add(new Village(3, "01"));
            serverInfo.Villages.Add(new Village(83117, "01"));
            SendResourcesExecutor sendResourcesExecutor = new SendResourcesExecutor(serverInfo);
            sendResourcesExecutor.Parse();
            sendResourcesExecutor.Process();
        }
    }
}
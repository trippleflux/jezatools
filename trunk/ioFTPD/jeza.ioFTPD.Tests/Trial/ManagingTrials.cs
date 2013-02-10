using System;
using System.Collections.Generic;
using jeza.ioFTPD.Framework;
using NUnit.Framework;

namespace jeza.ioFTPD.Tests.Trial
{
    [TestFixture]
    public class ManagingTrials
    {
        [Test]
        public void SerializeTrials()
        {
            SerializeOneUserInTrial();
        }

        [Test]
        public void AddNonExisting()
        {
            Extensions.Serialize(new List<Framework.TrialQuota.Trial>(), "trials.xml", Config.DefaultNamespaceTrialQuota);
            ConsoleAppTrial consoleAppTrial = new ConsoleAppTrial(new string[] {"trial", "add", "test"});
            consoleAppTrial.Parse();
            consoleAppTrial.Process();
            Assert.AreEqual(0, consoleAppTrial.Trials.Count);
        }

        [Test]
        public void RemoveNonExisting()
        {
            Extensions.Serialize(new List<Framework.TrialQuota.Trial>(), "trials.xml", Config.DefaultNamespaceTrialQuota);
            ConsoleAppTrial consoleAppTrial = new ConsoleAppTrial(new string[] {"trial", "remove", "test"});
            consoleAppTrial.Parse();
            consoleAppTrial.Process();
            Assert.AreEqual(0, consoleAppTrial.Trials.Count);
        }

        [Test]
        [Explicit("When shared memory!")]
        public void List()
        {
            SerializeOneUserInTrial();
            ConsoleAppTrial consoleAppTrial = new ConsoleAppTrial(new string[] {"trial"});
            consoleAppTrial.Parse();
            consoleAppTrial.Process();
            Assert.AreEqual(1, consoleAppTrial.Trials.Count);
        }

        private void SerializeOneUserInTrial()
        {
            Framework.TrialQuota.Trial trial = new Framework.TrialQuota.Trial
                                               {
                                                   Uid = 0,
                                                   Period = 7,
                                                   QuotaToPass = 5000,
                                                   StartAllUp = 0,
                                                   DateAdded = new DateTime(DateTime.Now.Ticks),
                                               };
            List<Framework.TrialQuota.Trial> trials = new List<Framework.TrialQuota.Trial> {trial};
            Extensions.Serialize(trials, "trials.xml", Config.DefaultNamespaceTrialQuota);
        }
    }
}
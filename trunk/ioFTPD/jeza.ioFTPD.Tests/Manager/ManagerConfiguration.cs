using System;
using jeza.ioFTPD.Framework;
using jeza.ioFTPD.Framework.Manager;
using MbUnit.Framework;

namespace jeza.ioFTPD.Tests.Manager
{
    [TestFixture]
    public class ManagerConfiguration
    {
        /// <summary>
        /// Save new configuration.
        /// </summary>
        [Test]
        public void SaveConfigurationManager()
        {
            Framework.Manager.ManagerConfiguration managerConfiguration = new Framework.Manager.ManagerConfiguration();
            DateTime dateTime = new DateTime(DateTime.UtcNow.Ticks);
            WeeklyTask weeklyTask1 = new WeeklyTask
                                     {
                                         WeeklyTaskStatus = WeeklyTaskStatus.Enabled,
                                         Uid = 1,
                                         Creator = "test",
                                         Credits = 1024,
                                         Notes = "Just for fun!",
                                         DateTimeStart = dateTime,
                                         DateTimeStop = dateTime.AddYears(1),
                                         WeeklyTaskType = WeeklyTaskType.Day,
                                     };
            WeeklyTask weeklyTask2 = new WeeklyTask
                                     {
                                         WeeklyTaskStatus = WeeklyTaskStatus.Pending,
                                         Uid = 123,
                                         Creator = "test 123",
                                         Credits = 1024 * 1024 * 24,
                                         Notes = "Just for fun 123!",
                                         DateTimeStart = dateTime,
                                         DateTimeStop = dateTime.AddYears(2),
                                         WeeklyTaskType = WeeklyTaskType.Week,
                                     };
            managerConfiguration.WeeklyTask = new[] {weeklyTask1, weeklyTask2};
            Extensions.Serialize(managerConfiguration, ConfigurationFile, DefaultNamespace);
        }

        private const string ConfigurationFile = "testConfigManager.xml";
        private const string DefaultNamespace = "http://jeza.ioFTPD.Tools/XMLSchema.xsd";
    }
}
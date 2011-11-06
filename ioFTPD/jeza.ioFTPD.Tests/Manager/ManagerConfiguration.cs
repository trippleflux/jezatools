using System;
using jeza.ioFTPD.Framework;
using jeza.ioFTPD.Framework.Manager;
using MbUnit.Framework;

namespace jeza.ioFTPD.Tests.Manager
{
    [TestFixture]
    public class ManagerConfiguration
    {
        public ManagerConfiguration()
        {
            taskConfiguration = new TaskConfiguration
            {
                WeeklyTasks = new[] { weeklyTask1, weeklyTask2 },
                NewDayTasks = new[] { newDayTask },
            };
        }

        /// <summary>
        /// Save new configuration.
        /// </summary>
        [Test]
        public void SaveConfigurationManager()
        {
            Extensions.Serialize(taskConfiguration, configurationFile, DefaultNamespace);
        }

        private readonly string configurationFile = Config.FileNameConfiguration;
        private const string DefaultNamespace = Config.DefaultNamespace;
        private TaskConfiguration taskConfiguration;

        /// <summary>
        /// Predefined task configuration.
        /// </summary>
        public TaskConfiguration TaskConfiguration
        {
            get { return taskConfiguration; }
            set { taskConfiguration = value; }
        }

        private static DateTime dateTime = new DateTime(DateTime.UtcNow.Ticks);

        private readonly WeeklyTask weeklyTask1 = new WeeklyTask
                                                  {
                                                      WeeklyTaskStatus = WeeklyTaskStatus.Enabled,
                                                      Uid = 1,
                                                      Creator = "test",
                                                      Credits = 1024,
                                                      Notes = "Just for fun!",
                                                      DateTimeStart = dateTime,
                                                      DateTimeStop = dateTime.AddYears(1),
                                                  };

        private readonly WeeklyTask weeklyTask2 = new WeeklyTask
                                                  {
                                                      WeeklyTaskStatus = WeeklyTaskStatus.Pending,
                                                      Uid = 123,
                                                      Creator = "test 123",
                                                      Credits = 1024 * 1024 * 24,
                                                      Notes = "Just for fun 123!",
                                                      DateTimeStart = dateTime,
                                                      DateTimeStop = dateTime.AddYears(2),
                                                  };

        private readonly NewDayTask newDayTask = new NewDayTask
                                                 {
                                                     FolderFormat = "{0}{1}",
                                                     GroupId = 0,
                                                     Mode = 777,
                                                     RealPath = "D:\\mp3\\day",
                                                     VirtualPath = "/mp3/day/",
                                                     Symlink = "today-mp3",
                                                     UserId = 0,
                                                     Status = NewDayTaskStatus.Enabled,
                                                     CultureInfo = "en-US",
                                                     FirstDayOfWeek = DayOfWeek.Sunday,
                                                 };
    }
}
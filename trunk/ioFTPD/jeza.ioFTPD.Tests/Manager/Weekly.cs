using System;
using jeza.ioFTPD.Framework;
using jeza.ioFTPD.Framework.Manager;
using MbUnit.Framework;

namespace jeza.ioFTPD.Tests.Manager
{
    [TestFixture]
    public class Weekly
    {
        /// <summary>
        /// Scheduler.
        /// </summary>
        [Test]
        public void Check()
        {
            DateTime dateTime = new DateTime(DateTime.UtcNow.Ticks);
            ConsoleAppTasks task = new ConsoleAppTasks(new[] { "weekly", "check"})
            {
                TaskConfiguration = new TaskConfiguration
                {
                    WeeklyTasks = new[]
                                                                             {
                                                                                 new WeeklyTask
                                                                                 {
                                                                                     WeeklyTaskStatus = WeeklyTaskStatus.Enabled,
                                                                                     Uid = 1,
                                                                                     Username = "newuser",
                                                                                     Creator = "test",
                                                                                     Credits = 1024,
                                                                                     Notes = "asd!",
                                                                                     DateTimeStart = dateTime,
                                                                                     DateTimeStop = dateTime.AddYears(1),
                                                                                 },
                                                                                 new WeeklyTask
                                                                                 {
                                                                                     WeeklyTaskStatus = WeeklyTaskStatus.Enabled,
                                                                                     Username = "user 2",
                                                                                     Uid = 2,
                                                                                     Creator = "test 2",
                                                                                     Credits = 1024 * 1024 * 1024,
                                                                                     Notes = "Just for fun 2 !",
                                                                                     DateTimeStart = dateTime,
                                                                                     DateTimeStop = dateTime.AddYears(1),
                                                                                 },
                                                                             },
                }
            };
            TaskConfiguration taskConfiguration = task.TaskConfiguration;
            Assert.AreEqual(2, taskConfiguration.WeeklyTasks.Length);
            task.Execute(TaskType.Weekly);
            Assert.AreEqual(2, taskConfiguration.WeeklyTasks.Length);
        }        /// <summary>
        /// Add new weekly task.
        /// </summary>
        [Test]
        public void Remove()
        {
            DateTime dateTime = new DateTime(DateTime.UtcNow.Ticks);
            ConsoleAppTasks task = new ConsoleAppTasks(new[] { "weekly", "del", "newuser"})
            {
                TaskConfiguration = new TaskConfiguration
                {
                    WeeklyTasks = new[]
                                                                             {
                                                                                 new WeeklyTask
                                                                                 {
                                                                                     WeeklyTaskStatus = WeeklyTaskStatus.Enabled,
                                                                                     Uid = 1,
                                                                                     Username = "newuser",
                                                                                     Creator = "test",
                                                                                     Credits = 1024,
                                                                                     Notes = "This one will be removed!",
                                                                                     DateTimeStart = dateTime,
                                                                                     DateTimeStop = dateTime.AddYears(1),
                                                                                 },
                                                                                 new WeeklyTask
                                                                                 {
                                                                                     WeeklyTaskStatus = WeeklyTaskStatus.Enabled,
                                                                                     Username = "user 2",
                                                                                     Uid = 2,
                                                                                     Creator = "test 2",
                                                                                     Credits = 1024 * 1024 * 1024,
                                                                                     Notes = "Just for fun 2 !",
                                                                                     DateTimeStart = dateTime,
                                                                                     DateTimeStop = dateTime.AddYears(1),
                                                                                 },
                                                                             },
                }
            };
            TaskConfiguration taskConfiguration = task.TaskConfiguration;
            Assert.AreEqual(2, taskConfiguration.WeeklyTasks.Length);
            task.Execute(TaskType.Weekly);
            Assert.AreEqual(1, taskConfiguration.WeeklyTasks.Length);
            Assert.AreEqual("user 2", taskConfiguration.WeeklyTasks[0].Username);
        }

        /// <summary>
        /// Add new weekly task.
        /// </summary>
        [Test]
        public void AddNew()
        {
            DateTime dateTime = new DateTime(DateTime.UtcNow.Ticks);
            ConsoleAppTasks task = new ConsoleAppTasks(new[] {"weekly", "add", "newuser", "1024000000"})
                                   {
                                       TaskConfiguration = new TaskConfiguration
                                                           {
                                                               WeeklyTasks = new[]
                                                                             {
                                                                                 new WeeklyTask
                                                                                 {
                                                                                     WeeklyTaskStatus = WeeklyTaskStatus.Enabled,
                                                                                     Uid = 1,
                                                                                     Username = "suer 1",
                                                                                     Creator = "test",
                                                                                     Credits = 1024,
                                                                                     Notes = "Just for fun!",
                                                                                     DateTimeStart = dateTime,
                                                                                     DateTimeStop = dateTime.AddYears(1),
                                                                                 },
                                                                                 new WeeklyTask
                                                                                 {
                                                                                     WeeklyTaskStatus = WeeklyTaskStatus.Enabled,
                                                                                     Username = "user 2",
                                                                                     Uid = 2,
                                                                                     Creator = "test 2",
                                                                                     Credits = 1024 * 1024 * 1024,
                                                                                     Notes = "Just for fun 2 !",
                                                                                     DateTimeStart = dateTime,
                                                                                     DateTimeStop = dateTime.AddYears(1),
                                                                                 },
                                                                             },
                                                           }
                                   };
            TaskConfiguration taskConfiguration = task.TaskConfiguration;
            Assert.AreEqual(2, taskConfiguration.WeeklyTasks.Length);
            task.Execute(TaskType.Weekly);
            Assert.AreEqual(3, taskConfiguration.WeeklyTasks.Length);
        }

        /// <summary>
        /// Get list of weekly tasks.
        /// </summary>
        [Test]
        public void List()
        {
            DateTime dateTime = new DateTime(DateTime.UtcNow.Ticks);
            ConsoleAppTasks task = new ConsoleAppTasks(new[] {"weekly"})
                                   {
                                       TaskConfiguration = new TaskConfiguration
                                                           {
                                                               WeeklyTasks = new[]
                                                                             {
                                                                                 new WeeklyTask
                                                                                 {
                                                                                     WeeklyTaskStatus = WeeklyTaskStatus.Enabled,
                                                                                     Uid = 1,
                                                                                     Username = "suer 1",
                                                                                     Creator = "test",
                                                                                     Credits = 1024,
                                                                                     Notes = "Just for fun!",
                                                                                     DateTimeStart = dateTime,
                                                                                     DateTimeStop = dateTime.AddYears(1),
                                                                                 },
                                                                                 new WeeklyTask
                                                                                 {
                                                                                     WeeklyTaskStatus = WeeklyTaskStatus.Enabled,
                                                                                     Username = "user 2",
                                                                                     Uid = 2,
                                                                                     Creator = "test 2",
                                                                                     Credits = 1024 * 1024 * 1024,
                                                                                     Notes = "Just for fun 2 !",
                                                                                     DateTimeStart = dateTime,
                                                                                     DateTimeStop = dateTime.AddYears(1),
                                                                                 },
                                                                             },
                                                           }
                                   };
            TaskConfiguration taskConfiguration = task.TaskConfiguration;
            Assert.AreEqual(2, taskConfiguration.WeeklyTasks.Length);
            task.Execute(TaskType.Weekly);
        }
    }
}
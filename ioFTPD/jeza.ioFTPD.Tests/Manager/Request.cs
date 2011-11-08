using System;
using System.IO;
using jeza.ioFTPD.Framework;
using jeza.ioFTPD.Framework.Manager;
using MbUnit.Framework;

namespace jeza.ioFTPD.Tests.Manager
{
    [TestFixture]
    public class Request
    {
        /// <summary>
        /// Gets the requests list.
        /// </summary>
        [Test]
        public void ListEmpty()
        {
            //DateTime dateTime = new DateTime(DateTime.UtcNow.Ticks);
            ConsoleAppTasks task = new ConsoleAppTasks(new[] {"listrequest"})
                                   {
                                       TaskConfiguration = new TaskConfiguration {WeeklyTasks = new WeeklyTask[] {}},
                                   };
            TaskConfiguration taskConfiguration = task.TaskConfiguration;
            Assert.IsNull(taskConfiguration.RequestTasks);
            task.Execute(TaskType.Request);
            Assert.IsNull(taskConfiguration.RequestTasks);
        }

        /// <summary>
        /// Gets the requests list.
        /// </summary>
        [Test]
        public void List()
        {
            DateTime dateTime = new DateTime(DateTime.UtcNow.Ticks);
            ConsoleAppTasks task = new ConsoleAppTasks(new[] {"listrequest"})
                                   {
                                       TaskConfiguration = new TaskConfiguration
                                                           {
                                                               RequestTasks = new[]
                                                                              {
                                                                                  new RequestTask
                                                                                  {
                                                                                      Creator = "testRequester",
                                                                                      DateAdded = dateTime,
                                                                                      Name = "Some.Stupid.Request With Spaces",
                                                                                  },
                                                                                  new RequestTask
                                                                                  {
                                                                                      Creator = "testRequester 2",
                                                                                      DateAdded = dateTime,
                                                                                      Name = "Some.Stupid.Request 2",
                                                                                  },
                                                                              },
                                                           }
                                   };
            TaskConfiguration taskConfiguration = task.TaskConfiguration;
            Assert.AreEqual(2, taskConfiguration.RequestTasks.Length);
            task.Execute(TaskType.Request);
            Assert.AreEqual(2, taskConfiguration.RequestTasks.Length);
        }

        /// <summary>
        /// Add new request.
        /// </summary>
        [Test]
        public void Add()
        {
            const string requestName = "some stupid request";
            string request = Path.Combine(Config.RequestFolder, Config.RequestPrefix + requestName);
            request.RemoveFolder();
            DateTime dateTime = new DateTime(DateTime.UtcNow.Ticks);
            ConsoleAppTasks task = new ConsoleAppTasks(new[] {"request", requestName})
                                   {
                                       TaskConfiguration = new TaskConfiguration
                                                           {
                                                               RequestTasks = new[]
                                                                              {
                                                                                  new RequestTask
                                                                                  {
                                                                                      Creator = "testRequester",
                                                                                      DateAdded = dateTime,
                                                                                      Name = "Some.Stupid.Request With Spaces",
                                                                                  },
                                                                                  new RequestTask
                                                                                  {
                                                                                      Creator = "testRequester 2",
                                                                                      DateAdded = dateTime,
                                                                                      Name = "Some.Stupid.Request 2",
                                                                                  },
                                                                              },
                                                           }
                                   };
            TaskConfiguration taskConfiguration = task.TaskConfiguration;
            Assert.AreEqual(2, taskConfiguration.RequestTasks.Length);
            task.Execute(TaskType.Request);
            Assert.AreEqual(3, taskConfiguration.RequestTasks.Length);
        }

        /// <summary>
        /// Delete request.
        /// </summary>
        [Test]
        public void Del()
        {
            DateTime dateTime = new DateTime(DateTime.UtcNow.Ticks);
            const string name = "Some.Stupid.Request With Spaces";
            ConsoleAppTasks task = new ConsoleAppTasks(new[] {"delrequest", name})
                                   {
                                       TaskConfiguration = new TaskConfiguration
                                                           {
                                                               RequestTasks = new[]
                                                                              {
                                                                                  new RequestTask
                                                                                  {
                                                                                      Creator = "testRequester",
                                                                                      DateAdded = dateTime,
                                                                                      Name = name,
                                                                                  },
                                                                                  new RequestTask
                                                                                  {
                                                                                      Creator = "testRequester 2",
                                                                                      DateAdded = dateTime,
                                                                                      Name = "Some.Stupid.Request 2",
                                                                                  },
                                                                              },
                                                           }
                                   };
            TaskConfiguration taskConfiguration = task.TaskConfiguration;
            Assert.AreEqual(2, taskConfiguration.RequestTasks.Length);
            task.Execute(TaskType.Request);
            Assert.AreEqual(1, taskConfiguration.RequestTasks.Length);
        }
    }
}
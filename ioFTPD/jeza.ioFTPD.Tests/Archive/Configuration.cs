using System.Collections.Generic;
using System.IO;
using jeza.ioFTPD.Framework;
using jeza.ioFTPD.Framework.Archive;
using NUnit.Framework;

namespace jeza.ioFTPD.Tests.Archive
{
    /// <summary>
    /// Serialization/deserialization of config.
    /// </summary>
    [TestFixture]
    public class Configuration
    {
        [Test]
        public void ReadIncludePatternFromFile()
        {
            SaveConfiguration();
            TaskConfiguration actualTaskConfiguration = Extensions.Deserialize(new TaskConfiguration(), ConfigurationFile, DefaultNamespace);
            ArchiveTask task = null;
            foreach (ArchiveTask archiveTask in actualTaskConfiguration.ArchiveTasks)
            {
                if (archiveTask.RegExpressionInclude != null)
                {
                    task = archiveTask;
                    break;
                }
            }
            DirectoryInfo directoryInfo = new DirectoryInfo(@"..\..\TestFiles\Archive\source");
            List<DirectoryInfo> folders = directoryInfo.GetFolders(task);
            const int expectedValue = 1;
            Assert.AreEqual(expectedValue, folders.Count);
        }

        /// <summary>
        /// Read the configuration.
        /// </summary>
        [Test]
        public void ReadConfiguration()
        {
            TaskConfiguration expectedTaskConfiguration = GetArchiveConfiguration();
            Extensions.Serialize(expectedTaskConfiguration, ConfigurationFile, DefaultNamespace);
            TaskConfiguration actualTaskConfiguration = Extensions.Deserialize(new TaskConfiguration(), ConfigurationFile, DefaultNamespace);
            Assert.AreEqual(expectedTaskConfiguration.ArchiveTasks [0].Action.Id, actualTaskConfiguration.ArchiveTasks [0].Action.Id, "Configuration missmatch!");
        }

        private TaskConfiguration GetArchiveConfiguration()
        {
            ArchiveTask task1 = new ArchiveTask
                                {
                                    ArchiveStatus = ArchiveStatus.Enabled,
                                    ArchiveType = ArchiveType.Move,
                                    Source = "C:\\temp",
                                    Destination = "D:\\temp",
                                    Action = new ArchiveAction
                                             {
                                                 Id = ArchiveActionAttribute.TotalUsedSpace,
                                                 Value = 120 * 1024 * 1024,
                                                 MinFolderAction = 10,
                                             },
                                };
            ArchiveTask task2 = new ArchiveTask
                                {
                                    ArchiveStatus = ArchiveStatus.Enabled,
                                    ArchiveType = ArchiveType.Delete,
                                    Source = "C:\\temp123",
                                    Destination = "D:\\temp123",
                                    Action = new ArchiveAction
                                             {
                                                 Id = ArchiveActionAttribute.TotalFolderCount,
                                                 Value = 999 * 1024 * 1024,
                                                 MinFolderAction = 5,
                                             },
                                };

            return new TaskConfiguration
                   {
                       ArchiveTasks = new[] {task1, task2, task3}
                   };
        }

        /// <summary>
        /// Save new configuration.
        /// </summary>
        [Test]
        public void SaveConfiguration()
        {
            TaskConfiguration taskConfiguration = GetArchiveConfiguration();
            Extensions.Serialize(taskConfiguration, ConfigurationFile, DefaultNamespace);
        }

        private readonly ArchiveTask task3 = new ArchiveTask
                                    {
                                        ArchiveStatus = ArchiveStatus.Enabled,
                                        ArchiveType = ArchiveType.Delete,
                                        RegExpressionInclude = @"\S*([Ss]targate|[Ss]tar[Tt]rek)\S*",
                                        RegExpressionExclude = @"\S*([Cc]aprica|[Ff]ringe)\S*",
                                        Source = "C:\\temp123asd",
                                        Destination = "D:\\temp123dsa",
                                        Action = new ArchiveAction
                                                 {
                                                     Id = ArchiveActionAttribute.TotalFolderCount,
                                                     Value = 999 * 1024 * 1024,
                                                     MinFolderAction = 5,
                                                 },
                                    };

        private const string ConfigurationFile = "testConfig.xml";
        private const string DefaultNamespace = Config.DefaultNamespace;
    }
}
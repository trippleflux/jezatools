using jeza.ioFTPD.Framework;
using MbUnit.Framework;

namespace jeza.ioFTPD.Tests.Archive
{
    /// <summary>
    /// Serialization/deserialization of config.
    /// </summary>
    [TestFixture]
    public class Configuration
    {
        /// <summary>
        /// Read the configuration.
        /// </summary>
        [Test]
        public void ReadConfiguration()
        {
            ArchiveConfiguration expectedArchiveConfiguration = GetArchiveConfiguration();
            Extensions.Serialize(expectedArchiveConfiguration, ConfigurationFile, DefaultNamespace);
            ArchiveConfiguration actualArchiveConfiguration = Extensions.Deserialize(new ArchiveConfiguration(), ConfigurationFile, DefaultNamespace);
            Assert.AreEqual(expectedArchiveConfiguration.ArchiveTasks [0].Action.Id, actualArchiveConfiguration.ArchiveTasks [0].Action.Id, "Configuration missmatch!");
        }

        private static ArchiveConfiguration GetArchiveConfiguration()
        {
            ArchiveTask task1 = new ArchiveTask
                                {
                                    ArchiveStatus = ArchiveStatus.Enabled,
                                    ArchiveType = ArchiveType.Move,
                                    SkipPattern = new[] {".", "_"},
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
                                    SkipPattern = null,
                                    Source = "C:\\temp123",
                                    Destination = "D:\\temp123",
                                    Action = new ArchiveAction
                                             {
                                                 Id = ArchiveActionAttribute.TotalFolderCount,
                                                 Value = 999 * 1024 * 1024,
                                                 MinFolderAction = 5,
                                             },
                                };
            return new ArchiveConfiguration
                   {
                       ArchiveTasks = new[] {task1, task2,}
                   };
        }

        /// <summary>
        /// Save new configuration.
        /// </summary>
        [Test]
        public void SaveConfiguration()
        {
            ArchiveConfiguration archiveConfiguration = GetArchiveConfiguration();
            Extensions.Serialize(archiveConfiguration, ConfigurationFile, DefaultNamespace);
        }

        private const string ConfigurationFile = "testConfig.xml";
        private const string DefaultNamespace = "http://jeza.ioFTPD.Tools/XMLSchema.xsd";
    }
}
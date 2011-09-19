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
            ArchiveTask archiveTask = new ArchiveTask
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
            return new ArchiveConfiguration {ArchiveTasks = new[] {archiveTask}};
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
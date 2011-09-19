using System;
using jeza.ioFTPD.Framework;

namespace jeza.ioFTPD.Archive
{
    public class ConsoleApp
    {
        public void ParseConfig()
        {
            configuration = Extensions.Deserialize(new ArchiveConfiguration(), ConfigurationFile, DefaultNamespace);
        }

        public void Execute()
        {
            foreach (ArchiveTask task in configuration.ArchiveTasks)
            {
                if (task.ArchiveStatus == ArchiveStatus.Enabled)
                {
                    switch(task.Action.Id)
                    {
                        case ArchiveActionAttribute.DateOlder:
                        {
                            throw new NotImplementedException();
                            break;
                        }
                        case ArchiveActionAttribute.TotalFolderCount:
                        {
                            throw new NotImplementedException();
                            break;
                        }
                        case ArchiveActionAttribute.TotalFreeSpace:
                        {
                            throw new NotImplementedException();
                            break;
                        }
                        case ArchiveActionAttribute.TotalUsedSpace:
                        {
                            throw new NotImplementedException();
                            break;
                        }
                        default:
                        {
                            throw new NotSupportedException();
                        }
                    }
                }
                else
                {
                    Log.Debug("Task '{0}' is disabled!", task.ToString());
                }
            }
        }

        private ArchiveConfiguration configuration;
        private const string ConfigurationFile = "archiveConfiguration.xml";
        private const string DefaultNamespace = "http://jeza.ioFTPD.Tools/XMLSchema.xsd";
    }
}
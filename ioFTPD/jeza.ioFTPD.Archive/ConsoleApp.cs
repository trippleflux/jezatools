using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using jeza.ioFTPD.Framework;

namespace jeza.ioFTPD.Archive
{
    public class ConsoleApp
    {
        public void ParseConfig()
        {
            configuration = Extensions.Deserialize(new ArchiveConfiguration(), ConfigurationFile, DefaultNamespace);
            if (configuration == null)
            {
                throw new ConfigurationErrorsException("Failed to load configuration!");
            }
        }

        public void Execute()
        {
            foreach (ArchiveTask task in configuration.ArchiveTasks)
            {
                if (task.ArchiveStatus == ArchiveStatus.Enabled)
                {
                    Log.Debug("Starting with task '{0}'!", task.ToString());
                    DirectoryInfo sourceFolder;
                    try
                    {
                        sourceFolder = new DirectoryInfo(task.Source);
                    }
                    catch (Exception exception)
                    {
                        Log.Debug(exception.StackTrace);
                        throw;
                    }
                    List<DirectoryInfo> sourceFolders = sourceFolder.GetFolders(task);
                    if (task.Action.MinFolderAction > sourceFolders.Count)
                    {
                        Log.Debug("Skiping task because of MinFolderAction > ActualFodlersCount! '{0}' :: {1}", task.Action.MinFolderAction, sourceFolders.Count);
                        continue;
                    }
                    switch (task.Action.Id)
                    {
                        case ArchiveActionAttribute.DateOlder:
                        {
                            foreach (DirectoryInfo directoryInfo in sourceFolders)
                            {
                                DateTime dateTime = new DateTime(DateTime.UtcNow.Ticks);
                                DateTime creationTimeUtc = directoryInfo.CreationTimeUtc;
                                TimeSpan timeSpan = dateTime - creationTimeUtc;
                                if ((UInt64) timeSpan.Days > task.Action.Value)
                                {
                                    ExecuteArchiveTask(task, directoryInfo);
                                }
                            }
                            break;
                        }
                        case ArchiveActionAttribute.TotalFolderCount:
                        {
                            if ((UInt64) sourceFolders.Count > task.Action.Value)
                            {
                                ExecuteArchiveTask(task, sourceFolders);
                            }
                            break;
                        }
                        case ArchiveActionAttribute.TotalFreeSpace:
                        {
                            ManageDiskSpace(task, sourceFolders);
                            break;
                        }
                        case ArchiveActionAttribute.TotalUsedSpace:
                        {
                            ManageDiskSpace(task, sourceFolders);
                            break;
                        }
                        case ArchiveActionAttribute.TotalFolderUsedSpace:
                        {
                            UInt64 totalFolderSize = 0;
                            foreach (DirectoryInfo directoryInfo in sourceFolders)
                            {
                                totalFolderSize += directoryInfo.GetFolderSize();
                            }
                            if (totalFolderSize > task.Action.Value)
                            {
                                ExecuteArchiveTask(task, sourceFolders);
                            }
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

        private void ManageDiskSpace(ArchiveTask task,
                                     List<DirectoryInfo> sourceFolders)
        {
            DriveInfo[] driveInfos = DriveInfo.GetDrives();
            foreach (DriveInfo driveInfo in driveInfos)
            {
                if (task.Source.ToUpper().StartsWith(driveInfo.Name.ToUpper()))
                {
                    if (task.Action.Id == ArchiveActionAttribute.TotalFreeSpace)
                    {
                        if ((UInt64) driveInfo.AvailableFreeSpace < task.Action.Value)
                        {
                            ExecuteArchiveTask(task, sourceFolders);
                        }
                    }
                    if (task.Action.Id == ArchiveActionAttribute.TotalUsedSpace)
                    {
                        UInt64 usedSpace = (UInt64) driveInfo.TotalSize - (UInt64) driveInfo.TotalFreeSpace;
                        if (usedSpace > task.Action.Value)
                        {
                            ExecuteArchiveTask(task, sourceFolders);
                        }
                    }
                }
            }
        }

        private static void ExecuteArchiveTask(ArchiveTask archiveTask,
                                        List<DirectoryInfo> sourceFolders)
        {
            int currentFolderCount = sourceFolders.Count;
            int minFolderCountToKeep = archiveTask.Action.MinFolderAction;
            int howManyToRemove = currentFolderCount - minFolderCountToKeep;
            DirectoryInfo[] directoryInfos = sourceFolders.ToArray();
            Array.Sort(directoryInfos, new CompareDirectoryByDate());
            for (int i = 0; i < howManyToRemove; i++)
            {
                ExecuteArchiveTask(archiveTask, directoryInfos [i]);
            }
        }

        /// <summary>
        /// Executes the archive task (Move or Delete).
        /// </summary>
        /// <param name="archiveTask">The archive task.</param>
        /// <param name="directoryInfo">Source directory.</param>
        private static void ExecuteArchiveTask(ArchiveTask archiveTask,
                                               DirectoryInfo directoryInfo)
        {
            Log.Debug("ExecuteArchiveTask '{0}' on '{1}'!", archiveTask.ToString(), directoryInfo.FullName);
            switch (archiveTask.ArchiveType)
            {
                case ArchiveType.Copy:
                {
                    CopySourceFolders(archiveTask, directoryInfo);
                    break;
                }
                case ArchiveType.Move:
                {
                    CopySourceFolders(archiveTask, directoryInfo);
                    DeleteFolder(directoryInfo, true);
                    break;
                }
                case ArchiveType.Delete:
                {
                    DeleteFolder(directoryInfo, true);
                    break;
                }
                default:
                {
                    throw new NotSupportedException();
                }
            }
        }

        private static void DeleteFolder(DirectoryInfo directoryInfo,
                                         bool recursive)
        {
            directoryInfo.Delete(recursive);
        }

        private static void CopySourceFolders(ArchiveTask archiveTask,
                                              DirectoryInfo directoryInfo)
        {
            DirectoryInfo destinationDirectoryInfo = new DirectoryInfo(archiveTask.Destination);
            directoryInfo.CopyTo(destinationDirectoryInfo, true);
        }

        private ArchiveConfiguration configuration;
        private const string ConfigurationFile = "archiveConfiguration.xml";
        private const string DefaultNamespace = "http://jeza.ioFTPD.Tools/XMLSchema.xsd";
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using jeza.ioFTPD.Framework.Archive;
using jeza.ioFTPD.Framework.Manager;

namespace jeza.ioFTPD.Framework
{
    public class ConsoleAppTasks
    {
        public ConsoleAppTasks()
        {
        }

        public ConsoleAppTasks(string[] args)
        {
            this.args = args;
        }

        public void ParseConfig()
        {
            GetExecutionPath();
            taskConfiguration = Extensions.Deserialize(new TaskConfiguration(), configurationFileName, DefaultNamespace);
            if (taskConfiguration == null)
            {
                throw new ConfigurationErrorsException("Failed to load TaskConfiguration!");
            }
        }

        public void GetExecutionPath()
        {
            string codeBase = Assembly.GetExecutingAssembly().Location;
            Log.Debug("Assembly.GetExecutingAssembly().Location: ['{0}']", codeBase);
// ReSharper disable AssignNullToNotNullAttribute
            configurationFileName = Path.Combine(Path.GetDirectoryName(codeBase), configurationFile);
// ReSharper restore AssignNullToNotNullAttribute
        }

        public int Execute(TaskType taskType)
        {
            switch (taskType)
            {
                case TaskType.Archive:
                {
                    ExecuteArchiveTasks();
                    break;
                }
                case TaskType.NewDay:
                {
                    ExecuteNewDayTask();
                    break;
                }
                case TaskType.Weekly:
                {
                    ExecuteWeeklyTask();
                    break;
                }
                case TaskType.Request:
                {
                    ExecuteRequestTask();
                    break;
                }
                case TaskType.DupeNewDir:
                {
                    return ExecuteDupeNewDirTask() ? Constants.CodeOk : Constants.CodeFail;
                }
                case TaskType.DupeDelDir:
                {
                    return ExecuteDupeDelDirTask() ? Constants.CodeOk : Constants.CodeFail;
                }
                default:
                {
                    throw new NotSupportedException("Unknown TaskType");
                }
            }
            return Constants.CodeOk;
        }

        private bool ExecuteDupeNewDirTask()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(args [1]);
            string releaseName = directoryInfo.Name;
            DataBaseDupe dataBaseDupe = DataBase.SelectFromDupe(String.Format("SELECT * FROM Folders WHERE ReleaseName = '{0}'", releaseName));
            if (dataBaseDupe == null)
            {
                string userName = IoEnvironment.GetUserName();
                string groupName = IoEnvironment.GetGroupName();
                string insertCommand = String.Format(@"INSERT INTO Folders (UserName, GroupName, PathReal, PathVirtual, ReleaseName) VALUES('{0}', '{1}', '{2}', '{3}', '{4}')", userName, groupName, args [1], args [2], releaseName);
                int rows = DataBase.Insert(insertCommand);
                if (rows > 0)
                {
                    Log.Debug("INSERT new DUPE '{0}'", insertCommand);
                    return true;
                }
                Log.Debug("INSERT of new DUPE FAILED! '{0}'", insertCommand);
                return false;
            }
            Log.Debug("New dir is a dupe of '{0}'", dataBaseDupe.ToString());
            Output output = new Output();
            output.Client(output.FormatDupe(Config.ClientDupeNewDir, dataBaseDupe));
            return false;
        }

        private bool ExecuteDupeDelDirTask()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(args [1]);
            string releaseName = directoryInfo.Name;
            DataBaseDupe dataBaseDupe = DataBase.SelectFromDupe(String.Format("SELECT * FROM Folders WHERE ReleaseName = '{0}'", releaseName));
            if (dataBaseDupe == null)
            {
                return true;
            }
            Log.Debug("Removing dupe '{0}'", dataBaseDupe.ToString());
            string deleteCommand = String.Format(@"DELETE FROM Folders WHERE ReleaseName = '{0}'", releaseName);
            int rows = DataBase.ExecuteNonQuery(deleteCommand);
            if (rows > 0)
            {
                Log.Debug("Removed dupe");
                return true;
            }
            Log.Debug("DELETE of DUPE FAILED! '{0}'", deleteCommand);
            return false;
        }

        private void ExecuteRequestTask()
        {
            if (args.Length < 2)
            {
                OutputRequestList();
                return;
            }
            if (args [0].ToLowerInvariant().Equals(Constants.RequestAdd))
            {
                string requestName = args [1];
                Log.Debug("REQUEST ADD '{0}'", requestName);
                string request = Path.Combine(Config.RequestFolder, Config.RequestPrefix + requestName);
                if (!request.DirectoryExists())
                {
                    string creator = IoEnvironment.GetUserName();
                    DateTime dateTime = new DateTime(DateTime.UtcNow.Ticks);
                    RequestTask requestTask = new RequestTask
                                              {
                                                  Creator = creator,
                                                  DateAdded = dateTime,
                                                  Name = requestName,
                                              };
                    if (taskConfiguration.RequestTasks != null)
                    {
                        List<RequestTask> requestTasks = taskConfiguration.RequestTasks.ToList();
                        requestTasks.Add(requestTask);
                        taskConfiguration.RequestTasks = requestTasks.ToArray();
                    }
                    else
                    {
                        taskConfiguration.RequestTasks = new[] {requestTask};
                    }
                    SaveConfiguration();
                    FileInfo.CreateFolder(request);
                }
                else
                {
                    Log.Debug("REQUEST allready exists!");
                }
                return;
            }
            if (args [0].ToLowerInvariant().Equals(Constants.RequestDel))
            {
                string requestName = args [1];
                Log.Debug("REQUEST DEL '{0}'", requestName);
                string request = Path.Combine(Config.RequestFolder, Config.RequestPrefix + requestName);
                if (taskConfiguration.RequestTasks != null)
                {
                    List<RequestTask> requestTasks = taskConfiguration.RequestTasks.ToList();
                    RequestTask reqTask = requestTasks.Find(task => task.Name == requestName);
                    if (reqTask != null)
                    {
                        requestTasks.Remove(reqTask);
                    }
                    taskConfiguration.RequestTasks = requestTasks.ToArray();
                    SaveConfiguration();
                }
                if (request.DirectoryExists())
                {
                    request.KickUsersFromDirectory();
                    request.RemoveFolder();
                }
                return;
            }
            if (args [0].ToLowerInvariant().Equals(Constants.RequestFill))
            {
                string requestName = args [1];
                Log.Debug("REQUEST FILL '{0}'", requestName);
                string request = Path.Combine(Config.RequestFolder, Config.RequestPrefix + requestName);
                if (request.DirectoryExists())
                {
                    if (taskConfiguration.RequestTasks != null)
                    {
                        List<RequestTask> requestTasks = taskConfiguration.RequestTasks.ToList();
                        RequestTask reqTask = requestTasks.Find(task => task.Name == requestName);
                        if (reqTask != null)
                        {
                            requestTasks.Remove(reqTask);
                        }
                        taskConfiguration.RequestTasks = requestTasks.ToArray();
                        SaveConfiguration();
                    }
                    request.KickUsersFromDirectory();
                    Directory.Move(request, Path.Combine(Config.RequestFolder, Config.RequestFilled + requestName));
                }
                return;
            }
        }

        private void SaveConfiguration()
        {
            //TODO: create backup
            Extensions.Serialize(taskConfiguration, configurationFileName, DefaultNamespace);
        }

        private void OutputRequestList()
        {
            Output output = new Output();
            output.Client(output.FormatNone(Config.ClientRequestHead));
            if (taskConfiguration.RequestTasks != null)
            {
                foreach (RequestTask requestTask in taskConfiguration.RequestTasks)
                {
                    output.Client(output.FormatRequestTask(Config.ClientRequestBody, requestTask));
                }
            }
            output.Client(output.FormatNone(Config.ClientRequestFoot));
        }

        private void ExecuteWeeklyTask()
        {
            if (args.Length < 2)
            {
                OutputWeeklyTaskList();
                return;
            }
            switch (args [1].ToLowerInvariant())
            {
                case Constants.WeeklyAdd:
                {
                    if (args.Length < 4)
                    {
                        OutputWeeklyTaskList();
                    }
                    string username = args [2];
                    UInt64 amount = (UInt64) Misc.String2Number(args [3]);
                    string creator = IoEnvironment.GetUserName();
                    DateTime dateTime = new DateTime(DateTime.UtcNow.Ticks);
                    WeeklyTask newWeeklyTask = new WeeklyTask
                                               {
                                                   Creator = creator,
                                                   Uid = 0, //TODO: get UID from username
                                                   Credits = amount,
                                                   Username = username,
                                                   WeeklyTaskStatus = WeeklyTaskStatus.Enabled,
                                                   Notes = amount.FormatSize() + " From " + creator,
                                                   DateTimeStart = dateTime,
                                                   DateTimeStop = dateTime.AddYears(1),
                                               };
                    List<WeeklyTask> weeklyTasks = taskConfiguration.WeeklyTasks.ToList();
                    weeklyTasks.Add(newWeeklyTask);
                    taskConfiguration.WeeklyTasks = weeklyTasks.ToArray();
                    SaveConfiguration();
                    break;
                }
                case Constants.WeeklyDel:
                {
                    if (args.Length < 3)
                    {
                        OutputWeeklyTaskList();
                    }
                    string username = args [2];
                    List<WeeklyTask> weeklyTasks = taskConfiguration.WeeklyTasks.ToList();
                    List<WeeklyTask> list = weeklyTasks.FindAll(task => task.Username == username);
                    foreach (WeeklyTask weeklyTask in list)
                    {
                        weeklyTasks.Remove(weeklyTask);
                    }
                    taskConfiguration.WeeklyTasks = weeklyTasks.ToArray();
                    SaveConfiguration();
                    break;
                }
                case Constants.WeeklyCheck:
                {
                    List<WeeklyTask> weeklyTasks = taskConfiguration.WeeklyTasks.ToList();
                    DateTime dateTime = new DateTime(DateTime.UtcNow.Ticks);
                    foreach (WeeklyTask weeklyTask in weeklyTasks.Where(weeklyTask => weeklyTask.WeeklyTaskStatus == WeeklyTaskStatus.Enabled))
                    {
                        if (weeklyTask.DateTimeStop < dateTime)
                        {
                            weeklyTask.WeeklyTaskStatus = WeeklyTaskStatus.Disabled;
                        }
                        else
                        {
                            Misc.ExecuteSiteCommand(String.Format("{0} credits {1}", weeklyTask.Username, weeklyTask.Credits));
                        }
                    }
                    taskConfiguration.WeeklyTasks = weeklyTasks.ToArray();
                    SaveConfiguration();
                    break;
                }
                default:
                {
                    break;
                }
            }
        }

        private void OutputWeeklyTaskList()
        {
            Output output = new Output();
            foreach (WeeklyTask weeklyTask in taskConfiguration.WeeklyTasks)
            {
                output.Client(output.FormatWeeklyTask(Config.ClientWeeklyList, weeklyTask));
            }
        }

        private void ExecuteNewDayTask()
        {
            foreach (NewDayTask task in taskConfiguration.NewDayTasks)
            {
                if (task.Status == NewDayTaskStatus.Enabled)
                {
                    Log.Debug("Starting with task: ['{0}']", task.ToString());
                    DirectoryInfo sourceFolder;
                    try
                    {
                        sourceFolder = new DirectoryInfo(task.RealPath);
                    }
                    catch (Exception exception)
                    {
                        Log.Debug(exception.StackTrace);
                        throw;
                    }
                    //DateTime dateTime = new DateTime(DateTime.UtcNow.Ticks);
                    DateTime dateTime = new DateTime(DateTime.UtcNow.Ticks).AddNextDate();
                    string folderName = dateTime.GetNewDayFolderFormat(task);
                    string newDayFolder = Path.Combine(sourceFolder.FullName, folderName);
                    FileInfo.CreateFolder(newDayFolder);
                    if (!String.IsNullOrEmpty(task.Symlink))
                    {
                        FileInfo.CreateFolder(task.Symlink);
                        Misc.CreateSymlink(task.Symlink, task.VirtualPath + folderName);
                        Misc.ChangeVfs(task.Symlink, task.Mode, task.UserId, task.GroupId);
                    }
                    Log.IoFtpd(String.Format(task.LogFormat, task.VirtualPath + folderName, newDayFolder));
                }
                else
                {
                    Log.Debug("Task '{0}' is disabled!", task.ToString());
                }
            }
        }

        private void ExecuteArchiveTasks()
        {
            foreach (ArchiveTask task in taskConfiguration.ArchiveTasks)
            {
                if (task.ArchiveStatus == ArchiveStatus.Enabled)
                {
                    Log.Debug("Starting with task: ['{0}']", task.ToString());
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
                            UInt64 totalFolderSize = sourceFolders.Aggregate<DirectoryInfo, ulong>(0, (current,
                                                                                                       directoryInfo) => current + directoryInfo.GetFolderSize());
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
                    Log.Debug("Task is disabled! ['{0}']", task.ToString());
                }
            }
        }

        private static void ManageDiskSpace(ArchiveTask task,
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
            Log.Debug("ExecuteArchiveTask '{0}' on '{1}'!", archiveTask.Action.Id, directoryInfo.FullName);
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
            Log.Debug("Deleting '{0}'", directoryInfo.FullName);
            directoryInfo.FullName.KickUsersFromDirectory();
            directoryInfo.Delete(recursive);
        }

        private static void CopySourceFolders(ArchiveTask archiveTask,
                                              DirectoryInfo directoryInfo)
        {
            DirectoryInfo destinationDirectoryInfo = new DirectoryInfo(archiveTask.Destination);
            const string ioftpd = ".ioFTPD";
            const string ioftpdBackup = ".backup";
            string sourceFileName = Path.Combine(directoryInfo.FullName, ioftpd);
            if (File.Exists(sourceFileName))
            {
                string backupSource = sourceFileName + ioftpdBackup;
                FileInfo.DeleteFile(backupSource);
                File.Move(sourceFileName, backupSource);
            }
            string destinationFolder = Path.Combine(destinationDirectoryInfo.FullName, directoryInfo.Name);
            directoryInfo.CopyTo(new DirectoryInfo(destinationFolder), true);
            string destinationFileName = Path.Combine(destinationFolder, ioftpd + ioftpdBackup);
            if (File.Exists(destinationFileName))
            {
                string backupDestination = Path.Combine(destinationFolder, ioftpd);
                FileInfo.DeleteFile(backupDestination);
                File.Move(destinationFileName, backupDestination);
            }
        }

        private TaskConfiguration taskConfiguration;

        public TaskConfiguration TaskConfiguration
        {
            get { return taskConfiguration; }
            set { taskConfiguration = value; }
        }

        private readonly string configurationFile = Config.GetKeyValue("FileNameConfiguration");
        private readonly string[] args;
        private string configurationFileName = "testConfig.xml";

        private const string DefaultNamespace = Config.DefaultNamespace;
    }
}
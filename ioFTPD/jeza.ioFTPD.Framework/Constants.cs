using System;

namespace jeza.ioFTPD.Framework
{
    public static class Constants
    {
        /// <summary>
        /// The root element name in all XML configuration files (Archive, Manager,...).
        /// </summary>
        public const string XmlRootElementForConfiguration = "tasks";

        public const string XmlElementNameArchiveTask = "task";
        public const string XmlElementNameArchiveTaskType = "actionType";
        public const string XmlElementNameArchiveTaskStatus = "status";
        public const string XmlElementNameArchiveTaskRegExExclude = "regExpressionExclude";
        public const string XmlElementNameArchiveTaskRegExInclude = "regExpressionInclude";
        public const string XmlElementNameArchiveTaskSource = "source";
        public const string XmlElementNameArchiveTaskDestination = "destination";
        public const string XmlElementNameArchiveTaskAction = "action";
        public const string XmlElementNameArchiveTaskActionId = "id";
        public const string XmlElementNameArchiveTaskActionValue = "value";
        public const string XmlElementNameArchiveTaskActionMinFolder = "minFolderAction";

        public const string XmlElementNameWeeklyTask = "weeklyTask";
        public const string XmlElementNameWeeklyTaskStatus = "status";
        public const string XmlElementNameWeeklyTaskUserId = "userId";
        public const string XmlElementNameWeeklyTaskUserName = "userName";
        public const string XmlElementNameWeeklyTaskCredits = "credits";
        public const string XmlElementNameWeeklyTaskNotes = "notes";
        public const string XmlElementNameWeeklyTaskCreator = "creator";
        public const string XmlElementNameWeeklyTaskDateTimeStart = "dateTimeStart";
        public const string XmlElementNameWeeklyTaskDateTimeStop = "dateTimeStop";

        public const string XmlElementNameNewDayTask = "newDayTask";
        public const string XmlElementNameNewDayTaskStatus = "status";
        public const string XmlElementNameNewDayTaskType = "type";
        public const string XmlElementNameNewDayTaskRealPath = "realPath";
        public const string XmlElementNameNewDayTaskVirtualPath = "virtualPath";
        public const string XmlElementNameNewDayTaskFolderFormat = "format";
        public const string XmlElementNameNewDayTaskSymlink = "symlink";
        public const string XmlElementNameNewDayTaskMode = "mode";
        public const string XmlElementNameNewDayTaskUserId = "uid";
        public const string XmlElementNameNewDayTaskGroupId = "gid";
        public const string XmlElementNameNewDayTaskCultureInfo = "cultureInfo";
        public const string XmlElementNameNewDayTaskFirstDayOfWeek = "firstDayOfWeek";
        public const string XmlElementNameNewDayTaskLogFormat = "logFormat";

        public const string XmlElementNameRequestTask = "requestTask";
        public const string XmlElementNameRequestTaskName = "name";
        public const string XmlElementNameRequestTaskDateAdded = "dateAdded";
        public const string XmlElementNameRequestTaskCreator = "creator";
        public const string XmlElementNameRequestTaskGroupname = "groupname";

        public const string CodeIrcBold = "\\002";
        public const string CodeIrcUnderline = "\\037";
        public const string CodeIrcColor = "\\003";
        public static readonly string CodeNewLine = Environment.NewLine;
        
        public const string RequestAdd = "request";
        public const string RequestDel = "delrequest";
        public const string RequestFill = "fillrequest";

        public const string WeeklyAdd = "add";
        public const string WeeklyDel = "del";
        public const string WeeklyCheck = "check";

        public const int CodeOk = 0;
        public const int CodeFail = 1;
    
    }
}
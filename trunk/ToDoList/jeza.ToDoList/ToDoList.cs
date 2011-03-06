using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Google.GData.Calendar;
using log4net;

namespace jeza.ToDoList
{
    public class ToDoList
    {
        private const string XmlFileTasks = "XMLFileTasks.xml";
        private const string XmlFileSettings = "XMLFileSettings.xml";
        private static readonly ILog Log = LogManager.GetLogger(typeof (ToDoList));

        /// <summary>
        /// Initializes a new instance of the <see cref="ToDoList"/> class and add google accounts from settings file.
        /// </summary>
        public ToDoList()
        {
            TaskList = new List<Task>();
            GoogleAccounts = new List<GoogleAccountInfo>();
            //if (File.Exists(XmlFileTasks))
            //{
            //    TaskList.AddRange(Misc.Deserialize<List<Task>>(XmlFileTasks));
            //}
            AddGoogleAccounts();
            //AddGoogleTasks();
        }

        public List<Task> TaskList { get; set; }
        public List<GoogleAccountInfo> GoogleAccounts { get; set; }

        public void ShowTasksToConsole()
        {
            foreach (Task task in TaskList)
            {
                Console.WriteLine(task.ToString());
            }
        }

        private void AddGoogleAccounts()
        {
            Settings settings = Misc.Deserialize<Settings>(XmlFileSettings);
            if (settings != null)
            {
                ClearGoogleAccounts();
                foreach (GoogleAccountInfo googleAccountInfo in settings.GoogleAccount)
                {
                    GoogleAccounts.Add(googleAccountInfo);
                    Log.DebugFormat("Added new Google Account: {0}",googleAccountInfo);
                }
            }
        }

        private void ClearGoogleAccounts()
        {
            GoogleAccounts.Clear();
        }

        public void AddGoogleTasks()
        {
            ClearTasks();
            CalendarService service = new CalendarService("googleApp");
            foreach (GoogleAccountInfo googleAccountInfo in GoogleAccounts)
            {
                Log.InfoFormat("Fetching google account : {0}", googleAccountInfo.ToString());
                service.setUserCredentials(googleAccountInfo.Username, googleAccountInfo.Password);
                string queryUri = String.Format(CultureInfo.InvariantCulture,
                                                "http://www.google.com/calendar/feeds/{0}/private/full",
                                                service.Credentials.Username);
                Log.DebugFormat("Query='{0}'", queryUri);
                EventQuery eventQuery = new EventQuery(queryUri);
                try
                {
                    EventFeed eventFeed = service.Query(eventQuery);
                    foreach (EventEntry eventEntry in eventFeed.Entries.Cast<EventEntry>())
                    {
                        if (eventEntry.Times.Count > 0)
                        {
                            Task task = new Task
                                        {
                                            Id = eventEntry.EventId,
                                            Head = eventEntry.Title.Text,
                                            Description = eventEntry.Content.Content,
                                            StartDate = eventEntry.Times.First().StartTime,
                                            StopDate = eventEntry.Times.First().EndTime,
                                            Notes = googleAccountInfo.Title,
                                            GoogleAccount = googleAccountInfo,
                                            Location = eventEntry.Locations.FirstOrDefault().ValueString,
                                        };
                            AddTask(task);
                        }
                    }
                }
                catch (Exception exception)
                {
                    Log.ErrorFormat(exception.Message);
                    Log.ErrorFormat(exception.StackTrace);
                    Console.WriteLine(exception.ToString());
                }
            }
            ToString();
        }

        private void ClearTasks()
        {
            Log.Debug("ClearTasks");
            TaskList.Clear();
        }

        public bool AddTask(Task task)
        {
            if (TaskList.Contains(task))
            {
                return false;
            }
            TaskList.Add(task);
            Misc.Serialize(TaskList, XmlFileTasks);
            Log.DebugFormat("Added new task : {0}", task);
            return true;
        }

        private bool RemoveTask(Task task)
        {
            if (TaskList.Contains(task))
            {
                TaskList.Remove(task);
                Misc.Serialize(TaskList, XmlFileTasks);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Task task in TaskList)
            {
                stringBuilder.AppendLine(task.ToString());
            }
            return String.Format("TaskList:\r\n{0}", stringBuilder);
        }
    }
}
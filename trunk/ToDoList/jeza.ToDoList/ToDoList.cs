using System.Collections.Generic;
using System.IO;
using System.Linq;
using Google.GData.Calendar;

namespace jeza.ToDoList
{
    public class ToDoList
    {
        private const string XmlFileTasks = "XMLFileTasks.xml";
        private const string XmlFileSettings = "XMLFileSettings.xml";

        public ToDoList()
        {
            TaskList = new List<Task>();
            if (File.Exists(XmlFileTasks))
            {
                TaskList.AddRange(Misc.Deserialize<List<Task>>(XmlFileTasks));
            }
            AddGoogleTasks();
        }

        public List<Task> TaskList { get; set; }

        public void ShowTasks()
        {
            foreach (Task task in TaskList)
            {
                System.Console.WriteLine(task.ToString());
            }
        }

        public void AddGoogleTasks()
        {
            CalendarService service = new CalendarService("googleApp");
            Settings settings = Misc.Deserialize<Settings>(XmlFileSettings);
            foreach (GoogleAccountInfo googleAccountInfo in settings.GoogleAccount)
            {
                service.setUserCredentials(googleAccountInfo.Username, googleAccountInfo.Password);
                EventQuery myQuery =
                    new EventQuery("http://www.google.com/calendar/feeds/" + service.Credentials.Username +
                                   "/private/full");
                EventFeed calFeed = service.Query(myQuery);
                foreach (EventEntry eventEntry in calFeed.Entries.Cast<EventEntry>())
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
                                        };
                        AddTask(task);
                    }
                }
            }
        }

        public bool AddTask(Task task)
        {
            if (TaskList.Contains(task))
            {
                return false;
            }
            TaskList.Add(task);
            Misc.Serialize(TaskList, XmlFileTasks);
            return true;
        }

        public bool RemoveTask(Task task)
        {
            if (TaskList.Contains(task))
            {
                TaskList.Remove(task);
                Misc.Serialize(TaskList, XmlFileTasks);
                return true;
            }
            return false;
        }
    }
}
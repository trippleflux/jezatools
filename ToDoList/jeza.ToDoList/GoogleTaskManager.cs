using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Google.GData.Calendar;
using Google.GData.Client;
using Google.GData.Extensions;
using log4net;

namespace jeza.ToDoList
{
    public class GoogleTaskManager : ITaskManager
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (ToDoList));
        public string ErrorMessage { get; set; }

        public string QueryUrl { get; set; }

        public List<Task> Query(IAccountInfo accountInfo)
        {
            ErrorMessage = String.Empty;
            CalendarService service = new CalendarService("googleCalendar");
            service.setUserCredentials(accountInfo.Username, accountInfo.Password);
            Log.InfoFormat("Fetching google account : [{0}]", accountInfo.ToString());
            string queryUri = String.Format(CultureInfo.InvariantCulture,
                                            "http://www.google.com/calendar/feeds/{0}/private/full",
                                            service.Credentials.Username);
            Log.DebugFormat("Query='{0}'", queryUri);
            EventQuery eventQuery = new EventQuery(queryUri);
            List<Task> tasks = new List<Task>();
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
                                        Notes = accountInfo.Title,
                                        AccountInfo = accountInfo,
                                        Location = eventEntry.Locations.FirstOrDefault().ValueString,
                                    };
                        tasks.Add(task);
                    }
                }
            }
            catch (Exception exception)
            {
                Log.ErrorFormat(exception.Message);
                Log.ErrorFormat(exception.ToString());
                ErrorMessage = exception.Message;
            }
            return tasks;
        }

        public bool Delete(Task task)
        {
            ErrorMessage = String.Empty;
            CalendarService service = new CalendarService("googleCalendar");
            service.setUserCredentials(task.AccountInfo.Username, task.AccountInfo.Password);
            Log.InfoFormat("Fetching google account : [{0}]", task.AccountInfo.ToString());
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
                        if (eventEntry.EventId == task.Id)
                        {
                            Log.InfoFormat("Deleting : [{0}]-[{1}]", eventEntry.EventId, eventEntry.Title);
                            eventEntry.Delete();
                            return true;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Log.ErrorFormat(exception.Message);
                Log.ErrorFormat(exception.ToString());
                ErrorMessage = exception.Message;
            }
            return false;
        }

        public bool Insert(Task task)
        {
            EventEntry eventEntry = new EventEntry
                                    {
                                        Title = {Text = task.Head},
                                        Content = {Content = task.Description,},
                                        Locations = {new Where("", "", task.Location)},
                                        Times = {new When(task.StartDate, task.StopDate)},
                                    };
            Log.InfoFormat("Inserting new entry to google : [{0}]", task.ToString());
            CalendarService service = new CalendarService("googleCalendarInsert");
            service.setUserCredentials(task.AccountInfo.Username, task.AccountInfo.Password);
            Uri postUri = new Uri("https://www.google.com/calendar/feeds/default/private/full");
            ErrorMessage = String.Empty;
            try
            {
                EventEntry createdEntry = service.Insert(postUri, eventEntry);
                return createdEntry != null;
            }
            catch (Exception exception)
            {
                Log.ErrorFormat(exception.Message);
                Log.ErrorFormat(exception.ToString());
                ErrorMessage = exception.Message;
            }
            return false;
        }

        public bool Update(Task task)
        {
            ErrorMessage = String.Empty;
            CalendarService service = new CalendarService("googleCalendar");
            service.setUserCredentials(task.AccountInfo.Username, task.AccountInfo.Password);
            Log.InfoFormat("Fetching google account : [{0}]", task.AccountInfo.ToString());
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
                        if (eventEntry.EventId == task.Id)
                        {
                            Log.InfoFormat("Updating : [{0}]-[{1}]", eventEntry.EventId, eventEntry.Title);
                            EventEntry eventEntryForUpdate = eventEntry;
                            eventEntryForUpdate.Title.Text = task.Head;
                            eventEntryForUpdate.Content.Content = task.Description;
                            eventEntryForUpdate.Locations.Clear();
                            eventEntryForUpdate.Locations.Add(new Where("", "", task.Location));
                            eventEntryForUpdate.Times.Clear();
                            eventEntryForUpdate.Times.Add(new When(task.StartDate, task.StopDate));
                            AtomEntry atomEntry = eventEntryForUpdate.Update();
                            //service.Update(eventEntryForUpdate);
                            return atomEntry != null;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Log.ErrorFormat(exception.Message);
                Log.ErrorFormat(exception.ToString());
                ErrorMessage = exception.Message;
            }
            return false;
        }
    }
}
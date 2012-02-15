using System;
using System.Collections.Generic;
using System.Text;
using log4net;

namespace jeza.ToDoList
{
    public class ToDoList
    {
        private const string XmlFileSettings = "XMLFileSettings.xml";
        private static readonly ILog Log = LogManager.GetLogger(typeof (ToDoList));
        public Dictionary<string, IAccountInfo> Errors = new Dictionary<string, IAccountInfo>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ToDoList"/> class and add accounts from settings file.
        /// </summary>
        public ToDoList()
        {
            TaskList = new List<Task>();
            Accounts = new List<IAccountInfo>();
            ParseAccounts();
        }

        public List<Task> TaskList { get; set; }
        public List<IAccountInfo> Accounts { get; set; }

        private void ParseAccounts()
        {
            Settings settings = Misc.Deserialize<Settings>(XmlFileSettings);
            if (settings != null)
            {
                ClearAccounts();
                foreach (AccountInfo accountInfo in settings.Account)
                {
                    Accounts.Add(accountInfo);
                    Log.DebugFormat("Added new Account: [{0}]", accountInfo);
                }
            }
        }

        public void FetchAccounts()
        {
            ClearErrors();
            ClearTaskList();
            ParseAccounts();
            FetchGoogleAccounts();
        }

        private void ClearTaskList()
        {
            TaskList.Clear();
        }

        private void FetchGoogleAccounts()
        {
            List<IAccountInfo> googleAccounts = Accounts.FindAll(acc => acc.Provider == AccountProvider.Google);
            foreach (IAccountInfo account in googleAccounts)
            {
                GoogleTaskManager taskManager = new GoogleTaskManager();
                List<Task> query = taskManager.Query(account);
                if (taskManager.ErrorMessage != String.Empty)
                {
                    Errors.Add(taskManager.ErrorMessage, account);
                    Accounts.Remove(account);
                }
                else
                {
                    TaskList.AddRange(query);
                }
            }
        }

        private void ClearAccounts()
        {
            Accounts.Clear();
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

        public bool Insert
            (string accountTitle,
             Task task)
        {
            IAccountInfo accountInfo =
                Accounts.Find(acc => (acc.Title == accountTitle && acc.Provider == AccountProvider.Google));
            if (accountInfo != null)
            {
                GoogleTaskManager googleTaskManager = new GoogleTaskManager();
                task.AccountInfo = accountInfo;
                bool insertSucess = googleTaskManager.Insert(task);
                ClearErrors();
                if (!insertSucess)
                {
                    Errors.Add(googleTaskManager.ErrorMessage, accountInfo);
                }
                return insertSucess;
            }
            return false;
        }

        private void ClearErrors()
        {
            Errors.Clear();
        }

        public bool Delete(Task task)
        {
            if (task.AccountInfo.Provider == AccountProvider.Google)
            {
                GoogleTaskManager googleTaskManager = new GoogleTaskManager();
                bool deleteSucess = googleTaskManager.Delete(task);
                if (!deleteSucess)
                {
                    Errors.Add(googleTaskManager.ErrorMessage, task.AccountInfo);
                }
                return deleteSucess;
            }
            return false;
        }

        public bool Update(Task task)
        {
            if (task.AccountInfo.Provider == AccountProvider.Google)
            {
                GoogleTaskManager googleTaskManager = new GoogleTaskManager();
                bool updateSucess = googleTaskManager.Update(task);
                if (!updateSucess)
                {
                    Errors.Add(googleTaskManager.ErrorMessage, task.AccountInfo);
                }
                return updateSucess;
            }
            return false;
        }
    }
}
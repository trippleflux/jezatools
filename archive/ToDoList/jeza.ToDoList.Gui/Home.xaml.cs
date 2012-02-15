using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace jeza.ToDoList.Gui
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home
    {
        private readonly ToDoList TodoList;
        private Task ActiveTask;

        public Home()
        {
            InitializeComponent();
            TodoList = new ToDoList();
            DisableButtons();
        }

        private void ButtonClick
            (object sender,
             RoutedEventArgs e)
        {
            UpdateFetch();
        }

        private void UpdateFetch()
        {
            DisableButtons();
            listViewDetails.Items.Clear();
            TodoList.FetchAccounts();
            foreach (Task task in TodoList.TaskList)
            {
                listViewDetails.Items.Add(task);
            }
            UpdateAccounts();
        }

        private void PageLoaded
            (object sender,
             RoutedEventArgs e)
        {
            UpdateAccounts();
        }

        private void UpdateAccounts()
        {
            accountsListBox.Items.Clear();
            foreach (IAccountInfo accountInfo in TodoList.Accounts)
            {
                accountsListBox.Items.Add(accountInfo.Title);
            }
        }

        private void listViewDetailsMouseDoubleClick
            (object sender,
             MouseButtonEventArgs e)
        {
            DependencyObject dep = (DependencyObject) e.OriginalSource;

            while ((dep != null) && !(dep is ListViewItem))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }

            if (dep == null)
            {
                return;
            }
            Task task = (Task) listViewDetails.ItemContainerGenerator.ItemFromContainer(dep);
            ActiveTask = task;
            textBoxHead.Text = task.Head;
            textBoxDescription.Text = task.Description;
            textBoxLocation.Text = task.Location;
            dateTimeStart.DateTimeSelected = task.StartDate;
            dateTimeStop.DateTimeSelected = task.StopDate;

            Insert.IsEnabled = false;
            Update.IsEnabled = true;
            Delete.IsEnabled = true;
        }

        private void AddClick
            (object sender,
             RoutedEventArgs e)
        {
            Insert.IsEnabled = true;
            Update.IsEnabled = false;
            Delete.IsEnabled = false;
            textBoxLocation.Text = "";
            textBoxHead.Text = "";
            textBoxDescription.Text = "";
            dateTimeStart.DateTimeSelected = new DateTime(DateTime.Now.Ticks);
            dateTimeStop.DateTimeSelected = new DateTime(DateTime.Now.Ticks).AddDays(1);
            ActiveTask = null;
        }

        private void UpdateClick
            (object sender,
             RoutedEventArgs e)
        {
            DisableButtons();
            if (ActiveTask == null)
            {
                MessageBox.Show("You can not see this message!");
            }
            else
            {
                Task task = ActiveTask;
                task.Location = textBoxLocation.Text;
                task.Head = textBoxHead.Text;
                task.Description = textBoxDescription.Text;
                task.StartDate = dateTimeStart.DateTimeSelected;
                task.StopDate = dateTimeStop.DateTimeSelected;
                TodoList.Update(task);
                UpdateFetch();
            }
        }

        private void DisableButtons()
        {
            Insert.IsEnabled = false;
            Update.IsEnabled = false;
            Delete.IsEnabled = false;
        }

        private void DeleteClick
            (object sender,
             RoutedEventArgs e)
        {
            DisableButtons();
            if (ActiveTask == null)
            {
                MessageBox.Show("You can not see this message!");
            }
            else
            {
                TodoList.Delete(ActiveTask);
                UpdateFetch();
            }
        }

        private void InsertClick
            (object sender,
             RoutedEventArgs e)
        {
            object selectedItem = accountsListBox.SelectedItem;
            if (selectedItem == null)
            {
                MessageBox.Show("Select the account first!");
            }
            else
            {
                DisableButtons();
                string accountTitle = selectedItem.ToString();
                Task task = new Task
                            {
                                Location = textBoxLocation.Text,
                                Head = textBoxHead.Text,
                                Description = textBoxDescription.Text,
                                StartDate = dateTimeStart.DateTimeSelected,
                                StopDate = dateTimeStop.DateTimeSelected,
                                Notes = accountTitle,
                            };

                bool insertSucess = TodoList.Insert(accountTitle, task);
                if (!insertSucess)
                {
                    MessageBox.Show("Failed to insert new entry!");
                }
                UpdateFetch();
            }
        }
    }
}
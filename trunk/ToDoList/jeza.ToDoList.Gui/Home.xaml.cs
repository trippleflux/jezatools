using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Windows.Controls;

namespace jeza.ToDoList.Gui
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        private readonly ToDoList TodoList;
        public Home()
        {
            InitializeComponent();
            TodoList = new ToDoList();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            listViewDetails.Items.Clear();
            TodoList.AddGoogleTasks();
            foreach (Task task in TodoList.TaskList)
            {
                listViewDetails.Items.Add(task);
            }
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            foreach (GoogleAccountInfo googleAccount in TodoList.GoogleAccounts)
            {
                googleAccountsListBox.Items.Add(googleAccount.Title);
            }
        }

        private void listViewDetailsMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;

            while ((dep != null) && !(dep is ListViewItem))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }

            if (dep == null)
                return;

            Task task = (Task)listViewDetails.ItemContainerGenerator.ItemFromContainer(dep);
            textBoxHead.Text = task.Head;
            textBoxDescription.Text = task.Description;
            textBoxLocation.Text = task.Location;
            dateTimeStart.DateTimeSelected = task.StartDate;
            dateTimeStop.DateTimeSelected = task.StopDate;
        }
    }
}

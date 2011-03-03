using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace jeza.ToDoList.Console
{
    internal class Program
    {
        private static readonly ToDoList ToDoList = new ToDoList();

        public static void Main(string[] args)
        {
            //ShowHelp();
            ShowTasks();
            string input;
            do
            {
                input = System.Console.ReadLine();
                if (input != null)
                    if (input == "list")
                    {
                        ShowTasks();
                    }
                    else if (input.StartsWith("+"))
                    {
                        if (input.IndexOf('|') > -1)
                        {
                            string[] split = input.Split('|');
                            if (split.Count() == 5)
                            {
                                Task xmlSchemaTask = new Task
                                                {
                                                    Id = Guid.NewGuid().ToString(),
                                                    StartDate = 
                                                        DateTime.Parse(split[1], CultureInfo.InvariantCulture,
                                                                       DateTimeStyles.AdjustToUniversal),
                                                    StopDate = 
                                                        DateTime.Parse(split[2], CultureInfo.InvariantCulture,
                                                                       DateTimeStyles.AdjustToUniversal),
                                                    Head = split[3],
                                                    Description = split[4],
                                                    Notes = "Task From User",
                                                };
                                ToDoList.AddTask(xmlSchemaTask);
                            }
                            else
                            {
                                ShowHelp();
                            }
                        }
                        else
                        {
                            ShowHelp();
                        }
                    }
            } while (input != "exit");
        }

        private static void ShowHelp()
        {
            System.Console.WriteLine("Usage:");
            System.Console.WriteLine("Add Task   : +|2011-03-12T12:30:45|2011-04-12T12:40:50|head 1|description 1 one bla bla ba");
            System.Console.WriteLine("Show Tasks : list");
            System.Console.WriteLine("Exit       : exit");
        }

        private static void ShowTasks()
        {
            ToDoList.ShowTasks();
        }
    }
}
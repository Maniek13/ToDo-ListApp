using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using ToDoList.Models;
using ToDoList.Views;

namespace ToDoList.ViewModels
{
    public sealed class ListOfTasksUserControlViewModel
    {
#pragma warning disable CS8601, CS8618
        private ObservableCollection<Task> _tasks {  get; set; }
#pragma warning restore S8601, CS8618
        public ObservableCollection<Task> Tasks { get { return _tasks; } }

        public void GetList()
        {
            _tasks = new ObservableCollection<Task>
            {
                new Task()
                {
                    Id = 1,
                    Name = "nowa"
                },
                new Task()
                {
                    Id = 2,
                    Name= "stara"
                }
            };
        }
    }
}

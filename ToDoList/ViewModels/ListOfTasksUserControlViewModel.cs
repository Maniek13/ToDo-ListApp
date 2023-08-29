using System;
using System.Collections.ObjectModel;
using ToDoList.Models;

namespace ToDoList.ViewModels
{
    public sealed class ListOfTasksUserControlViewModel
    {
        private ObservableCollection<Task> _tasks {  get; set; }
        public ObservableCollection<Task> Tasks { get { return _tasks; } }

        public ListOfTasksUserControlViewModel() 
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

        public void EditTask(Task task)
        {
            throw new NotImplementedException();
        }
    }
}

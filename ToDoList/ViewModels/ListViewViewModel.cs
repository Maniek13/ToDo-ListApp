using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using ToDoList.Models;

namespace ToDoList.ViewModels
{
    public sealed class ListViewViewModel
    {
        private ObservableCollection<Task> _tasks {  get; set; }
        public ObservableCollection<Task> Tasks { get { return _tasks; } }

        public ListViewViewModel() 
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

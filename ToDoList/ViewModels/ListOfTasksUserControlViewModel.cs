using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ToDoList.DbControler;
using ToDoList.Helper;
using ToDoList.Models;

namespace ToDoList.ViewModels
{
    public sealed class ListOfTasksUserControlViewModel
    {
        TaskDbControler taskDbControler = new();
#pragma warning disable CS8601, CS8618, IDE1006
        private ObservableCollection<Task> _tasks { get; set; }
#pragma warning restore S8601, CS8618, IDE1006
        public ObservableCollection<Task> Tasks { get { return _tasks; } }

        public void GetList()
        {
            List<Task> list = taskDbControler.GetAllTasks().Select(el => ConversionHelper.ConvertToTask(el)).ToList();
            _tasks = new ObservableCollection<Task>(list);
        }
    }
}

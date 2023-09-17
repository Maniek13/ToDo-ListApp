using System;
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
        readonly TaskDbControler taskDbControler = new();
        readonly ReminderDbControler reminderDbControler = new();

#pragma warning disable CS8601, CS8618, IDE1006
        private ObservableCollection<Task> _tasks { get; set; }
#pragma warning restore S8601, CS8618, IDE1006
        public ObservableCollection<Task> Tasks { get { return _tasks; } }

        public void GetList()
        {
            try
            {
                List<Task> list = taskDbControler.GetAllTasks().Select(el => ConversionHelper.ConvertToTask(el)).ToList();
                _tasks = new ObservableCollection<Task>(list);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public void DeleteTask(Task task)
        {
            try
            {
                taskDbControler.DeleteTask(task.Id);
                _tasks.Remove(task);

                if(task.HasReminder)
                {
                    var reminder = reminderDbControler.GetReminder(task.Id);

                    if(reminder != null)
                    {
                        TaskShulder taskShulder = new();
                        taskShulder.DeleteTaskShulder(reminder.Id, reminder.Date);
                    }
                }

              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}

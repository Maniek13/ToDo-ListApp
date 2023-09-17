using System;
using ToDoList.DbControler;
using ToDoList.Helper;
using ToDoList.Models;

namespace ToDoList.ViewModels
{
    public sealed class AddTaskUserControlViewModel
    {

        internal void AddTask(Task task, Reminder reminder = new Reminder())
        {
            try
            {
                CheckingValues.CheckTaskValues(task);
                if (task.HasReminder)
                {
                    TaskShulder taskShulder = new();
                    taskShulder.CreateTaskShulder(ConversionHelper.ConvertToDbReminder(reminder));
                }

                TaskDbControler taskDbControler = new();
                taskDbControler.AddTask(ConversionHelper.ConvertToDbTask(task));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

    }
}

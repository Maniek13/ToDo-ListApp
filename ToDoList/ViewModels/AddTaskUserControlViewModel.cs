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

                TaskDbControler taskDbControler = new();
                var taskId = taskDbControler.AddTask(ConversionHelper.ConvertToDbTask(task));


                if (task.HasReminder)
                {
                    reminder.TaskID = taskId;

                    TaskShulder taskShulder = new();
                    taskShulder.CreateTaskShulder(ConversionHelper.ConvertToDbReminder(reminder));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

    }
}

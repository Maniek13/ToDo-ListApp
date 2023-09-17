using System;
using ToDoList.DbControler;
using ToDoList.Helper;
using ToDoList.Models;

namespace ToDoList.ViewModels
{
    public sealed class EditTaskUserControlViewModel
    {

        internal void EditTask(Task task)
        {
            try
            {
                CheckingValues.CheckTaskValues(task);
                TaskDbControler taskDbControler = new();
                taskDbControler.EditTask(ConversionHelper.ConvertToDbTask(task));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        internal Reminder? GetReminderTask(int taskId)
        {
            try
            {
                ReminderDbControler reminderDbControler = new();
                var reminder = reminderDbControler.GetReminder(taskId);

                if(reminder != null)
                    return ConversionHelper.ConvertToReminder(reminder);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        internal void EditOrCreateReminder(int taskId, Reminder reminder, bool edit)
        {
            try
            {
                TaskShulder taskShulder = new();

                if (edit)
                    taskShulder.DeleteTaskShulder(taskId);


                reminder = reminder with { Id = 0 };
                taskShulder.CreateTaskShulder(ConversionHelper.ConvertToDbReminder(reminder));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}

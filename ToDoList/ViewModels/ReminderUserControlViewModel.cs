using Microsoft.Win32.TaskScheduler;
using System;
using System.Windows.Navigation;
using ToDoList.Helper;

namespace ToDoList.ViewModels
{
    internal class ReminderUserControlViewModel
    {
        internal void CreateReminder(string msg, DateTime date)
        {
            try
            {
                TaskShulder task = new TaskShulder();
                task.CreateTaskShulder(msg, date);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

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
                if (DateTime.Compare(DateTime.Now, date) < 0)
                {
                    TaskShulder task = new TaskShulder();
                    task.CreateTaskShulder(msg, date);
                }
                else
                    throw new Exception("Date must by leter then today");

                
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

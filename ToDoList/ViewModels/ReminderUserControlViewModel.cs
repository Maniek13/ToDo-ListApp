using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32.TaskScheduler;
using System;
using System.Windows.Navigation;
using ToDoList.Helper;

namespace ToDoList.ViewModels
{
    internal class ReminderUserControlViewModel
    {
        internal static void CreateReminder(string msg, DateTime date)
        {
            try
            {
                if(msg.IsNullOrEmpty())
                    throw new Exception("Please write text of reminder");


                if (DateTime.Compare(DateTime.Now, date) < 0)
                {
                    TaskShulder task = new();
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

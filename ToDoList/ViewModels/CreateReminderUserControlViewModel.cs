using Microsoft.IdentityModel.Tokens;
using System;
using ToDoList.Helper;
using ToDoList.Models;

namespace ToDoList.ViewModels
{
#pragma warning disable CA1822
    internal class CreateReminderUserControlViewModel
    {
        internal void CreateReminder(Reminder reminder)
        {
            try
            {
                if (reminder.Description.IsNullOrEmpty())
                    throw new Exception("Please write text of reminder");


                if (DateTime.Compare(DateTime.Now, reminder.Date) < 0)
                {
                    TaskShulder task = new();
                    task.CreateTaskShulder(ConversionHelper.ConvertToDbReminder(reminder));
                }
                else
                    throw new Exception("Date must by leter then today");


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
#pragma warning restore CA1822
}

using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using ToDoList.DbControler;
using ToDoList.DbModels;

namespace ToDoList.Helper
{
    internal class TaskShulder
    {
        readonly ReminderDbControler reminderDbController = new();
        internal void CreateTaskShulder(string msg, DateTime date, int? taskId = null)
        {
            int id = 0;
            try
            {
                using TaskService ts = new();

                if(taskId != null)
                    id = reminderDbController.AddReminder(date, msg, taskId);
                else
                    id = reminderDbController.AddReminder(date, msg);

                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = $"ToDoList reminder";
                td.Settings.AllowDemandStart = true;
                td.Triggers.Add(new TimeTrigger(date));
                td.Actions.Add(new ExecAction($"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.exe", $"{id.ToString()} {date:dd-MM-yy}", AppDomain.CurrentDomain.BaseDirectory));
                ts.RootFolder.RegisterTaskDefinition($"\\ToDoApp\\{date:dd-MM-yy}\\{id}", td);
            }
            catch (Exception ex)
            {
                if (id > 0)
                    reminderDbController.DeleteExecutedReminder(id);
                throw new Exception(ex.Message);
            }
        }

        internal void DeleteTaskShulder(int id, DateTime date)
        {
            try
            {
                reminderDbController.DeleteExecutedReminder(id);
                using TaskService ts = new();
                ts.RootFolder.DeleteTask($"\\ToDoApp\\{date:dd-MM-yy}\\{id.ToString()}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal List<Reminder> DeleteExpiredShulder(DateTime actualDate)
        {
            try
            {
                List<Reminder> reminders = reminderDbController.GetExpiredReminder(actualDate);

                for (int i = 0; i < reminders.Count; ++i)
                {
                    reminderDbController.DeleteExecutedReminder(reminders[i].Id);
                    using TaskService ts = new();
                    ts.RootFolder.DeleteTask($"\\ToDoApp\\{reminders[i].Date:dd-MM-yy}\\{reminders[i].Id}");
                }

                return reminders;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

using DbReminder = ToDoList.DbModels.Reminder;
using Reminder = ToDoList.Models.Reminder;
using DbTask = ToDoList.DbModels.Task;
using Task = ToDoList.Models.Task;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.Collections.Generic;

namespace ToDoList.Helper
{
    internal class ConversionHelper
    {
        internal static DbReminder ConvertToDbReminder(Reminder reminder)
        {
            return new DbReminder()
            {
                Id = reminder.Id,
                Description = reminder.Description,
                Date = reminder.Date,
                TaskID = reminder.TaskID
            };
        }

        internal static DbTask ConvertToDbTask(Task task)
        {
            return new DbTask()
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                Type = task.Type,
                HasReminder = task.HasReminder
            };
        }

        internal static Task ConvertToTask(DbTask task)
        {
            return new Task()
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                Type = task.Type,
                HasReminder = task.HasReminder
            };
        }
    }
}

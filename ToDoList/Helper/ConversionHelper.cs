using System.IO;
using DbReminder = ToDoList.DbModels.Reminder;
using DbTask = ToDoList.DbModels.Task;
using Reminder = ToDoList.Models.Reminder;
using Task = ToDoList.Models.Task;

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

        internal static Reminder ConvertToReminder(DbReminder reminder)
        {
            return new Reminder()
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

using DbReminder = ToDoList.DbModels.Reminder;
using Reminder = ToDoList.Models.Reminder;

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
    }
}

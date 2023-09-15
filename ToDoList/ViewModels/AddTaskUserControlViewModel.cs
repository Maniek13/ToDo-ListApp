using System;
using ToDoList.Models;

namespace ToDoList.ViewModels
{
    public sealed class AddTaskUserControlViewModel
    {
        internal void AddTask(Task task, Reminder reminder = new Reminder())
        {
            throw new NotImplementedException($"Not implement exception. {task.Name} {task.Description} {task.Type}");
        }

    }
}

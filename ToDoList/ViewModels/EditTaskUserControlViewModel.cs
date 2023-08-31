using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using ToDoList.Models;
using ToDoList.Views;

namespace ToDoList.ViewModels
{
    public sealed class EditTasksUserControlViewModel
    {
        internal void EditTask(Task task)
        {
            throw new NotImplementedException($"Not implement exception. {task.Name} {task.Description} {task.Type}");
        }

    }
}

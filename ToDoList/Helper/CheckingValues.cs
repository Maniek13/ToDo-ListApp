using System;
using ToDoList.Models;

namespace ToDoList.Helper
{
    class CheckingValues
    {
        internal static void CheckTaskValues(Task task)
        {
            if (string.IsNullOrEmpty(task.Name))
                throw new Exception("Plese write a name of the task");
            if (string.IsNullOrEmpty(task.Description))
                throw new Exception("Plese write a description of the task");
        }
    }
}

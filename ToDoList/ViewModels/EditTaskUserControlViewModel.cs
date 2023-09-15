using System;
using ToDoList.DbControler;
using ToDoList.Models;
using ToDoList.Helper;

namespace ToDoList.ViewModels
{
    public sealed class EditTaskUserControlViewModel
    {

        internal void EditTask(Task task)
        {
            try
            {
                CheckingValues.CheckTaskValues(task);
                TaskDbControler taskDbControler = new();
                taskDbControler.EditTask(ConversionHelper.ConvertToDbTask(task));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

 

    }
}

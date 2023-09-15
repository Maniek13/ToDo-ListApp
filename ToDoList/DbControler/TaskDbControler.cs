using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Contexts;
using ToDoList.DbModels;

namespace ToDoList.DbControler
{
    internal class TaskDbControler
    {
        readonly ToDoAppDbContext dbContext = new();
        public int AddTask(Task task)
        {
            try
            {
                dbContext.Tasks.Add(task);
                dbContext.SaveChanges();

                return task.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<Task> GetAllTasks()
        {
            try
            {
                return dbContext.Tasks.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}

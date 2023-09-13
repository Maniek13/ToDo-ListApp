using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Contexts;
using ToDoList.DbModels;

namespace ToDoList.DbControler
{
    internal class ReminderDbControler
    {
        readonly ToDoAppDbContext dbContext = new();
        public int AddReminder(DateTime date, string msg)
        {
            try
            {
                Reminder reminder = new()
                {
                    Description = msg,
                    Date = date,
                };
                dbContext.Reminder.Add(reminder);
                dbContext.SaveChanges();

                return reminder.Id;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        public void DeleteExecutedReminder(int id)
        {
            try
            {
                Reminder reminder = dbContext.Reminder.Where(r => r.Id == id).FirstOrDefault();
                dbContext.Reminder.Remove(reminder);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetReminderMsg(int id)
        {
            try
            {
                Reminder reminder = dbContext.Reminder.Where(r => r.Id == id).FirstOrDefault();
                return reminder.Description;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Reminder> GetExpiredReminder(DateTime actualDate)
        {
            try
            {
                return dbContext.Reminder.Where(r => r.Date <= actualDate).Select(el => el).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

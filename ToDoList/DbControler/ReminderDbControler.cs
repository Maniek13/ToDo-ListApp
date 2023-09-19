using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Contexts;
using ToDoList.DbModels;

namespace ToDoList.DbControler
{
    public class ReminderDbControler
    {
        readonly ToDoAppDbContext dbContext = new();
        public int AddReminder(Reminder reminder)
        {
            try
            {
                dbContext.Reminder.Add(reminder);
                dbContext.SaveChanges();

                return reminder.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
        public void DeleteReminder(int id)
        {
            try
            {
                Reminder? reminder = dbContext.Reminder.Where(r => r.Id == id).FirstOrDefault() ??
                    throw new Exception("Reminder could not be found");

                dbContext.Reminder.Remove(reminder);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Reminder? GetReminder(int taskID)
        {
            try
            {
                Reminder? reminder = dbContext.Reminder.Where(r => r.TaskID == taskID).FirstOrDefault();

                return reminder;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public string GetReminderMsg(int id)
        {
            try
            {
                Reminder? reminder = dbContext.Reminder.Where(r => r.Id == id).FirstOrDefault() ??
                    throw new Exception("Reminder could not be found");

                return reminder.Description;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
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
                throw new Exception(ex.Message, ex);
            }
        }
    }
}

using NUnit.Framework;
using ToDoList.DbControler;
using ToDoList.DbModels;

namespace ToDoListTests
{
    public class ReminderControllerTests
    {
        readonly ReminderDbControler db = new();

        [Test]
        public void GetReminderByTaskIdMsg()
        {
            try
            {
                int id = 0;
                Reminder reminder = new ()
                {
                    Description = "Test",
                    Date = DateTime.Now,
                    TaskID = 1
                };

                Assert.DoesNotThrow(() => {
                    id = db.AddReminder(reminder);
                });

                var test = db.GetReminder(1);

                Assert.Multiple(() =>
                {
                    Assert.That(test.Description, Is.EqualTo(reminder.Description));
                    Assert.That(test.Date, Is.EqualTo(reminder.Date));
                    Assert.That(test.TaskID, Is.EqualTo(reminder.TaskID));
                });
                db.DeleteReminder(id);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }


        [Test]
        public void AddReminder()
        {
            try
            {
                Assert.DoesNotThrow(() => {
                    int id = db.AddReminder(new ToDoList.DbModels.Reminder()
                    {
                        Description = "Test",
                        Date = DateTime.Now
                    });

                    Assert.That(id, Is.GreaterThan(0));

                    db.DeleteReminder(id);
                });


            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [Test]
        public void DeleteExecutedReminder()
        {
            try
            {
                int id = 0;
                Assert.DoesNotThrow(() => {
                    id = db.AddReminder(new ToDoList.DbModels.Reminder()
                    {
                        Description = "Test",
                        Date = DateTime.Now
                    });
                    db.DeleteReminder(id);
                });

                var test = db.GetReminderById(id);
                Assert.That(test, Is.EqualTo(null));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [Test]
        public void GetReminderMsg()
        {
            try
            {
                int id = 0;
                Assert.DoesNotThrow(() => {
                    id = db.AddReminder(new ToDoList.DbModels.Reminder()
                    {
                        Description = "Test",
                        Date = DateTime.Now
                    });
                });

                var test = db.GetReminderById(id);
                Assert.That(test.Description, Is.EqualTo("Test"));

                db.DeleteReminder(id);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [Test]
        public void GetExpiredReminder()
        {
            try
            {
                int id = 0;
                Assert.DoesNotThrow(() => {
                    id = db.AddReminder(new ToDoList.DbModels.Reminder()
                    {
                        Description = "Test",
                        Date = DateTime.Now
                    });
                });

                var expiredList = db.GetExpiredReminder(DateTime.Now.AddMinutes(1));
                var expired = db.GetReminderById(id);

                CollectionAssert.Contains(expiredList, expired);

                db.DeleteReminder(id);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
    }
}
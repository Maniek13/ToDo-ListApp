using ToDoList.DbControler;

namespace ToDoListTests
{
    public class TaskControllerTests
    {
        TaskDbControler db = new TaskDbControler();

        [Test]
        public void ShowTasks()
        {
            try
            {
                int id = db.AddTask(new ToDoList.DbModels.Task()
                {
                    Description = "Test",
                    Name = "Test",
                    Type = 0,
                    HasReminder = false
                });


                Assert.DoesNotThrow(() => {
                    var x = db.GetAllTasks();
                    Assert.IsInstanceOf<List<ToDoList.DbModels.Task>>(x);
                });

                db.DeleteTask(id);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
            
        }

        [Test]
        public void AddTask()
        {
            try
            {
                Assert.DoesNotThrow(() => {
                    int id = db.AddTask(new ToDoList.DbModels.Task()
                    {
                        Description = "Test",
                        Name = "Test",
                        Type = 0,
                        HasReminder = false
                    });

                    Assert.That(id, Is.GreaterThan(0));

                    db.DeleteTask(id);
                });

                
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [Test]
        public void EditTask()
        {
            try
            {
                int id = 0;
                Assert.DoesNotThrow(() => {

                    ToDoList.DbModels.Task task = new ToDoList.DbModels.Task()
                    {
                        Description = "Test",
                        Name = "Test",
                        Type = 0,
                        HasReminder = false
                    };


                    id = db.AddTask(task);

                    task.Description = "Test2";
                    task.Name = "Test2";

                    db.EditTask(task);

                    var editedTask = db.GetTask(id);

                    Assert.That(editedTask.Description == "Test2" && editedTask.Name == "Test2");

                    db.DeleteTask(id);

                });

            
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [Test]
        public void DeleteTask()
        {

            try
            {
                int id = 0;
                Assert.DoesNotThrow(() => {
                    id = db.AddTask(new ToDoList.DbModels.Task()
                    {
                        Description = "Test",
                        Name = "Test",
                        Type = 0,
                        HasReminder = false
                    });
                    db.DeleteTask(id);
                });

                var test = db.GetTask(id);
                Assert.That(test == null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
    }
}
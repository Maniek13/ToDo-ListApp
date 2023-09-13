using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Interop;

namespace ToDoList.Helper
{
    internal class TaskShulder
    {

        private void CreateOne(string msg, DateTime date, string taskName)
        {
            try
            {
                using (TaskService ts = new TaskService())
                {
                    TaskDefinition td = ts.NewTask();
                    td.RegistrationInfo.Description = $"ToDoList reminder";

                    td.Triggers.Add(new TimeTrigger(date));
                    td.Actions.Add(new ExecAction($"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.exe", msg, AppDomain.CurrentDomain.BaseDirectory));

                    ts.RootFolder.RegisterTaskDefinition(taskName, td);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        internal void CreateTaskShulder(string msg, DateTime date)
        {
            try
            {
                CreateOne(msg, date, $"{new Guid()}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal void CreateTaskShulder(string msg, DateTime date, int id)
        {
            try
            {
                CreateOne(msg, date, $"TDL{ id.ToString()}");
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

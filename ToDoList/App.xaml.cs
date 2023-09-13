using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using ToDoList.DbControler;
using ToDoList.DbModels;
using ToDoList.Helper;

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow wnd = new();
            ReminderDbControler reminderDbController = new();
            TaskShulder taskScheduler = new();


            if (e.Args.Length == 2)
            {
                try
                {
                    if (int.TryParse(e.Args[0], out int id) && DateTime.TryParse(e.Args[1], out DateTime date))
                    {
                        string msg = reminderDbController.GetReminderMsg(id);

                        if(!msg.IsNullOrEmpty())
                        {
                            MessageBox.Show(msg);

                            taskScheduler.DeleteTaskShulder(id, date);
                        }
                      
                    }
                    else
                    {
                        MessageBox.Show("Bad data format");                
                    } 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
                Environment.Exit(0);
            }
            else
            {
                try
                {
                    List<Reminder> reminders = taskScheduler.DeleteExpiredShulder(DateTime.Now);

                    if(reminders.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();

                        for (int i = 0; i < reminders.Count; ++i)
                        {
                            sb.AppendLine($"Reminders: {reminders[i].Description} on data: {reminders[i].Date} expired");
                        }
                        MessageBox.Show(sb.ToString());
                    }
                }
                catch (Exception ex)
                {
                    wnd.ErrorMsg.Visibility = Visibility.Visible;
                    wnd.ErrorMsg.Text = ex.Message;
                }
                

                wnd.Show();
            }
        }
    }
}

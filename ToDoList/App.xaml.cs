using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using ToDoList.DbControler;
using ToDoList.Helper;
using ToDoList.Models;
using ToDoList.Views;

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

                        if (!msg.IsNullOrEmpty())
                        {
                            ReminderMsgWindow reminderMsgWindow = new(msg);
                            reminderMsgWindow.Show();
                            taskScheduler.DeleteTaskShulder(id, date);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bad data format");
                        Environment.Exit(0);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Environment.Exit(0);
                }
            }
            else
            {
                try
                {
                    List<Reminder> reminders = taskScheduler.DeleteExpiredShulder(DateTime.Now).Select(el => ConversionHelper.ConvertToReminder(el)).ToList();
                    if (reminders.Count > 0)
                    {
                        StringBuilder sb = new();

                        sb.AppendLine("Expired reminders:");
                        sb.AppendLine(@"\line");

                        for (int i = 0; i < reminders.Count; ++i)
                        {
                            sb.AppendLine(@"\line");
                            sb.AppendLine($"Data: {reminders[i].Date}");
                            sb.AppendLine(@"\line");
                            sb.AppendLine($"{reminders[i].Description}");
                        }

                        ReminderMsgWindow reminderMsgWindow = new(sb.ToString(), true);
                        reminderMsgWindow.Show();
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



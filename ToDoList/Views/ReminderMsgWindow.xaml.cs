using System;
using System.Windows;

namespace ToDoList.Views
{
    /// <summary>
    /// Interaction logic for ReminderMsgWindow.xaml
    /// </summary>
    public partial class ReminderMsgWindow : Window
    {
        public ReminderMsgWindow(string msg)
        {
            InitializeComponent();
            MessageBox.Text = msg;
        }
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Environment.Exit(0);
        }
    }
}

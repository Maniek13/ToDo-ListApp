using System;
using System.Media;
using System.Windows;

namespace ToDoList.Views
{
    /// <summary>
    /// Interaction logic for ReminderMsgWindow.xaml
    /// </summary>
    public partial class ReminderMsgWindow : Window
    {
        private readonly bool _expired;
        public ReminderMsgWindow(string msg, bool expired = false)
        {
            _expired = expired;
            InitializeComponent();
            SystemSounds.Beep.Play();
            MessageBox.Text = msg;

        }
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!_expired)
                Environment.Exit(0);
            else
                this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!_expired)
            {
                e.Cancel = true;
                Environment.Exit(0);
            }
        }
    }
}

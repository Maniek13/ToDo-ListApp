using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ToDoList.Models;
using ToDoList.ViewModels;

namespace ToDoList.Views
{
    public partial class CreateReminderUserControl : UserControl
    {
        private CreateReminderUserControlViewModel ViewModel { get; }
        private readonly MainWindow mainWindow;

        #region Dependency property
        private static readonly DependencyProperty ReminderProperty =
            DependencyProperty.Register(
                name: "ReminderValue",
                propertyType: typeof(Reminder),
                ownerType: typeof(CreateReminderUserControl),
                typeMetadata: new FrameworkPropertyMetadata(defaultValue: new Reminder() { Date = DateTime.Now }));
        #endregion

        private Reminder ReminderValue
        {
            get { return (Reminder)GetValue(ReminderProperty); }
            set { SetValue(ReminderProperty, value); }
        }

#pragma warning disable CS8601, CS8618
        public CreateReminderUserControl()
        {
            InitializeComponent();
            ViewModel = new CreateReminderUserControlViewModel();
            DataContext = this;
            mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
        }
#pragma warning restore CS8601, CS8618

        private void CreateNewReminderBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mainWindow.ErrorMsg.Text = "";
                mainWindow.ErrorMsg.Visibility = Visibility.Hidden;
                Status.Visibility = Visibility.Hidden;
                AddBtn.IsEnabled = false;
                mainWindow.ErrorMsg.Text = "";
                mainWindow.ErrorMsg.Visibility = Visibility.Hidden;
                ViewModel.CreateReminder(ReminderValue);
                Status.Visibility = Visibility.Visible;
                Status.Text = $"Reminder was added on date: {ReminderValue.Date}";
            }
            catch (Exception ex)
            {
                mainWindow.ErrorMsg.Text = ex.Message;
                mainWindow.ErrorMsg.Visibility = Visibility.Visible;
            }

            AddBtn.IsEnabled = true;
        }
    }
}

using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ToDoList.ViewModels;

namespace ToDoList.Views
{
    public partial class ReminderUserControl : UserControl
    {
        private ReminderUserControlViewModel ViewModel { get; }
        private readonly MainWindow mainWindow;

        #region Dependency property
        private static readonly DependencyProperty DateValueProperty =
            DependencyProperty.Register(
                name: "DateValue",
                propertyType: typeof(DateTime),
                ownerType: typeof(ReminderUserControl),
                typeMetadata: new FrameworkPropertyMetadata(defaultValue: DateTime.Now));

        private static readonly DependencyProperty DescriptionValueProperty =
            DependencyProperty.Register(
                name: "DescriptionValue",
                propertyType: typeof(string),
                ownerType: typeof(ReminderUserControl),
                typeMetadata: new FrameworkPropertyMetadata(defaultValue: ""));
        #endregion

        private DateTime DateValue
        {
            get { return (DateTime)GetValue(DateValueProperty); }
            set { SetValue(DateValueProperty, value); }
        }
        private string DescriptionValue
        {
            get { return (string)GetValue(DescriptionValueProperty); }
            set { SetValue(DescriptionValueProperty, value); }
        }
        public ReminderUserControl()
        {
            InitializeComponent();
            ViewModel = new ReminderUserControlViewModel();
            DataContext = this;
            mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
        }
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
                ReminderUserControlViewModel.CreateReminder(DescriptionValue, DateValue);
                Status.Visibility = Visibility.Visible;
                Status.Text = $"Reminder was added on date: {DateValue}";
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

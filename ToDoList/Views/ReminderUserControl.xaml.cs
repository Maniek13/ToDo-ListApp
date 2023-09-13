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
                typeMetadata: new FrameworkPropertyMetadata(defaultValue: DateTime.Now.AddDays(1)));

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
                if (DateTime.Compare(DateTime.Now.AddDays(1), DateValue) >= 0)
                    ViewModel.CreateReminder(DescriptionValue, DateValue);
                else
                    throw new Exception("Date must by leter then today");

            }
            catch(Exception ex)
            {
                mainWindow.ErrorMsg.Text = ex.Message;
                mainWindow.ErrorMsg.Visibility = Visibility.Visible;
            }
        }
    }
}

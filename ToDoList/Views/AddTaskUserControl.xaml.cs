using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ToDoList.Models;
using ToDoList.ViewModels;

namespace ToDoList.Views
{
    public partial class AddTaskUserControl : UserControl
    {
        private readonly MainWindow mainWindow;
        private AddTaskUserControlViewModel ViewModel { get; }

#pragma warning disable CS8601, CS8618
        public AddTaskUserControl()
        {
            InitializeComponent();
            DataContext = ViewModel = new AddTaskUserControlViewModel();
            EditForm.DataContext = this;
            mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
        }
#pragma warning restore CS8601, CS8618

        #region Dependency property
        private static readonly DependencyProperty TaskValueProperty =
            DependencyProperty.Register(
                name: "TaskValue",
                propertyType: typeof(Task),
                ownerType: typeof(AddTaskUserControl),
                typeMetadata: new FrameworkPropertyMetadata(defaultValue: new Task()));
        private static readonly DependencyProperty ReminderProperty =
           DependencyProperty.Register(
               name: "ReminderValue",
               propertyType: typeof(Reminder),
               ownerType: typeof(AddTaskUserControl),
               typeMetadata: new FrameworkPropertyMetadata(defaultValue: new Reminder() { Date = DateTime.Now }));
        #endregion

        private Task TaskValue
        {
            get { return (Task)GetValue(TaskValueProperty); }
            set { SetValue(TaskValueProperty, value); }
        }
        private Reminder ReminderValue
        {
            get { return (Reminder)GetValue(ReminderProperty); }
            set { SetValue(ReminderProperty, value); }
        }

        private void AddTask_BtnClick(object sender, RoutedEventArgs e)
        {

            try
            {
                mainWindow.ErrorMsg.Text = "";
                mainWindow.ErrorMsg.Visibility = Visibility.Hidden;

                ViewModel.AddTask(TaskValue, ReminderValue);

                mainWindow.MainContext = null;
            }
            catch (Exception ex)
            {
                mainWindow.ErrorMsg.Text = ex.Message;
                mainWindow.ErrorMsg.Visibility = Visibility.Visible;
            }
        }
        private void HasReminderCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ReminderForm.Visibility = Visibility.Visible;
            ReminderForm.Height = 55;
        }
        private void HasReminderCheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            ReminderForm.Visibility = Visibility.Hidden;
            ReminderForm.Height = 0;
        }

    }
}

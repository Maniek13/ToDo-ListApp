using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ToDoList.Models;
using ToDoList.ViewModels;

namespace ToDoList.Views
{
    public partial class EditTaskUserControl : UserControl
    {
        private readonly MainWindow mainWindow;
        private EditTaskUserControlViewModel ViewModel { get; }

#pragma warning disable CS8601, CS8618
        public EditTaskUserControl(Task task)
        {
            InitializeComponent();
            TaskValue = task;
            DataContext = ViewModel = new EditTaskUserControlViewModel();
            EditForm.DataContext = this;
            mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
        }
#pragma warning restore CS8601, CS8618

        #region Dependency property
        private static readonly DependencyProperty TaskValueProperty =
        DependencyProperty.Register(
            name: "TaskValue",
            propertyType: typeof(Task),
            ownerType: typeof(EditTaskUserControl),
            typeMetadata: new FrameworkPropertyMetadata(defaultValue: new Task()));
        #endregion

        private Task TaskValue
        {
            get { return (Task)GetValue(TaskValueProperty); }
            set { SetValue(TaskValueProperty, value); }
        }

        private void EditTask_BtnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                mainWindow.ErrorMsg.Visibility = Visibility.Hidden;
                ViewModel.EditTask(TaskValue);
                mainWindow.MainContext.Content = new ListOfTasksUserControl();
            }
            catch (Exception ex)
            {
                mainWindow.ErrorMsg.Text = ex.Message;
                mainWindow.ErrorMsg.Visibility = Visibility.Visible;
            }
        }
    }
}

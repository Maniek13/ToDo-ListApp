using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ToDoList.Views
{
    public partial class MenuUserControl : UserControl
    {
        private readonly MainWindow mainWindow;

#pragma warning disable CS8601, CS8618
        public MenuUserControl()
        {
            InitializeComponent();
            mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
        }
#pragma warning restore CS8601, CS8618

        private void ShowTasksList_BtnClick(object sender, RoutedEventArgs e)
        {
            mainWindow.ErrorMsg.Visibility = Visibility.Hidden;
            mainWindow.MainContext.Content = new ListOfTasksUserControl();
        }
        private void AddTasksList_BtnClick(object sender, RoutedEventArgs e)
        {
            mainWindow.ErrorMsg.Visibility = Visibility.Hidden;
            mainWindow.MainContext.Content = new AddTaskUserControl();
        }
        private void ReminderCreate_BtnClick(object sender, RoutedEventArgs e)
        {
            mainWindow.ErrorMsg.Visibility = Visibility.Hidden;
            mainWindow.MainContext.Content = new CreateReminderUserControl();
        }
    }
}
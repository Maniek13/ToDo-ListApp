using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ToDoList.Views
{
    public partial class MenuUserControl : UserControl
    {
        public MenuUserControl()
        {
            InitializeComponent();
        }

        internal void ShowTasksList_BtnClick(object sender, RoutedEventArgs e) 
        {
            var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if(mainWindow != null)
                mainWindow.MainContext.Content = new ListOfTasksUserControl();
        }
    }
}
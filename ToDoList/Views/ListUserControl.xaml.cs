using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ToDoList.Models;
using ToDoList.ViewModels;

namespace ToDoList.Views
{

    public sealed partial class ListOfTasksUserControl : UserControl
    {
        private readonly MainWindow mainWindow;
        internal ListOfTasksUserControlViewModel ViewModel { get; }

#pragma warning disable CS8601, CS8618
        public ListOfTasksUserControl()
        {
            InitializeComponent();

            try
            {
                DataContext = ViewModel = new ListOfTasksUserControlViewModel();
                mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                mainWindow.ErrorMsg.Visibility = Visibility.Hidden;
                ViewModel.GetList();
            }
            catch (Exception ex)
            {
                mainWindow.ErrorMsg.Text = ex.Message;
                mainWindow.ErrorMsg.Visibility = Visibility.Visible;
            }

        }
#pragma warning restore CS8601, CS8618

        private void Edit_BtnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                mainWindow.ErrorMsg.Visibility = Visibility.Hidden;
                mainWindow.MainContext.Content = new EditTaskUserControl((Task)((Button)sender).Tag);
            }
            catch (Exception ex)
            {
                mainWindow.ErrorMsg.Text = ex.Message;
                mainWindow.ErrorMsg.Visibility = Visibility.Visible;
            }
        }

        private void Delete_BtnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                mainWindow.ErrorMsg.Visibility = Visibility.Hidden;
                ViewModel.DeleteTask((Task)((Button)sender).Tag);
            }
            catch (Exception ex)
            {
                mainWindow.ErrorMsg.Text = ex.Message;
                mainWindow.ErrorMsg.Visibility = Visibility.Visible;
            }
        }
    }
}

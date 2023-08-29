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
        internal ListOfTasksUserControlViewModel ViewModel { get; set; }
        public ListOfTasksUserControl()
        {
            InitializeComponent();
            DataContext = ViewModel = new ListOfTasksUserControlViewModel();
        }

        internal void Edit_BtnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                ErrorMsg.Visibility = Visibility.Hidden;
                Task task = (Task)((Button)sender).Tag;
                ViewModel.EditTask(task);
            }
            catch (Exception ex)
            {
                ErrorMsg.Visibility = Visibility.Visible;
                ErrorMsg.Text = ex.Message;
            }
            
        }
    }
}

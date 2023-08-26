using System;
using System.Windows;
using System.Windows.Controls;
using ToDoList.Models;
using ToDoList.ViewModels;

namespace ToDoList.Pages
{
    public sealed partial class ListPage : Page
    {
        internal ListPageViewModel ViewModel { get; set; }
        public ListPage()
        {
            InitializeComponent();
            try
            {
                DataContext = ViewModel = new ListPageViewModel();
            }
            catch (Exception ex)
            {
                ErrorMsg.Visibility = Visibility.Visible;
                ErrorMsg.Text = ex.Message;
            }

         
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
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

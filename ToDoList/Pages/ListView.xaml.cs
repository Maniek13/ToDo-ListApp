using System;
using System.Windows;
using System.Windows.Controls;
using ToDoList.Models;
using ToDoList.ViewModels;

namespace ToDoList.Pages
{
    public sealed partial class ListView : UserControl
    {
        internal ListViewViewModel ViewModel { get; set; }
        public ListView()
        {
            InitializeComponent();
            DataContext = ViewModel = new ListViewViewModel();
           

         
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

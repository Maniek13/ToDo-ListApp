using System.Linq;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ToDoList.Pages
{
    public partial class MenuView : UserControl
    {
        public MenuView()
        {
            InitializeComponent();
        }

        internal void ShowTasksList_BtnClick(object sender, RoutedEventArgs e) 
        {
            Application.Current.Windows.OfType<MainWindow>().FirstOrDefault().MainContext.Content = new ListView();

        }

      
    }
}
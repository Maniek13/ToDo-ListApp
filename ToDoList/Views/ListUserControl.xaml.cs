using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ToDoList.Models;
using ToDoList.ViewModels;

namespace ToDoList.Views
{

    public sealed partial class ListOfTasksUserControl : UserControl
    {
        private readonly MainWindow mainWindow;
        internal ListOfTasksUserControlViewModel ViewModel { get; }


#pragma warning disable CS8601, CS8618, CS8602, CS8600, CS8604
        public ListOfTasksUserControl()
        {
            InitializeComponent();

            try
            {
                DataContext = ViewModel = new ListOfTasksUserControlViewModel();
                mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                mainWindow.ErrorMsg.Visibility = Visibility.Hidden;
                ViewModel.GetList();


                Style itemContainerStyle = new (typeof(ListBoxItem));
                itemContainerStyle.Setters.Add(new Setter(ListBoxItem.AllowDropProperty, true));
                itemContainerStyle.Setters.Add(new EventSetter(ListBoxItem.PreviewMouseRightButtonDownEvent, new MouseButtonEventHandler(ListOfTasksItem_PreviewMouseRightButtonDown)));
                itemContainerStyle.Setters.Add(new EventSetter(ListBoxItem.DropEvent, new DragEventHandler(ListOfTasks_Drop)));
                ListOfTasks.ItemContainerStyle = itemContainerStyle;
            }
            catch (Exception ex)
            {
                mainWindow.ErrorMsg.Text = ex.Message;
                mainWindow.ErrorMsg.Visibility = Visibility.Visible;
            }

        }

        private void ListOfTasksItem_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListBoxItem)
            {
                ListBoxItem draggedItem = sender as ListBoxItem;
                DragDrop.DoDragDrop(draggedItem, draggedItem.DataContext, DragDropEffects.Move);
                draggedItem.IsSelected = true;
            }
        }

        private void ListOfTasks_Drop(object sender, DragEventArgs e)
        {
            Task droppedData = e.Data.GetData(typeof(Task)) as Task;
            Task target = ((ListBoxItem)(sender)).DataContext as Task;

            int oldIdx = ListOfTasks.Items.IndexOf(droppedData);
            int targetIdx = ListOfTasks.Items.IndexOf(target);

            if (oldIdx < targetIdx)
            {
                ViewModel.Tasks.Insert(targetIdx + 1, droppedData);
                ViewModel.Tasks.RemoveAt(oldIdx);
            }
            else
            {
                int remIdx = oldIdx + 1;
                if (ViewModel.Tasks.Count + 1 > remIdx)
                {
                    ViewModel.Tasks.Insert(targetIdx, droppedData);
                    ViewModel.Tasks.RemoveAt(remIdx);
                }
            }
        }
#pragma warning restore CS8601, CS8618, CS8602, CS8600, CS8604

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

        private void SortByNameAsc(object sender, RoutedEventArgs e)
        {
            try
            {
                mainWindow.ErrorMsg.Visibility = Visibility.Hidden;
                ViewModel.SortByName(true);
            }
            catch (Exception ex)
            {
                mainWindow.ErrorMsg.Text = ex.Message;
                mainWindow.ErrorMsg.Visibility = Visibility.Visible;
            }
        }

        private void SortByNameDesc(object sender, RoutedEventArgs e)
        {
            try
            {
                mainWindow.ErrorMsg.Visibility = Visibility.Hidden;
                ViewModel.SortByName(false);
            }
            catch (Exception ex)
            {
                mainWindow.ErrorMsg.Text = ex.Message;
                mainWindow.ErrorMsg.Visibility = Visibility.Visible;
            }
        }
    }
}

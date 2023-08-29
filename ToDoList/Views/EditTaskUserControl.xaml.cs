using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ToDoList.Models;

namespace ToDoList.Views
{
    /// <summary>
    /// Interaction logic for EditItemUserControl.xaml
    /// </summary>
    public partial class EditTaskUserControl : UserControl
    {

        public EditTaskUserControl(Task task)
        {
            TaskValue = task;
            InitializeComponent();
            DataContext = this;
        }

        internal static readonly DependencyProperty TaskValueProperty =
        DependencyProperty.Register(
            name: "TaskValue",
            propertyType: typeof(Task),
            ownerType: typeof(EditTaskUserControl),
            typeMetadata: new FrameworkPropertyMetadata(defaultValue: new Task()));

        internal Task TaskValue
        {
            get { return (Task)GetValue(TaskValueProperty); }
            set { SetValue(TaskValueProperty, value); }
        }


        internal void ChangeTask_BtnClick(object sender, RoutedEventArgs e)
        {
            var task = ((Button)sender).Tag as Task?;

    
            TaskValue = new Task()
            {
                Id = 0,
                Name = "not implement"

            };
        }
    }
}

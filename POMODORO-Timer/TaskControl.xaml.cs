using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POMODORO_Timer
{
    /// <summary>
    /// Interaction logic for TaskControl.xaml
    /// </summary>
    public partial class TaskControl : UserControl
    {
        private Tasks _tasks;
        public TaskControl(Tasks tasks)
        {
            _tasks = tasks;
            InitializeComponent();
            DataContext = tasks;
        }

        private void SwitchButtonOnClick(object sender, RoutedEventArgs e)
        {
            _tasks.IsCompleted = !_tasks.IsCompleted;
        }
    }
}

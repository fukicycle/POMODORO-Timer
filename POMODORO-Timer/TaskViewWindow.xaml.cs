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
using System.Windows.Shapes;

namespace POMODORO_Timer
{
    /// <summary>
    /// Interaction logic for TaskViewWindow.xaml
    /// </summary>
    public partial class TaskViewWindow : Window
    {
        private Stem stem;
        private TaskItem taskItem;
        private List<TaskControl> _taskControls;

        public TaskViewWindow(List<TaskControl> taskControls)
        {
            _taskControls = taskControls;
            InitializeComponent();
            stem = new Stem(mainCanvas);
            stem.Create(_taskControls.Count);
            taskItem = new TaskItem(mainCanvas, stem.points, _taskControls);
            taskItem.Create();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace POMODORO_Timer
{
    public class TaskItem
    {
        private Canvas _canvas;
        private List<double[]> _points;
        private List<TaskControl> _taskControls;

        public TaskItem(Canvas canvas, List<double[]> points, List<TaskControl> taskControls)
        {
            _canvas=canvas;
            _points=points;
            _taskControls=taskControls;
        }

        public void Create()
        {
            int i = 0;
            _points.ForEach(point =>
            {
                double x = point[0];
                double y = point[1];
                TaskControl taskControl = _taskControls[i];
                Canvas.SetLeft(taskControl, AdjestValue(x));
                Canvas.SetTop(taskControl, AdjestValue(y));
                _canvas.Children.Add(taskControl);
                i++;
            });
        }

        private double AdjestValue(double value)
        {
            return value - 65;
        }
    }
}

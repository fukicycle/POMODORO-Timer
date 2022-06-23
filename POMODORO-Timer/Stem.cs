using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace POMODORO_Timer
{
    public class Stem
    {
        private Color MainColor = Color.FromRgb(9, 134, 21);
        private Canvas _canvas;
        public List<double[]> points = new List<double[]>();
        public Stem(Canvas canvas)
        {
            _canvas = canvas;
        }

        public void Create(int taskCount)
        {
            double xLength = 100.0 * taskCount / 2.0 + 20;
            double yLength = 80.0 * taskCount / 2.0 + 20;
            _canvas.Children.Add(CreateOneStreetStem(0, xLength, 0, yLength));
            int surplus = taskCount % 2;
            for (int i = 0; i < taskCount / 2 + surplus; i++)
            {
                (double, double) xy = GetCrossPosition((xLength - 20) - i * 100, xLength, yLength);
                _canvas.Children.Add(CreateOneStreetStem(xy.Item1, xy.Item1, xy.Item2, xy.Item2+80));
                points.Add(new double[2] { xy.Item1, xy.Item2+80 });
                if (surplus != 0 && i == taskCount / 2) continue;
                xy = GetCrossPosition((xLength - 50) - i * 100, xLength, yLength);
                _canvas.Children.Add(CreateOneStreetStem(xy.Item1, xy.Item1+100, xy.Item2, xy.Item2));
                points.Add(new double[2] { xy.Item1+100, xy.Item2 });
            }
        }



        private Line CreateOneStreetStem(double x1, double x2, double y1, double y2)
        {
            Line line = new Line();
            line.StrokeThickness = 10;
            line.Stroke = new SolidColorBrush(MainColor);
            line.X1 = x1;
            line.X2 = x2;
            line.Y1 = y1;
            line.Y2 = y2;
            return line;
        }

        private Path CreateOneCurveStem(double x1, double x2, double y1, double y2)
        {
            Path path = new Path();
            Geometry geometry = Geometry.Parse($"M {x1},{y1} c {x1 + 200},{y1 + 20} {x2 - 150},{y2 - 20} {x2},{y2}");
            path.Data = geometry;
            path.Stroke = new SolidColorBrush(MainColor);
            path.StrokeThickness = 10;
            return path;
        }

        private (double, double) GetCrossPosition(double x, double xLength, double yLength)
        {
            var y = (yLength/xLength) * x;
            return (x, y);
        }
    }
}

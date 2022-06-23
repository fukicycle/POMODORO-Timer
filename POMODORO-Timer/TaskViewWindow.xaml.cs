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
        public TaskViewWindow()
        {
            InitializeComponent();
            stem = new Stem(mainCanvas);
            stem.Create(5);
            //mainCanvas.Children.Add(new TaskControl(new Tasks { IsCompleted= false, Name = "課題の反省" }));
            //var tc = new TaskControl(new Tasks { IsCompleted= true, Name = "課題の反省2" });
            //Canvas.SetLeft(tc, 100);
            //Canvas.SetTop(tc, 200);
            //mainCanvas.Children.Add(tc);
        }
    }
}

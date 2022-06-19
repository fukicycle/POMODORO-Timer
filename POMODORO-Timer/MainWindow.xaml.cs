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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TimerManager tm = new TimerManager();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DragMove(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CloseButtonOnClick(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void StartButtonOnClick(object sender, RoutedEventArgs e)
        {
            if (tm.Create(this, Step.FIRST, StepEnum.FIRST)) tm.Start();
            stepTextBlock.Text = $"{typeof(StepEnum).GetEnumName(StepEnum.FIRST)}";
        }
    }
}

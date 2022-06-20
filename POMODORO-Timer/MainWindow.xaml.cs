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
        private StepManager stepManager;
        public MainWindow()
        {
            InitializeComponent();
            stepManager = new StepManager(this);
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
            stepManager.StartPomodoro();
        }

        private void PauseButtonOnClick(object sender, RoutedEventArgs e)
        {
            stepManager.Pause();
        }

        private void ResetButtonOnClick(object sender, RoutedEventArgs e)
        {
            stepManager.Reset();
        }
    }
}

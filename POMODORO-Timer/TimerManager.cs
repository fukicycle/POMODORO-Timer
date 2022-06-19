using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace POMODORO_Timer
{
    public class TimerManager
    {
        private Timer timer;
        private int countTimer = 0;
        private static StepEnum _stepEnum = StepEnum.DEFAULT;

        public bool Create(MainWindow window, int step, StepEnum stepEnum)
        {
            if (_stepEnum == stepEnum) return false;
            _stepEnum = stepEnum;
            timer = new Timer(step * 60 * 1000);
            timer.Interval = 1000;
            timer.Elapsed += (s, ev) =>
            {
                window.Dispatcher.Invoke(() => window.timerTextBlock.Text = $"{TimeSpan.FromSeconds((step * 60) - countTimer++)}");
                if (countTimer == (step * 60 + 1))
                {
                    timer.Stop();
                    timer.Dispose();
                    timer = null;
                }
            };
            return true;
        }

        public void Start()
        {
            if (timer != null)
                timer.Start();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace POMODORO_Timer
{
    public class TimerManager : IDisposable
    {
        private Timer timer;
        private int countTimer = 0;
        private static StepEnum _stepEnum = StepEnum.FIRST;
        private NotifyChanged _notifyChanged = null;
        private bool isPause = false;
        private MainWindow _window;

        public TimerManager(NotifyChanged notifyChanged, MainWindow window)
        {
            _window = window;
            _notifyChanged = notifyChanged;
            Create(StepEnum.FIRST);
        }

        public bool Create(StepEnum stepEnum)
        {
            //if (_stepEnum == stepEnum && isPause == false) return false;
            //if (isPause)
            //{
            //    isPause = false;
            //    return true;
            //}
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
                timer = null;
            }
            int step = Step.GetTimeFromStepEnum(stepEnum);
            countTimer = 0;
            _stepEnum = stepEnum;
            timer = new Timer(step * 60 * 1000);
            timer.Interval = 1000;
            timer.Elapsed += (s, ev) =>
            {
                _window.Dispatcher.Invoke(() => _window.timerTextBlock.Text = $"{TimeSpan.FromSeconds((step * 60) - countTimer++)}");
                if (countTimer == (step * 60 + 1))
                {
                    timer.Stop();
                    timer.Dispose();
                    timer = null;
                    _notifyChanged.Finished(stepEnum);
                }
            };
            return true;
        }

        public bool Start()
        {
            if (timer  == null) return false;
            timer.Start();
            isPause = false;
            return true;
        }

        public bool Pause()
        {
            if (timer == null || timer.Enabled == false) return false;
            isPause = true;
            timer.Stop();
            return true;
        }

        public bool Reset()
        {
            if (timer == null) return true;
            Dispose();
            return true;
        }


        public bool MoveStep(StepEnum stepEnum)
        {
            if (timer == null || timer.Enabled == true) return false;
            return Create(stepEnum);
        }

        public void Dispose()
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
                timer = null;
                countTimer = 0;
                _stepEnum = StepEnum.FIRST;
                _window = null;
                _notifyChanged = null;
                isPause = false;
            }
        }
    }
}

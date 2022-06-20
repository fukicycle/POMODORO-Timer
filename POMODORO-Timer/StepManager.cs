using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace POMODORO_Timer
{
    public class StepManager : NotifyChanged
    {
        private TimerManager timerManager;
        private StepEnum prevStep = StepEnum.READY;
        private StepEnum nextStep = StepEnum.FIRST;
        private MainWindow _window = null;

        public StepManager(MainWindow window)
        {
            timerManager = new TimerManager(this);
            _window = window;
            timerManager.Create(_window, Step.FIRST, StepEnum.FIRST);
        }

        public void StartPomodoro()
        {
            timerManager.Start();
            _window.stepTextBlock.Text = typeof(StepEnum).GetEnumName(nextStep);
        }

        public void Pause()
        {
            if (timerManager.Pause())
                _window.stepTextBlock.Text = "PAUSE";
        }

        public void Finished(StepEnum stepEnum)
        {
            switch (stepEnum)
            {
                case StepEnum.FIRST:
                case StepEnum.SECOND:
                case StepEnum.THIRD:
                    nextStep = StepEnum.BREAK;
                    prevStep = stepEnum;
                    timerManager.Create(_window, Step.BREAK, StepEnum.BREAK);
                    break;
                case StepEnum.FOURTH:
                    nextStep = StepEnum.L_BREAK;
                    prevStep = stepEnum;
                    timerManager.Create(_window, Step.L_BREAK, StepEnum.L_BREAK);
                    break;
                case StepEnum.BREAK:
                    if (prevStep == StepEnum.FIRST)
                    {
                        nextStep = StepEnum.SECOND;
                        timerManager.Create(_window, Step.SECOND, StepEnum.SECOND);
                    }
                    if (prevStep == StepEnum.SECOND)
                    {
                        nextStep = StepEnum.THIRD;
                        timerManager.Create(_window, Step.THIRD, StepEnum.THIRD);
                    }
                    if (prevStep == StepEnum.THIRD)
                    {
                        nextStep = StepEnum.FOURTH;
                        timerManager.Create(_window, Step.FOURTH, StepEnum.FOURTH);
                    }
                    break;
                case StepEnum.L_BREAK:
                    nextStep = StepEnum.READY;
                    break;
            }
            timerManager.Start();
            _window.Dispatcher.Invoke(() => _window.stepTextBlock.Text = typeof(StepEnum).GetEnumName(nextStep));
        }
    }
}

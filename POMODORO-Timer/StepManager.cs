using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMODORO_Timer
{
    public class StepManager : NotifyChanged
    {
        private TimerManager timerManager;
        private StepEnum prevStep = StepEnum.READY;
        private MainWindow _window = null;

        public StepManager(MainWindow window)
        {
            timerManager = new TimerManager(this);
            _window = window;
        }

        public void StartPomodoro()
        {
            timerManager.Create(_window, Step.FIRST, StepEnum.FIRST)?.Start();
            _window.stepTextBlock.Text = typeof(StepEnum).GetEnumName(StepEnum.FIRST);
        }

        public void Finished(StepEnum stepEnum)
        {
            StepEnum nextStep = StepEnum.READY;
            switch (stepEnum)
            {
                case StepEnum.FIRST:
                case StepEnum.SECOND:
                case StepEnum.THIRD:
                    nextStep = StepEnum.BREAK;
                    prevStep = stepEnum;
                    timerManager.Create(_window, Step.BREAK, StepEnum.BREAK)?.Start();
                    break;
                case StepEnum.FOURTH:
                    nextStep = StepEnum.LONG_BREAK;
                    prevStep = stepEnum;
                    timerManager.Create(_window, Step.LONG_BREAK, StepEnum.LONG_BREAK)?.Start();
                    break;
                case StepEnum.BREAK:
                    if (prevStep == StepEnum.FIRST)
                    {
                        nextStep = StepEnum.SECOND;
                        timerManager.Create(_window, Step.SECOND, StepEnum.SECOND)?.Start();
                    }
                    if (prevStep == StepEnum.SECOND)
                    {
                        nextStep = StepEnum.THIRD;
                        timerManager.Create(_window, Step.THIRD, StepEnum.THIRD)?.Start();
                    }
                    if (prevStep == StepEnum.THIRD)
                    {
                        nextStep = StepEnum.FOURTH;
                        timerManager.Create(_window, Step.FOURTH, StepEnum.FOURTH)?.Start();
                    }
                    break;
                case StepEnum.LONG_BREAK:
                    nextStep = StepEnum.READY;
                    break;
            }
            _window.Dispatcher.Invoke(() => _window.stepTextBlock.Text = typeof(StepEnum).GetEnumName(nextStep));
        }
    }
}

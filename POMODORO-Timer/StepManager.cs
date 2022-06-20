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
        private StepEnum prevStep = StepEnum.L_BREAK;
        private StepEnum currentStep = StepEnum.FIRST;
        private StepEnum nextStep = StepEnum.BREAK;
        private MainWindow _window = null;

        public StepManager(MainWindow window)
        {
            timerManager = new TimerManager(this, window);
            _window = window;
        }

        public void StartPomodoro()
        {
            if (!timerManager.Start())
            {
                timerManager = new TimerManager(this, _window);
                timerManager.Start();
            }
            _window.stepTextBlock.Text = typeof(StepEnum).GetEnumName(currentStep);
        }

        public void Pause()
        {
            if (timerManager.Pause())
                _window.stepTextBlock.Text = "PAUSE";
        }

        public void Reset()
        {
            if (timerManager.Reset())
            {
                prevStep = StepEnum.L_BREAK;
                currentStep = StepEnum.FIRST;
                nextStep = StepEnum.BREAK;
                _window.stepTextBlock.Text = "FIRST";
                _window.timerTextBlock.Text = "00:00:00";
            }
        }

        public void Prev()
        {

        }

        public void Next()
        {
            if (currentStep == StepEnum.FIRST)
            {
                if (timerManager.Next(StepEnum.BREAK))
                {
                    prevStep = StepEnum.FIRST;
                    currentStep = StepEnum.BREAK;
                    nextStep = StepEnum.SECOND;
                }
            }
            else if (currentStep == StepEnum.SECOND)
            {
                if (timerManager.Next(StepEnum.BREAK))
                {
                    prevStep = StepEnum.SECOND;
                    currentStep = StepEnum.BREAK;
                    nextStep = StepEnum.THIRD;
                }
            }
            else if (currentStep == StepEnum.THIRD)
            {
                if (timerManager.Next(StepEnum.BREAK))
                {
                    prevStep = StepEnum.THIRD;
                    currentStep = StepEnum.BREAK;
                    nextStep = StepEnum.FOURTH;
                }
            }
            else if (currentStep == StepEnum.FOURTH)
            {
                if (timerManager.Next(StepEnum.L_BREAK))
                {
                    prevStep = StepEnum.FOURTH;
                    currentStep = StepEnum.L_BREAK;
                    nextStep = StepEnum.FIRST;
                }
            }
            else if (currentStep == StepEnum.BREAK)
            {
                if (timerManager.Next(nextStep))
                {
                    prevStep = StepEnum.BREAK;
                    currentStep = nextStep;
                    nextStep = StepEnum.BREAK;
                }
            }
            else if (currentStep == StepEnum.L_BREAK)
            {
                if (timerManager.Next(StepEnum.FIRST))
                {
                    prevStep = StepEnum.L_BREAK;
                    currentStep = StepEnum.FIRST;
                    nextStep = StepEnum.BREAK;
                }
            }
            _window.stepTextBlock.Text = typeof(StepEnum).GetEnumName(currentStep);
        }

        public void Finished(StepEnum stepEnum)
        {
            Next();
            timerManager.Start();
        }
    }
}

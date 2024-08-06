using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace POMODORO_Timer
{
    public class StepManager : NotifyChanged, IDisposable
    {
        private WaveOut player = new WaveOut();
        private TimerManager timerManager;
        private StepEnum prevStep = StepEnum.L_BREAK;
        private StepEnum currentStep = StepEnum.FIRST;
        private StepEnum nextStep = StepEnum.BREAK;
        private MainWindow _window = null;

        public StepManager(MainWindow window)
        {
            timerManager = new TimerManager(this, window);
            _window = window;
            _window.stepTextBlock.Text = typeof(StepEnum).GetEnumName(StepEnum.FIRST);
            _window.timerTextBlock.Text = TimeSpan.FromMinutes(Step.FIRST).ToString();
        }

        public void StartPomodoro()
        {
            if (timerManager.Start())
                _window.stepTextBlock.Text = typeof(StepEnum).GetEnumName(currentStep);
        }

        public void Pause()
        {
            if (timerManager.Pause())
                _window.stepTextBlock.Text = "PAUSE";
        }

        public void Reset()
        {
            if (timerManager.CanMove())
            {
                if (timerManager.Reset())
                {
                    prevStep = StepEnum.L_BREAK;
                    currentStep = StepEnum.FIRST;
                    nextStep = StepEnum.BREAK;
                    _window.stepTextBlock.Text = typeof(StepEnum).GetEnumName(StepEnum.FIRST);
                    _window.timerTextBlock.Text = TimeSpan.FromMinutes(Step.FIRST).ToString();
                    timerManager = new TimerManager(this, _window);
                }
            }
        }

        public void Prev()
        {
            if (timerManager.CanMove())
            {
                if (currentStep == StepEnum.FIRST)
                {
                    if (timerManager.MoveStep(StepEnum.L_BREAK))
                    {
                        prevStep = StepEnum.FOURTH;
                        currentStep = StepEnum.L_BREAK;
                        nextStep = StepEnum.FIRST;
                    }
                }
                else if (currentStep == StepEnum.SECOND)
                {
                    if (timerManager.MoveStep(StepEnum.BREAK))
                    {
                        prevStep = StepEnum.FIRST;
                        currentStep = StepEnum.BREAK;
                        nextStep = StepEnum.SECOND;
                    }
                }
                else if (currentStep == StepEnum.THIRD)
                {
                    if (timerManager.MoveStep(StepEnum.BREAK))
                    {
                        prevStep = StepEnum.SECOND;
                        currentStep = StepEnum.BREAK;
                        nextStep = StepEnum.THIRD;
                    }
                }
                else if (currentStep == StepEnum.FOURTH)
                {
                    if (timerManager.MoveStep(StepEnum.BREAK))
                    {
                        prevStep = StepEnum.THIRD;
                        currentStep = StepEnum.BREAK;
                        nextStep = StepEnum.FOURTH;
                    }
                }
                else if (currentStep == StepEnum.BREAK)
                {
                    if (timerManager.MoveStep(prevStep))
                    {
                        currentStep = prevStep;
                        prevStep = StepEnum.BREAK;
                        nextStep = StepEnum.BREAK;
                    }
                }
                else if (currentStep == StepEnum.L_BREAK)
                {
                    if (timerManager.MoveStep(StepEnum.FOURTH))
                    {
                        prevStep = StepEnum.BREAK;
                        currentStep = StepEnum.FOURTH;
                        nextStep = StepEnum.L_BREAK;
                    }
                }
                _window.stepTextBlock.Text = typeof(StepEnum).GetEnumName(currentStep);
                _window.timerTextBlock.Text = TimeSpan.FromMinutes(Step.GetTimeFromStepEnum(currentStep)).ToString();
            }
        }

        public void Next()
        {
            if (timerManager.CanMove())
            {
                if (currentStep == StepEnum.FIRST)
                {
                    if (timerManager.MoveStep(StepEnum.BREAK))
                    {
                        prevStep = StepEnum.FIRST;
                        currentStep = StepEnum.BREAK;
                        nextStep = StepEnum.SECOND;
                    }
                }
                else if (currentStep == StepEnum.SECOND)
                {
                    if (timerManager.MoveStep(StepEnum.BREAK))
                    {
                        prevStep = StepEnum.SECOND;
                        currentStep = StepEnum.BREAK;
                        nextStep = StepEnum.THIRD;
                    }
                }
                else if (currentStep == StepEnum.THIRD)
                {
                    if (timerManager.MoveStep(StepEnum.BREAK))
                    {
                        prevStep = StepEnum.THIRD;
                        currentStep = StepEnum.BREAK;
                        nextStep = StepEnum.FOURTH;
                    }
                }
                else if (currentStep == StepEnum.FOURTH)
                {
                    if (timerManager.MoveStep(StepEnum.L_BREAK))
                    {
                        prevStep = StepEnum.FOURTH;
                        currentStep = StepEnum.L_BREAK;
                        nextStep = StepEnum.FIRST;
                    }
                }
                else if (currentStep == StepEnum.BREAK)
                {
                    if (timerManager.MoveStep(nextStep))
                    {
                        prevStep = StepEnum.BREAK;
                        currentStep = nextStep;
                        nextStep = StepEnum.BREAK;
                    }
                }
                else if (currentStep == StepEnum.L_BREAK)
                {
                    if (timerManager.MoveStep(StepEnum.FIRST))
                    {
                        prevStep = StepEnum.L_BREAK;
                        currentStep = StepEnum.FIRST;
                        nextStep = StepEnum.BREAK;
                    }
                }
                _window.stepTextBlock.Text = typeof(StepEnum).GetEnumName(currentStep);
                _window.timerTextBlock.Text = TimeSpan.FromMinutes(Step.GetTimeFromStepEnum(currentStep)).ToString();
            }
        }

        public void Finished(StepEnum stepEnum)
        {
            _window.Dispatcher.Invoke(() => Next());
            Mp3FileReader mp3FileReader = new Mp3FileReader(@"alarm.mp3");
            player.Init(mp3FileReader);
            player.Play();
            timerManager.Start();
        }

        public void Dispose()
        {
            player.Dispose();
        }
    }
}

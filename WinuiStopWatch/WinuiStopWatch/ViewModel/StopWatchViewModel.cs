
using Microsoft.AspNetCore.Components;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using WinuiStopWatch.Command;

namespace WinuiStopWatch.ViewModel
{
    public class StopWatchViewModel

    {
        private const string _starttimerdisplay = "00:00:00";
         private Stopwatch _stopwatch;
         private Timer _timer;

         private string _timerDisplay;
         public string TimerDisplay
         {
             get { return _timerDisplay; }
             set { _timerDisplay = value; }
         }


         public StopWatchViewModel()
         {
             TimerDisplay = _starttimerdisplay;
             _stopwatch=new Stopwatch();
             _timer = new Timer(interval: 1000);
             _timer.Elapsed += OnTimerElapse;
         }

         private void OnTimerElapse(object sender, ElapsedEventArgs e)
         {
           
         }


        private ICommand _startButton;
        public ICommand StartButton
        {
            get
            {
                if (_startButton == null)
                {
                    _startButton = new ButtonCommand(StartExecute, CanStartExecute);
                }
                return _startButton;
            }
            set
            {
                _startButton = value;
            }
        }

      

        private bool CanStartExecute(object arg)
        {
            return true;
        }

        private void StartExecute(object obj)
        {
           _stopwatch.Start();
            _timer.Start();
            
            
           
        }


        private ICommand _stopButton;
        public ICommand StopButton
        {
            get
            {
                if (_stopButton == null)
                {
                    _stopButton = new ButtonCommand(StopExecute, CanStopExecute);
                }
                return _stopButton;
            }
            set
            {
                _stopButton = value;
            }
        }



        private bool CanStopExecute(object arg)
        {
            return true;
        }

        private void StopExecute(object obj)
        {
            _stopwatch.Stop();
            _timer.Stop();

        }


        private ICommand _resumeButton;
        public ICommand ResumeButton
        {
            get
            {
                if (_resumeButton == null)
                {
                    _resumeButton = new ButtonCommand(ResumeExecute, CanResumeExecute);
                }
                return _resumeButton;
            }
            set
            {
                _resumeButton = value;  
            }
        }



        private bool CanResumeExecute(object arg)
        {
            return true;
        }

        private void ResumeExecute(object obj)
        {
            _stopwatch.Reset();
            TimerDisplay = _starttimerdisplay;

        }

        /*  DispatcherTimer dispatchertimer;
          int timetick = 1;
          int timeToTick = 50;

          public void DispatcherTimerSetup()
          {
              dispatchertimer = new DispatcherTimer();
              dispatchertimer.Tick += dispatcherTimer_Tick;

              dispatchertimer.Interval = new TimeSpan(0, 0, 1);

              dispatchertimer.Start();
              TimerDisplay = _starttimerdisplay;

          }
          void dispatcherTimer_Tick(object sender, object e)

          {

              TimerDisplay=timetick.ToString();

              if (timetick > timeToTick)

              {

                 TimerDisplay = "Calling dispatcherTimer.Stop()\n";

                  dispatchertimer.Stop();

                  TimerDisplay = "dispatcherTimer.IsEnabled = " + dispatchertimer.IsEnabled + "\n";

              }

             timetick++;

          }*/



    }
}

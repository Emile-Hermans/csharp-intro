using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockExercise
{
    internal class Clock
    {
        private int TotalSeconds;

        private const int SecondsPerMinute = 60;

        private const int SecondsPerHour = 60 * 60;

        private const int SecondsPerDay = 60 * 60 * 24;

        public Clock(ITimerService timer)
        {
            timer.Tick += this.OnTick;
        }

        private void OnTick()
        {
            TotalSeconds++;

            NotifyObservers();
        }

        private void NotifyObservers()
        {
            NotifySecondObservers();
            NotifyMinuteObservers();
            NotifyHourObservers();
            NotifyDayObservers();
        }

        private void NotifySecondObservers()
        {
            SecondPassed?.Invoke(TotalSeconds);
        }

        public void NotifyMinuteObservers()
        {
            if (TotalSeconds % SecondsPerMinute == 0)
            {
                MinutePassed?.Invoke(TotalSeconds / SecondsPerMinute);
            }
        }

        public void NotifyHourObservers()
        {
            if (TotalSeconds % SecondsPerHour == 0)
            {
                HourPassed?.Invoke(TotalSeconds / SecondsPerHour);
            }
        }

        public void NotifyDayObservers()
        {
            if (TotalSeconds % SecondsPerDay == 0)
            {
                DayPassed?.Invoke(TotalSeconds / SecondsPerDay);
            }
        }


        public event Action<int> SecondPassed;

        public event Action<int> MinutePassed;

        public event Action<int> HourPassed;

        public event Action<int> DayPassed;
    }
}

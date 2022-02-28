using System;
using System.Collections.Generic;
using System.Text;

namespace TimeExercise
{
    internal class Time
    {
        private const int MinutesPerHour = 60;

        private const int SecondsPerMinute = 60;

        public Time(int hours, int minutes, int seconds)
        {
            TotalSeconds = hours * MinutesPerHour * SecondsPerMinute + minutes * SecondsPerMinute + seconds;
        }

        public int TotalSeconds { get; }
        
        public int Hours => TotalSeconds / MinutesPerHour / SecondsPerMinute; 
        

        public int Minutes => TotalSeconds/ SecondsPerMinute % MinutesPerHour;
        public int Seconds => TotalSeconds % SecondsPerMinute;
    }
}

using System;

namespace CleanCode.DuplicatedCode
{
    internal class DuplicatedCode
    {
       public class Time
        {
            public int Hours { get; set; }
            public int Minutes { get; set; }
            public Time(int hours, int minutes)
            {
                Hours = hours;
                Minutes = minutes;
            }
        }
        public void AdmitGuest(string name, string admissionDateTime)
        {
            // Some logic
            // ...
            var time = GetTime(admissionDateTime);
            var hours = time.Hours;
            var minutes = time.Minutes;
            // Some more logic
            // ...
            if (hours < 10)
            {
            }
        }

        public void UpdateAdmission(int admissionId, string name, string admissionDateTime)
        {
            // Some logic
            // ...

            var time = GetTime(admissionDateTime);
            var hours = time.Hours;
            var minutes = time.Minutes;

            // Some more logic
            // ...
            if (hours < 10)
            {
            }
        }

        private static Time GetTime( string admissionDateTime)
        {
            int time;
            int hours = 0;
            int minutes = 0;
            if (!string.IsNullOrWhiteSpace(admissionDateTime))
            {
                if (int.TryParse(admissionDateTime.Replace(":", ""), out time))
                {
                    hours = time / 100;
                    minutes = time % 100;
                }
                else
                {
                    throw new ArgumentException("admissionDateTime");
                }
            }
            else
                throw new ArgumentNullException("admissionDateTime");
            return new Time(hours,minutes);
        }
    }
}
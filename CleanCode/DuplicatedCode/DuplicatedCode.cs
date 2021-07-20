using System;

namespace CleanCode.DuplicatedCode
{
    internal class DuplicatedCode
    {
        public  class Time
        {
            public int Hours { get; set; }
            public int Minutes { get; set; }

            public Time(int hours, int minutes)
            {
                Hours = hours;
                Minutes = minutes;
            }
            public static Time Parse(string timeString)
            {
                int time;
                int hours;
                int minutes;
                if (!string.IsNullOrWhiteSpace(timeString))
                {
                    if (int.TryParse(timeString.Replace(":", ""), out time))
                    {
                        hours = time / 100;
                        minutes = time % 100;
                    }
                    else
                    {
                        throw new ArgumentException("timeString");
                    }
                }
                else
                    throw new ArgumentNullException("timeString");
                return new Time(hours, minutes);
            }
        }

        public void AdmitGuest(string name, string admissionDateTime)
        {
            // Some logic
            // ...
            var time = Time.Parse(admissionDateTime);
            // Some more logic
            // ...
            if (time.Hours < 10)
            {
            }
        }

        public void UpdateAdmission(int admissionId, string name, string admissionDateTime)
        {
            // Some logic
            // ...

            var time = Time.Parse(admissionDateTime);

            // Some more logic
            // ...
            if (time.Hours < 10)
            {
            }
        }
       

    }
}
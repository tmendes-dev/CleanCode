using System;

namespace CleanCode.DuplicatedCode
{
    internal class DuplicatedCode
    {
        public void AdmitGuest(string name, string admissionDateTime)
        {
            // Some logic
            // ...
            int hours;
            int minutes;
            GetTime(out hours, admissionDateTime, out minutes);
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

            int hours;
            int minutes;
            GetTime(out hours, admissionDateTime, out minutes);

            // Some more logic
            // ...
            if (hours < 10)
            {
            }
        }

        private static void GetTime(out int hours, string admissionDateTime, out int minutes)
        {
            int time;
            hours = 0;
            minutes = 0;
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
        }
    }
}
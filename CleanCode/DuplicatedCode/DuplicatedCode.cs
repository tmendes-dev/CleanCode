using System;

namespace CleanCode.DuplicatedCode
{
    internal class DuplicatedCode
    {
        public void AdmitGuest(string name, string admissionDateTime)
        {
            // Some logic
            // ...
            var tuple = GetTime(admissionDateTime);
            var hours = tuple.Item1;
            var minutes = tuple.Item2;
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

            var tuple = GetTime(admissionDateTime);
            var hours = tuple.Item1;
            var minutes = tuple.Item2;

            // Some more logic
            // ...
            if (hours < 10)
            {
            }
        }

        private static Tuple<int,int> GetTime( string admissionDateTime)
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
            return Tuple.Create(hours,minutes);
        }
    }
}
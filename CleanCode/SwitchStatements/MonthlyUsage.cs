using System;

namespace CleanCode.SwitchStatements
{
    public class MonthlyUsage
    {
        public Customer Customer { get; set; }
        public int CallMinutes { get; set; }
        public int SmsCount { get; set; }

        public void Generate(MonthlyStatement monthlyStatement)
        {
            switch (Customer.Type)
            {
                case CustomerType.PayAsYouGo:
                    monthlyStatement.CallCost = 0.12f * CallMinutes;
                    monthlyStatement.SmsCost = 0.12f * SmsCount;
                    monthlyStatement.TotalCost = monthlyStatement.CallCost + monthlyStatement.SmsCost;
                    break;

                case CustomerType.Unlimited:
                    monthlyStatement.TotalCost = 54.90f;
                    break;

                default:
                    throw new NotSupportedException("The current customer type is not supported");
            }
        }
    }
}
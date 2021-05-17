using System;

namespace CleanCode.NestedConditionals
{
    public class Customer
    {
        public int LoyaltyPoints { get; set; }
    }

    public class Reservation
    {
        public Reservation(Customer customer, DateTime dateTime)
        {
            From = dateTime;
            Customer = customer;
        }

        public DateTime From { get; set; }
        public Customer Customer { get; set; }
        public bool IsCanceled { get; set; }

        public void Cancel()
        {
            if (IsCancellationPeriodOver())
                throw new InvalidOperationException("It's too late to cancel.");

            IsCanceled = true;
        }

        private bool IsCancellationPeriodOver()
        {
            return (IsGoldCostumer() && LessThen(24)) || !IsGoldCostumer() && LessThen(48);
        }

        private bool IsGoldCostumer()
        {
            return Customer.LoyaltyPoints > 100;
        }

        private bool LessThen(int maxHours)
        {
            return (From - DateTime.Now).TotalHours < maxHours;
        }
    }
}
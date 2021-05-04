using CleanCode.Comments;
using System;
using System.Collections.Generic;

namespace CleanCode.OutputParameters
{
    public class OutputParameters
    {
        public class GetCustomersResult
        {
            public IEnumerable<Customer> Costumers { get; private set; }
            public int TotalCount { get; private set; }

            public GetCustomersResult(int totalCount, IEnumerable<Customer> costumers)
            {
                Costumers = costumers;
                TotalCount = totalCount;
            }
        }
        public void DisplayCustomers()
        {
            GetCustomersResult result = GetCustomers(pageIndex:1);
            IEnumerable<Customer> customers = result.Costumers; 

            Console.WriteLine("Total customers: " + result.TotalCount);
            foreach (Customer c in customers)
                Console.WriteLine(c);
        }

        public GetCustomersResult GetCustomers(int pageIndex)
        {
            var totalCount = 100;
            return new GetCustomersResult(totalCount, new List<Customer>());
        }
    }
}

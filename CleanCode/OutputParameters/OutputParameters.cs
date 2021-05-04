using CleanCode.Comments;
using System;
using System.Collections.Generic;

namespace CleanCode.OutputParameters
{
    public class OutputParameters
    {
        public class GetCustomersResult
        {
            public IEnumerable<Customer> Costumers { get; set; }
            public int TotalCount { get; set; }

            public GetCustomersResult(int totalCount, IEnumerable<Customer> costumers)
            {
                Costumers = costumers;
                TotalCount = totalCount;
            }
        }
        public void DisplayCustomers()
        {
            int totalCount;
            var tuple = GetCustomers(1);
            totalCount = tuple.TotalCount;
            var customers = tuple.Costumers;

            Console.WriteLine("Total customers: " + totalCount);
            foreach (var c in customers)
                Console.WriteLine(c);
        }

        public GetCustomersResult GetCustomers(int pageIndex)
        {
            var totalCount = 100;
            return new GetCustomersResult(totalCount, new List<Customer>());
        }
    }
}

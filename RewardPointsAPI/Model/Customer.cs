using System.Collections.Generic;

namespace RewardPoints
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
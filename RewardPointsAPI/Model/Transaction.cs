using System;
namespace RewardPoints
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Expense { get; set; }
    }
}
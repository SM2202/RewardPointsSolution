using System.Collections.Generic;

namespace RewardPoints
{
    public class CustomerTransaction
    {
        public int CustomerId { get; set; }
        public Dictionary<int, int> MonthlyRewards { get; set; } = new Dictionary<int, int>();
        public int TotalRewards { get; set; }
    }
}
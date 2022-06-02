using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace RewardPoints
{
    /// <summary>
    /// Reward Point Controller
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/rewards")]
    public class RewardPointController : Controller
    {
        /// <summary>
        /// Get Reward Points For AllCustomers
        /// </summary>
        [HttpGet]
        public IActionResult GetRewardsForAllCustomer()
        {
            try
            {
                var customers = new List<Customer>();
                var customerTransactions = new List<CustomerTransaction>();
                using (StreamReader r = new StreamReader("Data\\DataSet.json"))
                {
                    string json = r.ReadToEnd();
                    customers = JsonConvert.DeserializeObject<List<Customer>>(json);
                }
                if (customers?.Count() > 0)
                {
                    foreach (var customer in customers)
                    {
                        var customerTransaction = GetMonthlyRewards(customer);

                        // calculates total rewards on the basis of monthly rewards.
                        customerTransaction.TotalRewards = customerTransaction.MonthlyRewards.Select(x => x.Value).Sum();
                        customerTransactions.Add(customerTransaction);
                    }
                }
                return Ok(customerTransactions);
            }
            catch (Exception ex)
            {
                return this.StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
        
        /// <summary>
        /// Calculate Rewards For Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CalculateRewardsForCustomer(Customer customer)
        {
            try
            {
                var customerTransaction = GetMonthlyRewards(customer);

                // calculates total rewards on the basis of monthly rewards.
                customerTransaction.TotalRewards = customerTransaction.MonthlyRewards.Select(x => x.Value).Sum();

                return Ok(customerTransaction);
            }
            catch (Exception ex)
            {
                return this.StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Calculate Monthly Rewards For Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        private CustomerTransaction GetMonthlyRewards(Customer customer)
        {
            var customerTransaction = new CustomerTransaction();

            customerTransaction.CustomerId = customer.CustomerId;

            List<int> months = new List<int>();

            // Gets list of distinct months.
            months = customer.Transactions.Select(x => x.TransactionDate.Month).Distinct().ToList();

            customerTransaction.MonthlyRewards = new Dictionary<int, int>();

            for (int i = 0; i < months.Count; i++)
            {
                // gets monthly expense of the customer
                var monthlyExpense = customer.Transactions.Where(x => x.TransactionDate.Month == months[i]).Select(x => x.Expense).Sum();

                var monthlyReward = GetRewards(monthlyExpense);

                // Add monthly rewards in dictionary
                customerTransaction.MonthlyRewards.Add(months[i], monthlyReward);
            }
            return customerTransaction;
        }

        /// <summary>
        /// Returns Rewards on the basis of expense
        /// </summary>
        /// <param name="expense"></param>
        /// <returns></returns>
        private int GetRewards(int expense)
        {
            int rewards = 0;
            if (expense > 50)
            {
                rewards = expense - 50;
                if (expense > 100)
                {
                    rewards += expense - 100;
                }
            }
            return rewards;
        }
    }
}
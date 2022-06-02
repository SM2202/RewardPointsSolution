using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.AspNetCore.Mvc;

namespace RewardPoints.Tests
{
    [TestClass]
    public class RewardPointControllerTests
    {
        [TestMethod]
        public void CalculateRewardsPerMonthTest()
        {
            // Arrange
            var controller = new RewardPointController();
            var input = InitializeData();
            dynamic output = null;

            // Act
            var actionResult = controller.CalculateRewardsForCustomer(input);
            output = typeof(OkObjectResult).GetProperty("Value").GetValue(Convert.ChangeType(actionResult, typeof(OkObjectResult)));
            var result = (CustomerTransaction)output;

            // Assert
            Assert.IsNotNull(actionResult);
            
            Assert.AreEqual(actionResult.GetType(), typeof(OkObjectResult));
            
            Assert.IsTrue(result.MonthlyRewards.ContainsKey(05));
            Assert.AreEqual(result.MonthlyRewards[05], 90);
        }
        private Customer InitializeData()
        {
            var customer = new Customer();
            customer.CustomerId = 1;
            customer.CustomerName = "Customer1";

            customer.Transactions.Add(new Transaction()
            {
                TransactionId = 1,
                TransactionDate = Convert.ToDateTime("05/01/2022"),
                Expense = 120
            });
            return customer;
        }
    }
}

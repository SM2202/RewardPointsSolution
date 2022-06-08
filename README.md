# Reward Points Solution
## Technical Stack Used: C# .NET MVC
## Tools Required: Visual Studio Code Or Visual Studio
### How To Run the Project 
**Prerequisite: .NET Core 3.1 RunTime (LTS)**
Git clone the repository
#### In Visual Studio Code

1. Open the RewardPointsAPI folder.
1. Build the project from Terminal window with: dotnet build
1. Run the Project from Terminal window with: dotnet run
#### In Visual Studio
1. Clean the solution, rebuild
2. Run the Project

To access rewards controller: https://localhost:54761/api/rewards

You can access the **Swagger UI** by link: https://localhost:54761/swagger/index.html 

### Project Details
There are two folders:
**RewardPointsAPI and RewardPointsTests**

RewardPointsTests contains Unit Test.

#### RewardPointsAPI
1. Data used in the project is saved in DataSet.json file.
1. HealthController to Check health of API
2. RewardPointController contains two method:
   1. GetRewardsForAllCustomer(): Calculate the monthly and total reward points for customer details present in DataSet.json.
   2. CalculateRewardsForCustomer(Customer customer): Calculate monthly and total reward points for customer details passed as input parameter.

### DataSet
#### Input:
   
| CustomerID  | TransactinDate | Expense |
| ----------- | -----------    | ------- |
| 1           | 2022-06-01     | 120     |
| 1           | 2022-06-01     | 100     |
| 1           | 2022-07-01     | 10      |
| 2           | 2022-06-01     | 120     |
| 3           | 2022-06-01     | 200     |

#### Output:
**Monthly Rewards:**

| CustomerID  | Month | Rewards |
| ----------- | ------| ------- |
| 1           | 06    | 290     |
| 1           | 07    | 0       |
| 2           | 06    | 90      |
| 3           | 06    | 250     |

**Total Rewards:**
| CustomerID  | Rewards |
| ----------- | ------- | 
| 1           | 290     |
| 2           | 90      |
| 3           | 250     |

**Screenshot From Swagger UI:**

![GetRewardsForAllCustomers](https://github.com/SM2202/RewardPointsSolution/blob/main/TestImages/GetRewardsForAllCustomers.png)

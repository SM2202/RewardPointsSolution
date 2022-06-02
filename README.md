# Reward Points Solution
## Technical Stack Used: C# .NET MVC
## Tools Required: Visual Studio Code Or Visual Studio
### How To Run the Project 
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

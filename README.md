# FarmersOnlyBudget
Farmers only budget is a budgeting application that is meant to replace applications like EveryDollar.com and RocketMortgage.com. This application is not meant for broad commercial use, however, based on the application's state and services in the distant future, the application could be placed in the open market. For the near future, this application will remain as an application solely for the developer to use.

# Technical Aspects

The technical design of this application is pretty straight forward, with few extremely advanced features - the most advanced feature being decimal arithmetic precision, and sockets (ASP.NET Core SignalR). This application will be built with the following major technologies.

| **Technologies** | Version |
| ---------------- | ------- |
| ASP.NET Core     | .NET 8  |
| Postgres SQL     | v17.1   |
| Angular          | v18.0   |
| REST             | n/a     |
## Database Design

The application will use PostgresSQL for all database operations - may incorporate SQLite if there is a need for a runtime level database, but that is unlikely. The database will have several tables pertaining to users, budgeting years/months, budget line items, and transactions. The initial schema is simplistic in nature, and should not be too complex to configure and use. However, revisions may be needed as development progresses.

The database design is as follows.

```mermaid
erDiagram

    User ||--o{ YearBudget : has

    YearBudget ||--o{ MonthBudget : has  

    YearBudget ||--|| BudgetAmount : has

    MonthBudget ||--o{ BudgetItem : has

    MonthBudget ||--|| BudgetAmount : has

    BudgetItem ||--o{ Transaction : has

    Category ||--|| BudgetItem : has

    BudgetItem ||--o{ SplitTransaction : has

    Transaction ||--o{ SplitTransaction : has

  

    User {

        int UserId PK

        string NameFirst

        string NameFull

        string Email

        string Phone

    }

  

    YearBudget {

        int UserId PK

        int YearBudgetId FK

        int YearType "Enum with the specified year"

        int BudgetAmountId FK

    }

  

    MonthBudget {

        int MonthBudgetId PK

        int YearBudgetId FK

        int MonthType "Enum with specified month"

        int BudgetAmountId FK

    }

  

    BudgetItem {

        int BudgetItemId

        int MonthBudgetId FK

        int BudgetAmountId FK

        int CategoryId FK

    }

  

    Category {

        int CategoryId PK

        string Name

    }

  

    BudgetAmount {

        int BudgetAmountId PK

        decimal Amount

        decimal Remaining "Total amount remaining after all transactions have been applied"

    }

  

    Transaction {

        int TransactionId PK

        int BudgetItemId FK

        decimal Amount

        string Name

        date TransactionDate "Date transaction was made."

    }

  

    SplitTransaction {

        int PrincipleTransactionId PK

        int BudgetItemId FK

        decimal Amount

    }
```

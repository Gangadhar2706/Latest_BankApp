using BankApplication.Models;

namespace BankApplication.Data
{
    public static class InMemoryDataContext
    {
        public static List<BankAccount> BankAccounts = new List<BankAccount>
        {
            new BankAccount { Id = 1, AccountType = "saving", Balance = 1000.50m, AccountHolder = "XXX" },
            new BankAccount { Id = 2, AccountType = "current", Balance = 500.75m, AccountHolder = "YYYY" },
            new BankAccount { Id = 3, AccountType = "salary", Balance = 50000, AccountHolder = "ZZZ" }
        };
    }
}

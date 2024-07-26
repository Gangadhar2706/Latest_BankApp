using System;
using MediatR;

using BankApplication.Models;
using BankApplication.Controllers;
using BankApplication.Features.BankAccounts;

namespace TestProject
{
    public class HandlersUnitTestcases
    {

        [Fact]
        public async Task RetrieveBankAccountsbyType()
        {
            // Arrange
            var Accounttype = "saving";
            var handler = new GetBankAccountsByTypeHandler();
            var query = new GetBankAccountsByTypeQuery(Accounttype);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);
            // Assert
            Assert.NotNull(result);
        }
        [Fact]
        public async Task RetrieveBankAccountsbyID()
        {
            // Arrange
            var Accountid = 1;
            var handler = new GetBankAccountsByIDHandler();
            var query = new GetAccountByIdQuery(Accountid);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert          
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task CanRetrieveAccountsByType1()
        {
            // Arrange         
            var bank = new BankAccount { Id = 1, AccountType = "Savings", Balance = 1000.50m, AccountHolder = "XXX" };
            var handler = new UpdateBankAccountHandler();
            var command = new UpdateBankAccountCommand { Id = 1, Balance = 1500 };
        
            // Act
            var result = await handler.Handle(command, CancellationToken.None);
            // Assert
            Assert.Equal(1500, result.Balance);
        }


    }
}
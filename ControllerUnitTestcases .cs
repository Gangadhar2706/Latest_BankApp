using System;
using MediatR;
using Moq;
using BankApplication.Models;
using BankApplication.Controllers;
using BankApplication.Features.BankAccounts;
using Microsoft.AspNetCore.Mvc;
using Castle.Components.DictionaryAdapter.Xml;

namespace TestProject
{
    public class ControllerUnitTestcases
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly BankAccountsController _controller;
        public ControllerUnitTestcases()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new BankAccountsController(_mediatorMock.Object);
        }
        [Fact]
        public async Task GetBankAccountsByType__WhenSuccessful()
        {
            // Arrange
            var accountType = "Savings";
            var accounts = new List<BankAccount>
            {
                new BankAccount { Id = 1, AccountType = "Savings", AccountHolder = "xxx", Balance = 1000 }
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetBankAccountsByTypeQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(accounts);

            // Act
            var result = await _controller.RetrieveBankAccountsbyType(accountType);

            // Assert
            Assert.NotNull(result);
        }
        [Fact]
        public async Task GetBankAccountsByID_WhenSuccessful()
        {
            // Arrange
            var accountTypeID =1;
          
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetBankAccountsByIDHandler>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(accountTypeID);

            // Act
            var result = await _controller.RetrieveSpecificBankAccount(accountTypeID);

            // Assert
            Assert.NotNull(result);

        }
        [Fact]
        public async Task UpdateBankAccount_WhenSuccessful()
        {
            // Arrange
            var command = new UpdateBankAccountCommand { Id = 1, AccountType = "saving", Balance = 1000.50m, AccountHolder = "XXX" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateBankAccountHandler>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.UpdateBankAccount(command.Id,command);

            // Assert
            Assert.NotNull(result);;
        }

    }
}
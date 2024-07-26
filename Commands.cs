using BankApplication.Models;
using MediatR;
using System.Security.Principal;

namespace BankApplication.Features.BankAccounts
{
    public class UpdateBankAccountCommand : IRequest<BankAccount>
    {
        public int Id { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public string AccountHolder { get; set; }
    }

    // Queries/GetAccountByIdQuery.cs
    public class GetAccountByIdQuery : IRequest<BankAccount>
    {
        public int Id { get; set; }
        public GetAccountByIdQuery(int id)
        {
            Id = id;
        }
    }
}

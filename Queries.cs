using BankApplication.Models;
using MediatR;

namespace BankApplication.Features.BankAccounts
{
    public class GetBankAccountsByTypeQuery : IRequest<IEnumerable<BankAccount>>
    {
        public string AccountType { get; set; }

        public GetBankAccountsByTypeQuery(string accountType)
        {
            AccountType = accountType;
        }

    }
}

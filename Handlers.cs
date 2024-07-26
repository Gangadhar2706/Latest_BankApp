using BankApplication.Data;
using BankApplication.Models;
using MediatR;
using System.Security.Principal;

namespace BankApplication.Features.BankAccounts
{
    public class GetBankAccountsByTypeHandler : IRequestHandler<GetBankAccountsByTypeQuery, IEnumerable<BankAccount>>
    {
        public Task<IEnumerable<BankAccount>> Handle(GetBankAccountsByTypeQuery request, CancellationToken cancellationToken)
        {
            var accounts = InMemoryDataContext.BankAccounts
                .Where(a => a.AccountType.Equals(request.AccountType, System.StringComparison.OrdinalIgnoreCase))
                .ToList();
            return Task.FromResult<IEnumerable<BankAccount>>(accounts);
        }
       

    }
    public class GetBankAccountsByIDHandler : IRequestHandler<GetAccountByIdQuery, BankAccount>
    {
        public Task<BankAccount> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
            var account = InMemoryDataContext.BankAccounts.FirstOrDefault(a => a.Id == request.Id);
            return Task.FromResult(account);
        }
    }


    public class UpdateBankAccountHandler : IRequestHandler<UpdateBankAccountCommand, BankAccount>
    {
        public Task<BankAccount> Handle(UpdateBankAccountCommand request, CancellationToken cancellationToken)
        {
            var account = InMemoryDataContext.BankAccounts.FirstOrDefault(a => a.Id == request.Id);
            if (account != null)
            {
                account.AccountType = request.AccountType;
                account.Balance = request.Balance;
                account.AccountHolder = request.AccountHolder;
            }
            return Task.FromResult(account);
        }
    }
}

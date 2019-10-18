using MediatR;
using Accounts.Models;

namespace Accounts.Handlers
{
    public class PutAccountRequest : IRequest<AccountModel>
    {
        public string AccountId { get; set; }
        public AccountModel Account { get; set; }

        public PutAccountRequest(string accountId,  AccountModel account)
        {
            Account = account;
            AccountId = accountId;
            Account.AccountId = accountId;
        }
    }
}

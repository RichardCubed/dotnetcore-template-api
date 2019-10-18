using MediatR;
using Accounts.Models;

namespace Accounts.Handlers
{
    public class GetAccountRequest : IRequest<AccountModel>
    {
        public string AccountId { get; set; }

        public GetAccountRequest(string accountId)
        {
            AccountId = accountId;
        }
    }
}

using System.Threading;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using MediatR;
using Accounts.Middleware.Exceptions;
using Accounts.Models;

namespace Accounts.Handlers
{
    public class PutAccountHandler : IRequestHandler<PutAccountRequest, AccountModel>
    {
        protected readonly AmazonDynamoDBClient _client;
        protected readonly DynamoDBContext _context;

        public PutAccountHandler()
        {
            _client = new AmazonDynamoDBClient(Amazon.RegionEndpoint.USEast1);
            _context = new DynamoDBContext(_client);
        }

        public async Task<AccountModel> Handle(PutAccountRequest request, CancellationToken cancellationToken)
        {
            var account = await _context.LoadAsync<AccountModel>(request.AccountId);
            if (account == null)
            {
                throw new ObjectNotFoundException($"PutAccountHandler: AccountId {request.Account.AccountId} can not be found");
            }

            await _context.SaveAsync(request.Account);
            return request.Account;
        }
    }
}
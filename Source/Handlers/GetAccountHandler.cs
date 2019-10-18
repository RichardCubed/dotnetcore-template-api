using System.Threading;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using MediatR;
using Accounts.Middleware.Exceptions;
using Accounts.Models;

namespace Accounts.Handlers
{
    public class GetAccountHandler : IRequestHandler<GetAccountRequest, AccountModel>
    {
        protected readonly AmazonDynamoDBClient _client;
        protected readonly DynamoDBContext _context;

        public GetAccountHandler()
        {
            _client = new AmazonDynamoDBClient(Amazon.RegionEndpoint.USEast1);
            _context = new DynamoDBContext(_client);
        }

        public async Task<AccountModel> Handle(GetAccountRequest request, CancellationToken cancellationToken)
        {
            var account = await _context.LoadAsync<AccountModel>(request.AccountId);
            if (account == null)
            {
                throw new ObjectNotFoundException($"GetAccountHandler:  An AccountId {request.AccountId} can not be found");
            }

            return account;
        }
    }
}
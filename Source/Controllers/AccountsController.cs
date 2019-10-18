using System.Threading.Tasks;
using Accounts.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Accounts.Models;

namespace Accounts.Controllers
{
    /// <summary>
    /// Simple CRUD operations.  To keep a clean seperation of concerns all our business logic is 
    /// invoked using a simple "Mediator" pattern https://github.com/jbogard/MediatR.
    /// </summary>
    public class AccountsController : BaseController
    {
        public AccountsController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [Route("v1/accounts/{id}")]
        public async Task<ActionResult> Get(string id)
        {
            var result = await _mediator.Send(new GetAccountRequest(id));
            return StatusCode(200, result);
        }

        [HttpPut]
        [Route("v1/accounts/{id}")]
        public async Task<ActionResult> Put(string id, AccountModel account)
        {
            var result = await _mediator.Send(new PutAccountRequest(id, account));
            return StatusCode(200, result);
        }
    }
}
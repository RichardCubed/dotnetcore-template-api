using Amazon.DynamoDBv2;
using Amazon.XRay.Recorder.Handlers.AwsSdk;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Accounts.Filters;

namespace Accounts.Controllers
{
    /// <summary>
    /// The base class for all our controllers. We use Amazon XRay to track requests between services in
    /// our cluster and a ServiceFilter for some basic authentication.
    /// </summary>
    [ApiController]
    [ServiceFilter(typeof(AccountIdFilter))]
    public class BaseController : ControllerBase
    {
        protected IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            AWSSDKHandler.RegisterXRay<IAmazonDynamoDB>();
            _mediator = mediator;
        }

        protected string AccountId
        {
            get
            {
                return Request.HttpContext.Items["AccountId"].ToString();
            }
        }
    }
}
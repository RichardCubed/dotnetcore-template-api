using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Accounts.Controllers
{
    /// <summary>
    /// A simple health check endpoint used both internally (by the Docker process monitor) and 
    /// externally (via the AWS ALB) to monitor the health of the service.  
    /// </summary>
    [Route("accounts/health")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public HttpStatusCode Get()
        {
            return HttpStatusCode.OK;
        }
    }
}

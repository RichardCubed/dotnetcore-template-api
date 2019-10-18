using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Accounts.Middleware.Exceptions;

namespace Accounts.Filters
{
    /// <summary>
    /// Checks for the presence of a valid 'Account-Id' in the HTTP headers. If the field is missing or empty the connection is terminated.
    /// </summary> 
    public class AccountIdFilter : IActionFilter
    {   
        public bool AllowMultiple => false;

        public  void OnActionExecuting(ActionExecutingContext context)
        {
            // Check to see if the header is present
            if (!context.HttpContext.Request.Headers.TryGetValue("Account-Id", out StringValues accountId))
            {
                throw new UnauthorizedException("AccountFilter: The 'Account-Id' header is missing");
            }

            // Check to see if the header has a valid value
            if (string.IsNullOrEmpty(accountId))
            {
                throw new UnauthorizedException("AccountFilter: The 'Account-Id' header is empty or invalid");
            }

            // Add it to the context for use in the controllers
            context.HttpContext.Items.Add("AccountId", accountId);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            return;
        }
    }
}
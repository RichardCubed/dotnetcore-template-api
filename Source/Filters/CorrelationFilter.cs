using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

namespace Accounts.Filters
{
    /// <summary>
    /// The 'CorrelationFilter' checks for the presence of a valid 'Correlation-ID' in the header.  If
    /// we don't have one we'll create a new one
    /// </summary>
    public class CorrelationFilter : IActionFilter
    {   
        public bool AllowMultiple => false;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Check to see if the header is present
            if (context.HttpContext.Request.Headers.TryGetValue("Correlation-Id", out StringValues correlationId))
            {
                // Add it to the context for use in the controllers
                context.HttpContext.Items.Add("CorrelationId", correlationId);
            }
            else
            {
                // If we don't have a correlation-id we'll create a new one
                context.HttpContext.Items.Add("CorrelationId", Guid.NewGuid().ToString());
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            return;
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Accounts.Middleware.Exceptions;

namespace Accounts.Middleware
{
    /// <summary>
    /// The 'ErrorHandler' middleware is inserted in to HTTP pipeline to catch and log any
    /// exceptions that should result in specific HTTP status codes
    /// </summary>
    public class ErrorHandlerMiddleware
    {
        readonly ILogger _logger; 
        readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (UnauthorizedException ex)
            {
                _logger.LogError($"{ex.Message}");
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            }
            catch (ObjectNotFoundException ex)
            {
                _logger.LogError($"{ex.Message}");
                httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            }
        }
    }
}
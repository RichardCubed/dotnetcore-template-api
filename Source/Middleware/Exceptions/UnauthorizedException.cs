using System;

namespace Accounts.Middleware.Exceptions
{
    /// <summary>
    /// Thrown when a request can't be authorized resulting in an HTTP 401.
    /// </summary>
    [Serializable]
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException()
        {
        }

        public UnauthorizedException(string message)
            : base(message)
        {
        }

        public UnauthorizedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
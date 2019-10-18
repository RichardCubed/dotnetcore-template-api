using System;

namespace Accounts.Middleware.Exceptions
{
    /// <summary>
    /// Thrown when a request fails validations resulting in a HTTP 400.
    /// </summary>
    [Serializable]
    public class BadRequestException : Exception
    {
        public BadRequestException()
        {
        }

        public BadRequestException(string message)
            : base(message)
        {
        }

        public BadRequestException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
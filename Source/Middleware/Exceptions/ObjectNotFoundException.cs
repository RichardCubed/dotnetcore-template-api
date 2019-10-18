using System;

namespace Accounts.Middleware.Exceptions
{
    /// <summary>
    /// Thrown when the requested resource is not found resulting in an HTTP 404.
    /// </summary>
    [Serializable]
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException()
        {
        }

        public ObjectNotFoundException(string message)
            : base(message)
        {
        }

        public ObjectNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
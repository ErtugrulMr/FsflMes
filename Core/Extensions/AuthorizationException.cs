using System;

namespace Core.Extensions
{
    [Serializable]
    public class AuthorizationException : Exception
    {
        public AuthorizationException(string message): base(message)
        {
        }
    }
}

using System;

namespace Core.Extensions
{
    public class DatabaseException: Exception
    {
        public DatabaseException(string message): base(message)
        {
        }
    }
}

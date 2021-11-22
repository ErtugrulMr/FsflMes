using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public class DatabaseException: Exception
    {
        public DatabaseException(string message): base(message)
        {
        }
    }
}

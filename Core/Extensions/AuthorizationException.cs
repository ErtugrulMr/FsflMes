﻿using System;
using System.Collections.Generic;
using System.Text;

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

using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Persistance
{
    public static class IdCreator
    {
        public static int CreateId()
        {
            Random random = new Random();
            return random.Next(1000,9999);
        }
    }
}

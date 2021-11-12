﻿using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class SchAdmin: User, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

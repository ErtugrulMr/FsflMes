﻿using Core.Entities;

namespace Entities.Concrete
{
    public class SchoolClass: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

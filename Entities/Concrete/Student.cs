using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Student: IEntity
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public int ClassId { get; set; }
        public int SchoolNumber { get; set; }
        public long NationalIdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}

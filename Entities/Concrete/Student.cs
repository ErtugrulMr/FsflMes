using Core.Entities;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Student: User, IEntity
    {
        public int ClassId { get; set; }
        public int SchoolNumber { get; set; }
        public long NationalIdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }      

    }
}

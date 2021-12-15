using Core.Entities;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class SchAdmin: User, IEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

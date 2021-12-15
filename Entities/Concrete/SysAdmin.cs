using Core.Entities;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class SysAdmin: User, IEntity
    {
        public string UserName { get; set; }
    }
}

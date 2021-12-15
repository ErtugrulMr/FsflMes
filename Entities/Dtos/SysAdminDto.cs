using Core.Entities;

namespace Entities.Dtos
{
    public class SysAdminDto: IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

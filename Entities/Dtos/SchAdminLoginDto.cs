using Core.Entities;

namespace Entities.Dtos
{
    public class SchAdminLoginDto: IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

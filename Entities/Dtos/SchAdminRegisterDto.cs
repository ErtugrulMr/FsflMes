using Core.Entities;

namespace Entities.Dtos
{
    public class SchAdminRegisterDto: IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

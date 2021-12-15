using Core.Entities;

namespace Entities.Dtos
{
    public class StudentDetailsDto: IDto
    {
        public int Id { get; set; }
        public int SchoolNumber { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string ClassName { get; set; }
        public long NationalIdentityNumber { get; set; }
        public bool Status { get; set; }
    }
}

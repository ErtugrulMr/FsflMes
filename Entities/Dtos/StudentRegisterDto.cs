using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class StudentRegisterDto
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public int ClassId { get; set; }
        public int SchoolNumber { get; set; }
        public long NationalIdentityNumber { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}

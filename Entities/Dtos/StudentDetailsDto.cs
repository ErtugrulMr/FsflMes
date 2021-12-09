using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class StudentDetailsDto: IDto
    {
        public int Id { get; set; }
        public int SchoolNumber { get; set; }
        public string StudentName { get; set; }
        public string ClassName { get; set; }
        public long NationalIdentityNumber { get; set; }
        public bool Status { get; set; }
    }
}

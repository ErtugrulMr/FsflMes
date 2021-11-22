using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class StudentLoginDto
    {
        public string Name { get; set; }
        public int SchoolNumber { get; set; }
        public string Password { get; set; }
    }
}

using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class PostDetailsDto: IDto
    {
        public int PostId { get; set; }
        public string TypeName { get; set; }
        public string PostTitle { get; set; }
        public bool IsPostRepliedByAdmin { get; set; }
        public bool IsPostSolved { get; set; }
        public string ReportMessage { get; set; }
        public string StudentName { get; set; }
        public string StudentClassName { get; set; }
        public int SchoolNumber { get; set; }
        public long StudentNationalIdentityNumber { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? SolvingDate { get; set; }
    }
}

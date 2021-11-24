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
        public int ReportId { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public string PostTitle { get; set; }
        public bool IsPostLastRepliedByAdmin { get; set; }
        public bool IsPostSolved { get; set; }
        public string ReportMessage { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime SolvingDate { get; set; }
        public int StudentClassName { get; set; }
        public int SchoolNumber { get; set; }
        public long NationalIdentityNumber { get; set; }
        public string StudentName { get; set; }
    }
}

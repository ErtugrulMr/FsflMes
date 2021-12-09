using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Report: IEntity
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int StudentId { get; set; }
        public string Message { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

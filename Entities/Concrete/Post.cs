using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Post: IEntity
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int StudentId { get; set; }
        public string Title { get; set; }
        public bool IsReplied { get; set; }
        public bool IsSolved { get; set; }
    }
}

using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class Post: IEntity
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int StudentId { get; set; }
        public string Title { get; set; }
        public bool IsRepliedByAdmin { get; set; }
        public bool IsSolved { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? SolvingDate { get; set; }
    }
}

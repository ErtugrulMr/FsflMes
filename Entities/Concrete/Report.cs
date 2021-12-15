using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class Report: IEntity
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public bool IsFromStudent { get; set; }
        public string Message { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

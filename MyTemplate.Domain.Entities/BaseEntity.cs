using System;

namespace MyTemplate.Domain.Entities
{
    public abstract class BaseEntity : IAuditable
    {
        public int Id { get; set; }
        public DateTime InsertTime { get; set; } = System.DateTime.Now;
        public string InsertBy { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string UpdateBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

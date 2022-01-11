using MyTemplate.Domain.Entities.Enums;
using System;

namespace MyTemplate.Domain.Entities.Dtos
{
    public class CreateEmployeeDTO
    {
        public int EmployeeNo { get; set; }
        public Guid EmployeeIdInHRSSystem { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CurrentStatus CurrentStatus { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public Status Status { get; set; }

    }
    public class EmployeeDTO : CreateEmployeeDTO
    {
        public int Id { get; set; }
        public DateTime InsertTime { get; set; } = System.DateTime.Now;
        public string InsertBy { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string UpdateBy { get; set; }
    }

    public class EmployeeFilterDto : EmployeeDTO
    {
    }
        
}

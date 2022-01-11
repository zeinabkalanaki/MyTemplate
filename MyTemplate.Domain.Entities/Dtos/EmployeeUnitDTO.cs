using MyTemplate.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTemplate.Domain.Entities.Dtos
{
    public class CreateEmployeeUnitDTO
    {
        public int EmployeeId { get; set; }
        public int UnitId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
    }
   public  class EmployeeUnitDTO : CreateEmployeeUnitDTO
    {
        public int Id { get; set; }
        public DateTime InsertTime { get; set; } = System.DateTime.Now;
        public string InsertBy { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string UpdateBy { get; set; }
    }
    public class EmployeeUnitFilterDTO 
    {
        public int? EmployeeId { get; set; }
        public int? UnitId { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
    }

}

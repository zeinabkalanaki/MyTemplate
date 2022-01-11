using MyTemplate.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTemplate.Domain.Entities.Dtos
{
    public class UnitDTO: CreateUnitDTO
    {
        public int Id { get; set; }
        public DateTime InsertTime { get; set; } = System.DateTime.Now;
        public string InsertBy { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string UpdateBy { get; set; }

    }
    public class CreateUnitDTO
    {
        public int Code { get; set; }                        
        public string Name { get; set; }                     
        public UnitStatusType UnitStatusType { get; set; }     

    }

    public class UnitFilterDto : UnitDTO
    {
    }
}

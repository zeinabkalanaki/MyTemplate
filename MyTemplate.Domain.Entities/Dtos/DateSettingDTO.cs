using MyTemplate.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTemplate.Domain.Entities.Dtos
{
    public class CreateDateSettingDTO
    {
        public DateTime EffectiveDate { get; set; }
        public EmploymentType EmployemntTypes { get; set; }
        public byte BeginDayOfMonth { get; set; }
        public byte EndDayOfMonth { get; set; }
    }
   public  class DateSettingDTO : CreateDateSettingDTO
    {
        public int Id { get; set; }
        public DateTime InsertTime { get; set; } = System.DateTime.Now;
        public string InsertBy { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string UpdateBy { get; set; }
    }
    public class DateSettingFilterDTO 
    {
        public DateTime? EffectiveDate { get; set; }
        public EmploymentType? EmployemntTypes { get; set; }
        public byte? BeginDayOfMonth { get; set; }
        public byte? EndDayOfMonth { get; set; }
    }

}

using MyTemplate.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTemplate.Domain.Entities
{
   public class DateSetting :BaseEntity
    {
        //تاریخ موثر 
        public DateTime EffectiveDate { get; set; }
        //نوع استخدامی 
        public EmploymentType EmployemntTypes { get; set; }
        //روز شروع بازه در ماه
        public byte BeginDayOfMonth { get; set; }
        //روز پایان بازه در ماه
        public byte EndDayOfMonth { get; set; }
    }
}

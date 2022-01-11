using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTemplate.Domain.Entities
{
    public class EmployeeUnit :BaseEntity
    {
        //شناسه پرسنلی
        public int EmployeeId { get; set; }
        //شناسه واحد سازمانی
        public int UnitId { get; set; }
        //تاریخ شروع
        public DateTime EffectiveDate { get; set; }
        //تاریخ پایان
        public DateTime EndDate { get; set; }
        //توضیحات		
        public string Description { get; set; }
    }
}

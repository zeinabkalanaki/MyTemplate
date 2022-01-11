using MyTemplate.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTemplate.Domain.Entities
{
    public class OvertimeSettingAttendance :BaseEntity
    {
        //شناسه تنظیمات
        public int SettingId { get; set; }
        //نوع کارکرد در روز
        public AttendanceDayType AttendanceType { get; set; }
    }
}

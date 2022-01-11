using MyTemplate.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTemplate.Domain.Entities.Dtos
{
    public class CreateOvertimeSettingAttendanceDTO
    {
        public int SettingId { get; set; }
        public AttendanceDayType AttendanceType { get; set; }
    }
   public  class OvertimeSettingAttendanceDTO : CreateOvertimeSettingAttendanceDTO
    {
        public int Id { get; set; }
        public DateTime InsertTime { get; set; } = System.DateTime.Now;
        public string InsertBy { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string UpdateBy { get; set; }
    }
    public class OvertimeSettingAttendanceFilterDTO 
    {
        public int? SettingId { get; set; }
        public AttendanceDayType? AttendanceType { get; set; }
    }

}

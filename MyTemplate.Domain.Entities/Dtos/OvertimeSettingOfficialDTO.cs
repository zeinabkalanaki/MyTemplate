using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTemplate.Domain.Entities.Dtos
{
    public class OvertimeSettingOfficialDTO : CreateOvertimeSettingOfficialDTO
    {
        public int Id { get; set; }
        public DateTime InsertTime { get; set; } = System.DateTime.Now;
        public string InsertBy { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string UpdateBy { get; set; }
    }

    public class CreateOvertimeSettingOfficialDTO
    {
        public int SettingId { get; set; }
        public int UnitId { get; set; }
        public int MultipleCoef { get; set; }                   
        public int TotalCeil { get; set; }                      
        public int HolidayCeil { get; set; }                   
        public int RemoteWorkCeil { get; set; }               
        public int PercentEssentialBoss { get; set; }            
        public int PercentEssentialCEO { get; set; }          
        public int EssentialCeil { get; set; }                 
    }

    public class OvertimeSettingOfficialFilterDto : OvertimeSettingOfficialDTO
    {
    }
}

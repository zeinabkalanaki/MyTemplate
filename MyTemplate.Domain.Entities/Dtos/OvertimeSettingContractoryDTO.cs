using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTemplate.Domain.Entities.Dtos
{
   public class OvertimeSettingContractoryDTO : CreateOvertimeSettingContractoryDTO
    {
        public int Id { get; set; }
        public DateTime InsertTime { get; set; } = System.DateTime.Now;
        public string InsertBy { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string UpdateBy { get; set; }
    }

    public class CreateOvertimeSettingContractoryDTO
    {
        public int SettingId { get; set; }
        public int UnitId { get; set; }
        public int BaseManagmentHour { get; set; }              
        public int TotalCeil { get; set; }                    
        public int NormalCeil { get; set; }                  
        public int HolidayCeil { get; set; }                  
        public int RemoteWorkCeil { get; set; }              
        public int ShiftCeil { get; set; }                 
        public int PercentBoss { get; set; }                  
        public int PercentCEO { get; set; }             
        public int BossCeil { get; set; }                
        public int CEOCeil { get; set; }                      
        public int EssentialCeil { get; set; }               
        public int EssentialPercent { get; set; }             
    }

    public class OvertimeSettingContractoryFilterDto : OvertimeSettingContractoryDTO
    {
    }
}

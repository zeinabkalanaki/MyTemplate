using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTemplate.Domain.Entities
{
    public class OvertimeSettingOfficial :BaseEntity
    {
        //تنظیمات مابه التفاوت پرسنل رسمی
        public int SettingId { get; set; }
        public int UnitId { get; set; }
        public int MultipleCoef { get; set; }                     //مبنای چند برابر حضور فیزیکی
        public int TotalCeil { get; set; }                        //سقف ما به التفاوت
        public int HolidayCeil { get; set; }                      //سقف اضافه کار روز تعطیل
        public int RemoteWorkCeil { get; set; }                   //سقف ساعت دورکاری      
        public int PercentEssentialBoss { get; set; }             //در صد تجاوز از سقف رییس اداره
        public int PercentEssentialCEO { get; set; }              //در صد تجاوز از سقف مدیرعامل
        public int EssentialCeil { get; set; }                    //سقف استثنا

    }
}

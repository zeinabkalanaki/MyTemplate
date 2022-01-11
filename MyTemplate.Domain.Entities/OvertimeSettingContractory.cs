using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTemplate.Domain.Entities
{
    public class OvertimeSettingContractory :BaseEntity
    {
        //تنظیمات مابه التفاوت پرسنل شرکتی
        public int SettingId { get; set; }
        public int UnitId { get; set; }
        public int BaseManagmentHour { get; set; }              //مبنای ساعت مدیریتی
        public int TotalCeil { get; set; }                      //سقف ما به التفاوت
        public int NormalCeil { get; set; }                     //سقف اضافه کار عادی
        public int HolidayCeil { get; set; }                    //سقف اضافه کار روز تعطیل
        public int RemoteWorkCeil { get; set; }                 //سقف ساعت دورکاری
        public int ShiftCeil { get; set; }                      //سقف ساعت شیفت
        public int PercentBoss { get; set; }                    //درصد رییس اداره از بودجه
        public int PercentCEO { get; set; }                     //درصد مدیرعامل از بودجه
        public int BossCeil { get; set; }                       //ساعت کل رییس اداره از بودجه
        public int CEOCeil { get; set; }                        //ساعت کل مدیرعامل از بودجه
        public int EssentialCeil { get; set; }                  //سقف استثنا
        public int EssentialPercent { get; set; }               //درصد استثنا
    }
}

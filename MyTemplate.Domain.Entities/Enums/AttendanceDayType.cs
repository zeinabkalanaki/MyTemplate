using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTemplate.Domain.Entities.Enums
{
    public enum AttendanceDayType : int
    {
        //صحیح 
        Correct = 1,
        // مرخصی بدون حقوق
        UnpaidLeave = 2,
        //مرخصی زایمان  
        MaternityLeave = 3,
        //مرخصی استحقاقی
        PaidLeave = 4,
        //مرخصی استعلاجی
        SickLeave = 5,
        //نوبت کاری
        Shift = 6,
        //تعطیل
        Holiday = 7,
        //تعطیلی 5 شنبه
        ThursdayHoliday = 8
    }
}

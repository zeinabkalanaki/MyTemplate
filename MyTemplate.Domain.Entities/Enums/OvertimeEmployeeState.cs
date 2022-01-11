using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTemplate.Domain.Entities.Enums
{
    public enum OvertimeEmployeeState : int
    {
        Draft = 1,           //پیش نویس
        AdministrativeOfficerConfirmed = 2,       //تایید مسئول اداری شرکت
        DepartmentHeadConfirmed = 3,        //تایید رییس اداره
        CEOConfirmed = 4, //تایید مدیرعامل
        FinancialPaymentConfirmed = 5,//تایید پرداخت بخش مالی
        Cancel = 6 // ابطال     
    }
}

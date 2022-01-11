using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTemplate.Domain.Entities.Enums
{
    public enum OvertimeEmployeeTrigger : int
    {
        Draft = 1,           //پیش نویس
        AdministrativeOfficerConfirm = 2,       //تایید مسئول اداری شرکت
        DepartmentHeadConfirm = 3,        //تایید رییس اداره
        CEOConfirm = 4, //تایید مدیرعامل
        FinancialPaymentConfirm = 5,//تایید پرداخت بخش مالی
        Cancel = 6 // ابطال     
    }
}

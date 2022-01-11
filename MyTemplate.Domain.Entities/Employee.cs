using MyTemplate.Domain.Entities.Enums;
using System;

namespace MyTemplate.Domain.Entities
{
    public class Employee : BaseEntity
    {
        //شماره پرسنلی
        public int EmployeeNo { get; set; }

        //شناسه در سیستم منابع انسانی
        public Guid EmployeeIdInHRSSystem { get; set; }

        //نام
        public string FirstName { get; set; }

        //نام خانوادگی
        public string LastName { get; set; }

        //وضعیت جاری
        public CurrentStatus CurrentStatus { get; set; }

        //وضعیت استخدامی
        public EmploymentType EmploymentType { get; set; }

        //وضعیت در سامانه اضافه کاری
        public Status Status { get; set; }

    }
}

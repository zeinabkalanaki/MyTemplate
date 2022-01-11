using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTemplate.Domain.Entities.Enums
{
    public enum CurrentStatus : int
    {
        UnpaidLeave = 6 ,           //مرخصی بدون حقوق
        MaternityLeave = 10 ,       //مرخصی زایمان
        NonCooperation =55 ,        //قطع همکاری
        Employed = 100              //شاغل

    }
}

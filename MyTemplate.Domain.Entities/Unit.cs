using MyTemplate.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTemplate.Domain.Entities
{
   public class Unit :BaseEntity
    {
        public int Code { get; set; }                           // کد واحد
        public string Name { get; set; }                        // نام واحد
        public UnitStatusType UnitStatusType { get; set; }      // وضعیت واحد
    }
}

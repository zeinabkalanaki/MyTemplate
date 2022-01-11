using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTemplate.Domain.Entities
{
    public class OvertimeSetting :BaseEntity
    {
        //تاریخ موثر	
        public DateTime EffectiveDate { get; set; }
        //توضیحات		 
        public string Description { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTemplate.Domain.Entities
{
   public class EmployeeInfo : BaseEntity
    {
        public int EmployeeNo { get; set; }

        public string EmployeeIdInHRSSystem { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CurrentStatus { get; set; }

        public int EmploymentType { get; set; }

    }
}

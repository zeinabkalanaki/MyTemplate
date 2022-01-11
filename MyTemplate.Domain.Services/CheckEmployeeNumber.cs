using MyTemplate.Domain.Abstracts.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTemplate.Domain.Services
{
    public class CheckEmployeeNumber : ICheckEmployeeNumber
    {
        public bool IsValid(int employeeNo)
        {
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTemplate.Domain.Abstracts.DomainServices
{
    public interface ICheckEmployeeNumber
    {
        bool IsValid(int employeeNo);
    }
}

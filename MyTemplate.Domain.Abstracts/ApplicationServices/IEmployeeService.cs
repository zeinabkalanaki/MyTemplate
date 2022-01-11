
using MyTemplate.Domain.Entities.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTemplate.Domain.Abstracts.ApplicationServices
{
    public interface IEmployeeService 
    {
        Task<int> Add(CreateEmployeeDTO employee);
        Task Change(EmployeeDTO employee);
        public EmployeeDTO FindById(int id);
        List<EmployeeDTO> FindByFilters(EmployeeFilterDto input);
    }
}

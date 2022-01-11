using AutoMapper;
using MyTemplate.Domain.Abstracts.ApplicationServices;
using MyTemplate.Domain.Abstracts.DomainServices;
using MyTemplate.Domain.Abstracts.Repositories;
using MyTemplate.Domain.Entities;
using MyTemplate.Domain.Entities.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTemplate.Domain.ApplicationServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICheckEmployeeNumber _checkEmployeeNumber;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, ICheckEmployeeNumber checkEmployeeNumber, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _checkEmployeeNumber = checkEmployeeNumber;
            _mapper = mapper;
        }

        public async Task<int> Add(CreateEmployeeDTO employee)
        {
            var mappedEmployee = _mapper.Map<Employee>(employee);
            return await _employeeRepository.Insert(mappedEmployee); ;
        }

        public async Task Change(EmployeeDTO employee)
        {
            var mappedEmployee = _mapper.Map<Employee>(employee);

            await _employeeRepository.Update(mappedEmployee);
        }

        public EmployeeDTO FindById(int id)
        {
            var employee = _employeeRepository.Get().Where(x => x.Id == id).FirstOrDefault();

            _checkEmployeeNumber.IsValid(employee.EmployeeNo);

            var results = _mapper.Map<EmployeeDTO>(employee);
            return results;
        }

        public List<EmployeeDTO> FindByFilters(EmployeeFilterDto input)
        {
            var query = _employeeRepository.Get();

            query = (!string.IsNullOrWhiteSpace(input.FirstName)) ? query.Where(x => x.FirstName.Contains(input.FirstName)) : query;
            query = (!string.IsNullOrWhiteSpace(input.LastName)) ? query.Where(x => x.LastName.Contains(input.LastName)) : query;

            var results = query.ToList();

            var mappedResults = _mapper.Map<List<EmployeeDTO>>(results);
            return mappedResults;
        }

    }
}

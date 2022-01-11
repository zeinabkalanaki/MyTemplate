using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MyTemplate.Domain.Abstracts.ApplicationServices;
using MyTemplate.Domain.Entities.Dtos;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Identity;
using MyTemplate.Infrastructures.Security;

namespace MyTemplate.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseAppController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService,UserManager<ApplicationUser> userManager)
            : base(userManager)
        {
            _employeeService = employeeService;

        }

        [HttpGet]
        public IActionResult Get([FromQuery] EmployeeFilterDto employeeFilterDto)
        {
            List<EmployeeDTO> employees = _employeeService.FindByFilters(employeeFilterDto);

            return Ok(employees);

        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {

            EmployeeDTO employee = _employeeService.FindById(id);
            return Ok(employee);

        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(CreateEmployeeDTO createEmployeeDTO)
        {

            //_employeeinfoService.GetNewEmployeeInfo();
            //return Ok();

            var id = await _employeeService.Add(createEmployeeDTO);

            if (id == 1)
                return Ok(id);
            else return Ok(-1);

        }

        [HttpPut]
        public async Task<IActionResult> ChangeEmployee(EmployeeDTO employeeDTO)
        {
            await _employeeService.Change(employeeDTO);

            return Ok();

        }

    }
}

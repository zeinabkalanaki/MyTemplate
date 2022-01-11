using MyTemplate.Domain.Abstracts.Repositories;
using MyTemplate.Domain.Entities;
using MyTemplate.Infrastructures.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace MyTemplate.Infrastructures.DataAccess.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ClockWebDbContext context) : base(context)
        {
        }
    }
}

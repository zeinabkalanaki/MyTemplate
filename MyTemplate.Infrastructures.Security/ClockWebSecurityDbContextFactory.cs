using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTemplate.Infrastructures.Security
{
    class ClockWebSecurityDbContextFactory : IDesignTimeDbContextFactory<ClockWebSecurityDbContext>
    {
        public ClockWebSecurityDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder();
            return new ClockWebSecurityDbContext(builder.UseSqlServer(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ClockWebSecurityDb;Data Source=.").Options);
        }
    }
}

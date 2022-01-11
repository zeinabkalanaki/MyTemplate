using MyTemplate.Infrastructures.DataAccess.DbContexts;
using MyTemplate.Infrastructures.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyTemplate.Infrastructures.DataAccess.DesignTimeOptions
{
    public class ClockWebContextFactory : IDesignTimeDbContextFactory<ClockWebDbContext>
    {
        public ClockWebDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder();
            return new
                ClockWebDbContext(
                builder.UseSqlServer(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ClockWebDb;Data Source=.").Options,
                new UserResolverService(new HttpContextAccessor(), new ClockWebSecurityDbContext(builder.UseSqlServer(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ClockWebSecurityDb;Data Source=.").Options)));
        }
    }
}

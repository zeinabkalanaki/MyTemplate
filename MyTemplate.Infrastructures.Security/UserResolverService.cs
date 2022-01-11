using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTemplate.Infrastructures.Security
{
    public class UserResolverService
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly ClockWebSecurityDbContext _context;
        public UserResolverService(IHttpContextAccessor httpContext, ClockWebSecurityDbContext context)
        {
            _httpContext = httpContext;
            _context = context;
        }

        public ApplicationUser GetUser()
        {
            var currentUserName = _httpContext.HttpContext.User?.Identity?.Name.ToString();
            var currentApplicationUser = _context.Users.Where(x => x.UserName == currentUserName).FirstOrDefault();

            if (currentApplicationUser == null)
            {
                throw new System.Exception("There is no current user !");
            }

            return currentApplicationUser;
        }
    }
}

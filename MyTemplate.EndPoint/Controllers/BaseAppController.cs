using MyTemplate.Infrastructures.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTemplate.APIs.Controllers
{
    [ApiController]
    public class BaseAppController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public BaseAppController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public ApplicationUser CurrentUser
        {
            get { return _userManager.FindByNameAsync(User.Identity.Name).Result; }
        }
    }
}

using Microsoft.AspNetCore.Identity;

namespace MyTemplate.Infrastructures.Security
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}

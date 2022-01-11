using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyTemplate.Infrastructures.Security
{
    public class ClockWebSecurityDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,int>
    {
        public ClockWebSecurityDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //base.OnModelCreating(builder);

            builder.Entity<IdentityUserLogin<int>>().HasKey(p => new { p.ProviderKey, p.LoginProvider });
            builder.Entity<IdentityUserRole<int>>().HasKey(p => new { p.UserId, p.RoleId });
            builder.Entity<IdentityUserToken<int>>().HasKey(p => new { p.UserId, p.LoginProvider });

            //*********************************************//
            //ApplicationUser
            //*********************************************//
            builder.Entity<ApplicationUser>().Property(x => x.FirstName).HasMaxLength(100).IsRequired();
            builder.Entity<ApplicationUser>().Property(x => x.LastName).HasMaxLength(100).IsRequired();
            builder.Entity<ApplicationUser>().Property(x => x.UserName).HasMaxLength(50).IsRequired();
            builder.Entity<ApplicationUser>().Property(x => x.PasswordHash).IsRequired();
            builder.Entity<ApplicationUser>().Property(x => x.NormalizedUserName).HasMaxLength(50);

            builder.Entity<ApplicationUser>().Ignore(p => p.Email);
            builder.Entity<ApplicationUser>().Ignore(p => p.NormalizedEmail);
            builder.Entity<ApplicationUser>().Ignore(p => p.EmailConfirmed);
            builder.Entity<ApplicationUser>().Ignore(p => p.PhoneNumber);
            builder.Entity<ApplicationUser>().Ignore(p => p.PhoneNumberConfirmed);
            builder.Entity<ApplicationUser>().Ignore(p => p.TwoFactorEnabled);
            builder.Entity<ApplicationUser>().Ignore(p => p.LockoutEnd);
            builder.Entity<ApplicationUser>().Ignore(p => p.LockoutEnabled);
            builder.Entity<ApplicationUser>().Ignore(p => p.AccessFailedCount);

            //*********************************************//
            //ApplicationUser
            //*********************************************//
            builder.Entity<ApplicationRole>().Property(x => x.Description).HasMaxLength(500);
            builder.Entity<ApplicationRole>().Property(x => x.Name).HasMaxLength(100);
            builder.Entity<ApplicationRole>().Property(x => x.NormalizedName).HasMaxLength(100);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}

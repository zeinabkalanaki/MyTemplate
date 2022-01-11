using MyTemplate.Domain.Entities;
using MyTemplate.Infrastructures.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace MyTemplate.Infrastructures.DataAccess.DbContexts
{
    public class ClockWebDbContext : DbContext
    {
        private static List<Type> _entityTypeCache;
        private ApplicationUser _currentUser;
        public ClockWebDbContext(DbContextOptions options, UserResolverService userService) : base(options)
        {
            _currentUser = userService.GetUser();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<OvertimeSetting> OvertimeSettings { get; set; }
        public DbSet<OvertimeSettingAttendance> OvertimeSettingAttendances { get; set; }
        public DbSet<EmployeeUnit> EmployeeUnits { get; set; }
        public DbSet<DateSetting> DateSettings { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<OvertimeSettingOfficial> overtimeSettingOfficials { get; set; }
        public DbSet<OvertimeSettingContractory> overtimeSettingContractories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ClockWeb");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClockWebDbContext).Assembly);


            //Set Global Query Filter For All Entities
            GetEntityTypes().ForEach(type =>
            {
                var method = SetGlobalQueryMethod.MakeGenericMethod(type);
                method.Invoke(this, new object[] { modelBuilder });
            });

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries =
                ChangeTracker.Entries()
                             .Where(e => e.Entity is BaseEntity &&
                                        (e.State == EntityState.Added || e.State == EntityState.Modified)
                             );

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).InsertTime = DateTime.Now;
                    ((BaseEntity)entityEntry.Entity).InsertBy = _currentUser.Id.ToString();
                }
                else
                {
                    ((BaseEntity)entityEntry.Entity).UpdateTime = DateTime.Now;
                    ((BaseEntity)entityEntry.Entity).UpdateBy = _currentUser.Id.ToString();
                }

            }
            return base.SaveChangesAsync(cancellationToken);
        }

        private static List<Type> GetEntityTypes()
        {
            if (_entityTypeCache != null)
            {
                return _entityTypeCache.ToList();
            }
            var assembly = typeof(Employee).Assembly;
            _entityTypeCache = (
                                from t in assembly.DefinedTypes
                                where t.BaseType == typeof(IAuditable)
                                select t.AsType()).ToList();
            return _entityTypeCache;
        }

        static readonly MethodInfo SetGlobalQueryMethod = typeof(ClockWebDbContext).GetMethods(BindingFlags.Public | BindingFlags.Instance)
                                                         .Single(t => t.IsGenericMethod && t.Name == "SetGlobalQuery");
        public void SetGlobalQuery<T>(ModelBuilder builder) where T : class, IAuditable
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }
    }
}

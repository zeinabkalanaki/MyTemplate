using MyTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyTemplate.Infrastructures.DataAccess.EntityConfiguration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee", "ClockWeb");

            builder.Property(t => t.InsertTime).IsRequired();
            builder.Property(t => t.UpdateTime).IsRequired();
            builder.Property(x => x.InsertBy).HasMaxLength(101).IsRequired();
            builder.Property(x => x.UpdateBy).HasMaxLength(101).IsRequired();


            builder.Property(t => t.EmployeeNo).HasColumnType("int");
            builder.Property(x => x.EmployeeIdInHRSSystem).IsRequired();
            builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.CurrentStatus).HasConversion<int>();
            builder.Property(x => x.EmploymentType).HasConversion<int>();
            builder.Property(x => x.Status).HasConversion<int>();

            builder.HasIndex(p => new { p.EmployeeNo }).IsUnique(true);
        }
    }
}

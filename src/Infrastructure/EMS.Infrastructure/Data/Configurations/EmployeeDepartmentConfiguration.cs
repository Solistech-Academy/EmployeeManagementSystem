using EMS.Domain.Entities;
using EMS.Infrastructure.Common.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Data.Configurations
{
    public class EmployeeDepartmentConfiguration : IEntityTypeConfiguration<EmployeeDepartment>
    {
        public void Configure(EntityTypeBuilder<EmployeeDepartment> builder)
        {
            builder.ToTable(EntityNameConstant.EmployeeDepartment);

            //Define the composite primary key
            builder.HasKey(ed => new { ed.EmployeeId, ed.DepartmentId });           

            // Define the foreign key relationship with Employee
            builder.HasOne<Employee>(x => x.Employee)
                   .WithMany(x => x.EmployeeDepartments)
                   .HasForeignKey(ed => ed.EmployeeId) 
                   .IsRequired(true);

            // Define the foreign key relationship with Department
            builder.HasOne<Department>(x => x.Department)
                   .WithMany(d => d.EmployeeDepartments) 
                   .HasForeignKey(ed => ed.DepartmentId)         
                   .IsRequired(true);
        }
    }
}

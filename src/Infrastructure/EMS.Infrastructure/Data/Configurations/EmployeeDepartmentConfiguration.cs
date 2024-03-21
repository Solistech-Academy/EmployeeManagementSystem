using EMS.Domain.Entities;
using EMS.Infrastructure.Common.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Infrastructure.Data.Configurations
{
    public class EmployeeDepartmentConfiguration : IEntityTypeConfiguration<EmployeeDepartment>
    {
        public void Configure(EntityTypeBuilder<EmployeeDepartment> builder)
        {
            builder.ToTable(EntityNameConstant.EmployeeDepartment);

            builder.HasKey(ed => new { ed.EmployeeId, ed.DepartmentId });           //Define the composite primary key

            builder.HasOne<Employee>(x => x.Employee)
                   .WithMany(x => x.EmployeeDepartments)
                   .HasForeignKey(ed => ed.EmployeeId) // Define the foreign key relationship with Employee
                   .IsRequired(true);

            builder.HasOne<Department>(x => x.Department)
                   .WithMany(d => d.EmployeeDepartments) 
                   .HasForeignKey(ed => ed.DepartmentId)         // Define the foreign key relationship with Department
                   .IsRequired(true);
        }
    }
}

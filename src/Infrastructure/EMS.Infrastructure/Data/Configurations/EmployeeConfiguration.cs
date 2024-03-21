using EMS.Domain.Entities;
using EMS.Infrastructure.Common.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Infrastructure.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable(EntityNameConstant.Employee);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName)
                .IsRequired();
            builder.Property(x => x.LastName)
                .IsRequired();
            builder.Property(x => x.Address)
                .IsRequired();
            builder.HasIndex(e => e.MobileNumber)
                   .IsUnique();
            builder.HasIndex(e => e.Email)
                   .IsUnique();
            builder.Property(x => x.Birthday)
                   .IsRequired();
            builder.Property(x => x.CreatedDate)
                  .IsRequired();
            builder.HasMany(e => e.EmployeeDepartments)
               .WithOne(ed => ed.Employee)
               .HasForeignKey(ed => ed.EmployeeId);
        }
    }
}

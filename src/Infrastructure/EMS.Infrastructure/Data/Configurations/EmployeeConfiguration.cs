using EMS.Domain.Entities;
using EMS.Infrastructure.Common.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable(EntityNameConstant.Employee);

            //defining primary key
            builder.HasKey(x => x.Id);

            builder.HasIndex(e => e.MobileNumber)
                   .IsUnique();

            builder.HasIndex(e => e.Email)
                   .IsUnique();
        }
    }
}

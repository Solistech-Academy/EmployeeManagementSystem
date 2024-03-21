﻿using EMS.Domain.Entities;
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
    public class DepartmentConfiguration: IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable(EntityNameConstant.Department);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.HasMany(e => e.EmployeeDepartments)
               .WithOne(d => d.Department)
               .HasForeignKey(d => d.DepartmentId);
        }
    }
}

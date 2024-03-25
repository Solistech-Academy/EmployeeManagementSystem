using EMS.Application.Common.Interfaces;
using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EMS.Infrastructure.Data
{
    public class EMSContext : DbContext , IEMSContext
    {
        public EMSContext(DbContextOptions<EMSContext>options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        public DbSet<Employee> Employees => Set<Employee>();

        public DbSet<Department> Departments => Set<Department>();

        public DbSet<EmployeeDepartment> EmployeeDepartments => Set<EmployeeDepartment>();

        public Task BeginTransactionAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task CommitTransactionAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RetryOnExceptionAsync(Func<Task> func)
        {
            throw new NotImplementedException();
        }

        public Task RollbackTransactionAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

       
    }
}

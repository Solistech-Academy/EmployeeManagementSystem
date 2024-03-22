using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Common.Interfaces
{
    public interface IEMSContext
    {
        DbSet<Employee> Employees { get; }
        DbSet<Department> Departments { get; }
        DbSet<EmployeeDepartment>EmployeeDepartments { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task BeginTransactionAsync(CancellationToken cancellationToken);
        Task CommitTransactionAsync(CancellationToken cancellationToken);
        Task RollbackTransactionAsync(CancellationToken cancellationToken);
        Task RetryOnExceptionAsync(Func<Task> func);
    }
}

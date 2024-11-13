using EMS.Domain.Entities;
using EMS.Domain.Repositories.Command;
using EMS.Infrastructure.Data;
using EMS.Infrastructure.Repositories.Command.Base;

namespace EMS.Infrastructure.Repositories.Command
{
    public class EmployeeDepartmentCommandRepository : CommandRepository<EmployeeDepartment>, IEmployeeDepartmentCommandRepository
    {
        public EmployeeDepartmentCommandRepository(EMSContext context) : base(context)
        {
        }
    }
}

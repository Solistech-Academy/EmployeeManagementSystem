using EMS.Domain.Entities;
using EMS.Domain.Repositories.Query;
using EMS.Infrastructure.Data;
using EMS.Infrastructure.Repositories.Query.Base;

namespace EMS.Infrastructure.Repositories.Query
{
    public class EmployeeDepartmentQueryRepository : QueryRepository<EmployeeDepartment>, IEmployeeDepartmentQueryRepository
    {
        public EmployeeDepartmentQueryRepository(EMSContext context) : base(context)
        {
        }
    }
}

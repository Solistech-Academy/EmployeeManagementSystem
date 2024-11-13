using EMS.Domain.Entities;
using EMS.Domain.Repositories.Query;
using EMS.Infrastructure.Data;
using EMS.Infrastructure.Repositories.Query.Base;

namespace EMS.Infrastructure.Repositories.Query
{
    public class DepartmentQueryRepository : QueryRepository<Department>, IDepartmentQueryRepository
    {
        public DepartmentQueryRepository(EMSContext context) : base(context)
        {
        }
    }
}

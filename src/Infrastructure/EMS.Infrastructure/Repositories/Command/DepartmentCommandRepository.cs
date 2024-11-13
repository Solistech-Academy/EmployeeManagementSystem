using EMS.Domain.Entities;
using EMS.Domain.Repositories.Command;
using EMS.Infrastructure.Data;
using EMS.Infrastructure.Repositories.Command.Base;

namespace EMS.Infrastructure.Repositories.Command
{
    public class DepartmentCommandRepository : CommandRepository<Department>, IDepartmentCommandRepository
    {
        public DepartmentCommandRepository(EMSContext context) : base(context)
        {
        }
    }
}

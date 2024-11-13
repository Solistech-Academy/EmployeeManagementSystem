using EMS.Application.DTOs.CommonDTOs;
using EMS.Domain.Repositories.Query;
using MediatR;

namespace EMS.Application.PipeLines.Departments.Queries.GetDepartmentMasterData
{
    public record GetDepartmentMasterDataQuery() : IRequest<List<DropdownDTO>>;

    public class GetDepartmentMasterDataQueryHandler : IRequestHandler<GetDepartmentMasterDataQuery, List<DropdownDTO>>
    {
        private readonly IDepartmentQueryRepository _departmentQueryRepository;
        public GetDepartmentMasterDataQueryHandler(IDepartmentQueryRepository departmentQueryRepository)
        {
            this._departmentQueryRepository = departmentQueryRepository;
        }

        public async Task<List<DropdownDTO>> Handle(GetDepartmentMasterDataQuery request, CancellationToken cancellationToken)
        {
            var departments = await _departmentQueryRepository.GetAll(cancellationToken);

            var departmentDTOs = new List<DropdownDTO>();

            foreach (var department in departments)
            {
                var departmentDTO = new DropdownDTO
                {
                    Id = department.Id,
                    Name = department.Name
                };
                departmentDTOs.Add(departmentDTO);
            }

            return departmentDTOs;

        }
    }

}

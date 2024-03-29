using EMS.Application.Common.Enums;
using EMS.Application.DTOs.CommonDTOs;
using EMS.Application.DTOs.EmployeeDTOs;
using EMS.Application.PipeLines.Departments.Queries.GetDepartmentMasterData;
using MediatR;

namespace EMS.Application.PipeLines.Employees.Queries.GetEmployeeMasterData
{
    public record GetEmployeeMasterDataQuery() : IRequest<EmployeeMasterDataDTO>;

    public class GetEmployeeMasterDataQueryHandler : IRequestHandler<GetEmployeeMasterDataQuery, EmployeeMasterDataDTO>
    {
        private readonly IMediator _mediator;
        public GetEmployeeMasterDataQueryHandler(IMediator mediator)
        {

            this._mediator = mediator;

        }


        public async Task<EmployeeMasterDataDTO> Handle(GetEmployeeMasterDataQuery request, CancellationToken cancellationToken)
        {
            var employeeMasterDTO = new EmployeeMasterDataDTO();
            var departmentData = await _mediator.Send(new GetDepartmentMasterDataQuery());

            employeeMasterDTO.ListOfDepartments = departmentData;

            foreach (EmployeeStatus status in Enum.GetValues(typeof(EmployeeStatus)))
            {
                var activeStatusDTO = new DropdownDTO
                {
                    Id = (int)status,
                    Name = status.ToString() // Return enum value as string
                };
                employeeMasterDTO.ActiveStatus.Add(activeStatusDTO);
            }


            return employeeMasterDTO;
        }
    }
}

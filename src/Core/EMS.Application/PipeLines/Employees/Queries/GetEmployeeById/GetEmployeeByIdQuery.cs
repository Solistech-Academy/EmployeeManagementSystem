using EMS.Application.DTOs.EmployeeDTOs;
using EMS.Domain.Repositories.Query;
using MediatR;

namespace EMS.Application.PipeLines.Employees.Queries.GetEmployeeById
{
    public record GetEmployeeByIdQuery(int EmployeeId) : IRequest<EmployeeDTO>;

    public class GetEmployeeByIdCommandHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDTO>
    {
        private readonly IEmployeeQueryRepository _employeeQueryRepository;

        public GetEmployeeByIdCommandHandler(IEmployeeQueryRepository employeeQueryRepository)
        {
            this._employeeQueryRepository = employeeQueryRepository;
        }

        public async Task<EmployeeDTO> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeQueryRepository.GetById(request.EmployeeId, cancellationToken);

            var employeeDTO = new EmployeeDTO()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Address = employee.Address,
                MobileNumber = employee.MobileNumber,
                Email = employee.Email,
                Birthday = employee.Birthday,
                Departments = employee.EmployeeDepartments.Select(x => x.DepartmentId).ToList()
            };

            return employeeDTO;
        }
    }

}

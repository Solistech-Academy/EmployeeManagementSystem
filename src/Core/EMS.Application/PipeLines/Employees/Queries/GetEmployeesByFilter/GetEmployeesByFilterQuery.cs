using EMS.Application.DTOs.CommonDTOs;
using EMS.Application.DTOs.EmployeeDTOs;
using EMS.Domain.Repositories.Query;
using MediatR;

namespace EMS.Application.PipeLines.Employees.Queries.GetEmployeesByFilter
{
    public record GetEmployeesByFilterQuery(EmployeeFilterDTO EmployeeFilterDTO) : IRequest<PaginatedListDto<EmployeeDTO>>;

    public class GetEmployeesByFilterQueryHandler : IRequestHandler<GetEmployeesByFilterQuery, PaginatedListDto<EmployeeDTO>>
    {
        private readonly IEmployeeQueryRepository _employeeQueryRepository;


        public GetEmployeesByFilterQueryHandler(IEmployeeQueryRepository employeeQueryRepository)
        {
            this._employeeQueryRepository = employeeQueryRepository;
        }

        public async Task<PaginatedListDto<EmployeeDTO>> Handle(GetEmployeesByFilterQuery request, CancellationToken cancellationToken)

        {
            var totalRecordCount = 0;
            var query = await _employeeQueryRepository.Query(x => x.Id > 0);

            switch (request.EmployeeFilterDTO.EmployeeStatus)
            {
                case Common.Enums.EmployeeStatus.IsActive:
                    {
                        query = query.Where(x => x.IsActive == true);
                        break;
                    }
                case Common.Enums.EmployeeStatus.IsInActive:
                    {
                        query = query.Where(x => x.IsActive == false);
                        break;
                    }
            }

            if (!string.IsNullOrEmpty(request.EmployeeFilterDTO.Name))
            {
                query = query.Where(x => x.FirstName.Contains(request.EmployeeFilterDTO.Name));
            }

            if (request.EmployeeFilterDTO.DepartmentId > 0)
            {
                query = query.Where(x => x.EmployeeDepartments.Any(c => c.DepartmentId == request.EmployeeFilterDTO.DepartmentId));
            }

            totalRecordCount = query.Count();

            var listOfEmployee = query.OrderByDescending(x => x.CreatedDate)
                                .Skip(request.EmployeeFilterDTO.CurrentPage * request.EmployeeFilterDTO.PageSize)
                                .Take(request.EmployeeFilterDTO.PageSize).ToList();

            var employeeDTOs = new List<EmployeeDTO>();

            foreach (var employee in listOfEmployee)
            {
                var employeeDTO = new EmployeeDTO
                {

                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Address = employee.Address,
                    MobileNumber = employee.MobileNumber,
                    Email = employee.Email,
                    Birthday = employee.Birthday,
                    IsActive = employee.IsActive,
                    Departments = employee.EmployeeDepartments.Select(x => x.DepartmentId).ToList()
                };

                employeeDTOs.Add(employeeDTO);

            }

            return new PaginatedListDto<EmployeeDTO>(employeeDTOs, totalRecordCount, request.EmployeeFilterDTO.CurrentPage + 1, request.EmployeeFilterDTO.PageSize);
        }
    }
}

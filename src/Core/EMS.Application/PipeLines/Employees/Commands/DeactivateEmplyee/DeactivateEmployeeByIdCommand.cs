using EMS.Application.Common.Constants;
using EMS.Application.DTOs.CommonDTOs;
using EMS.Domain.Repositories.Command;
using EMS.Domain.Repositories.Query;
using MediatR;

namespace EMS.Application.PipeLines.Employees.Commands.DeactivateEmplyee
{
    public record DeactivateEmployeeByIdCommand(int EmployeeId) : IRequest<ResultDTO>;

    public class DeactivateEmployeeByIdCommandHandler : IRequestHandler<DeactivateEmployeeByIdCommand, ResultDTO>
    {
        private readonly IEmployeeQueryRepository _employeeQueryRepository;
        private readonly IEmployeeCommandRepository _employeeCommandRepository;
        public DeactivateEmployeeByIdCommandHandler(IEmployeeQueryRepository employeeQueryRepository, IEmployeeCommandRepository employeeCommandRepository)
        {
            this._employeeQueryRepository = employeeQueryRepository;
            this._employeeCommandRepository = employeeCommandRepository;
        }

        public async Task<ResultDTO> Handle(DeactivateEmployeeByIdCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeQueryRepository.GetById(request.EmployeeId, cancellationToken);

            employee.IsActive = false;

            await _employeeCommandRepository.UpdateAsync(employee, cancellationToken);

            return ResultDTO.Success(ResponseMessageConstant.EMPLOYEEDEACTIVATE_SUCCESS_MESSAGE);

        }
    }
}

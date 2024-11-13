using EMS.Domain.Repositories.Query;
using MediatR;

namespace EMS.Application.PipeLines.Employees.Queries.ValidateExistEmployeeMobileNumber
{
    public record ValidateExistEmployeeMobileNumberQuery(string MobileNumber) : IRequest<bool>;
    public class ValidateExistEmployeeMobileNumberQueryHandler : IRequestHandler<ValidateExistEmployeeMobileNumberQuery, bool>
    {
        private readonly IEmployeeQueryRepository _employeeQueryRepository;
        public ValidateExistEmployeeMobileNumberQueryHandler(IEmployeeQueryRepository employeeQueryRepository)
        {
            this._employeeQueryRepository = employeeQueryRepository;
        }

        public async Task<bool> Handle(ValidateExistEmployeeMobileNumberQuery request, CancellationToken cancellationToken)
        {
            var employee = (await _employeeQueryRepository.Query(x => x.MobileNumber == request.MobileNumber)).FirstOrDefault();

            if (employee is not null)
            {
                return true;
            }
            else
                return false;

        }
    }
}

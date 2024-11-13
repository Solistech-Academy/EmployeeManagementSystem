using EMS.Domain.Repositories.Query;
using MediatR;

namespace EMS.Application.PipeLines.Employees.Queries.ValidateExistEmployeeEmail
{
    public record ValidateExistEmployeeEmailQuery(string Email) : IRequest<bool>;
    public class ValidateExistEmployeeEmailQueryHandler : IRequestHandler<ValidateExistEmployeeEmailQuery, bool>
    {
        private readonly IEmployeeQueryRepository _employeeQueryRepository;
        public ValidateExistEmployeeEmailQueryHandler(IEmployeeQueryRepository employeeQueryRepository)
        {
            this._employeeQueryRepository = employeeQueryRepository;
        }

        public async Task<bool> Handle(ValidateExistEmployeeEmailQuery request, CancellationToken cancellationToken)
        {
            var employee = (await _employeeQueryRepository.Query(x => x.Email == request.Email)).FirstOrDefault();

            if (employee is not null)
            {
                return true;
            }
            else
                return false;
        }
    }
}

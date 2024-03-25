﻿using EMS.Application.Common.Constants;
using EMS.Application.DTOs.CommonDTOs;
using EMS.Application.DTOs.EmployeeDTOs;
using EMS.Domain.Entities;
using EMS.Domain.Repositories.Command;
using EMS.Domain.Repositories.Query;
using MediatR;

namespace EMS.Application.PipeLines.Employees.Commands.SaveEmployee
{
    public record SaveEmployeeCommand(EmployeeDTO EmployeeDTO) : IRequest<ResultDTO>;

    public class SaveEmployeeCommandHandler : IRequestHandler<SaveEmployeeCommand, ResultDTO>
    {
        private readonly IEmployeeQueryRepository _employeeQueryRepository;
        private readonly IEmployeeCommandRepository _employeeCommandRepository;



        public SaveEmployeeCommandHandler(IEmployeeQueryRepository employeeQueryRepository, IEmployeeCommandRepository employeeCommandRepository)
        {
            this._employeeQueryRepository = employeeQueryRepository;
            this._employeeCommandRepository = employeeCommandRepository;

        }

        public async Task<ResultDTO> Handle(SaveEmployeeCommand request, CancellationToken cancellationToken)
        {
            //check if employee exists
            var employee = await _employeeQueryRepository.GetById(request.EmployeeDTO.Id, cancellationToken);

            if (employee is null)
            {
                //add employee basic details
                employee = new Employee
                {
                    FirstName = request.EmployeeDTO.FirstName,
                    LastName = request.EmployeeDTO.LastName,
                    Address = request.EmployeeDTO.Address,
                    MobileNumber = request.EmployeeDTO.MobileNumber,
                    Email = request.EmployeeDTO.Email,
                    Birthday = request.EmployeeDTO.Birthday

                };

                AddNewDepartments(employee, request.EmployeeDTO.Departments);

                await _employeeCommandRepository.AddAsync(employee, cancellationToken);

                return ResultDTO.Success(ResponseMessageConstant.EMPLOYEE_SAVE_SUCCESS_MESSAGE, employee.Id);
            }
            else
            {
                // update  employee details


                employee.FirstName = request.EmployeeDTO.FirstName;
                employee.LastName = request.EmployeeDTO.LastName;
                employee.Address = request.EmployeeDTO.Address;
                employee.MobileNumber = request.EmployeeDTO.MobileNumber;
                employee.Email = request.EmployeeDTO.Email;
                employee.Birthday = request.EmployeeDTO.Birthday;


                //add new department, handle deleted departments 
                var existingDepartments = employee.EmployeeDepartments.ToList();
                var selectedDepartmentIds = request.EmployeeDTO.Departments.ToList();
                var newDepartments = selectedDepartmentIds.Except(existingDepartments.Select(x => x.DepartmentId)).ToList();
                var deletedDepartments = existingDepartments.Where(x => !selectedDepartmentIds.Contains(x.DepartmentId)).ToList();

                foreach (var deletedDepartment in deletedDepartments)
                {
                    employee.EmployeeDepartments.Remove(deletedDepartment);
                }

                AddNewDepartments(employee, newDepartments);

                await _employeeCommandRepository.UpdateAsync(employee, cancellationToken);

                return ResultDTO.Success(ResponseMessageConstant.EMPLOYEE_UPDATE_SUCCESS_MESSAGE, employee.Id);
            }

        }
        private void AddNewDepartments(Employee employee, List<int> newDepartmentIds)
        {
            foreach (var newDepartmentId in newDepartmentIds)
            {
                employee.EmployeeDepartments.Add(new EmployeeDepartment()
                {
                    DepartmentId = newDepartmentId,
                    EmployeeId = employee.Id
                });

            }
        }

    }
}

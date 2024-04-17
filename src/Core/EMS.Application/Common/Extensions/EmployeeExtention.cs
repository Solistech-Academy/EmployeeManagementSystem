using EMS.Application.DTOs.EmployeeDTOs;
using EMS.Domain.Entities;

namespace System
{
    public static class EmployeeExtention
    {
        public static Employee ToEntity(this EmployeeDTO dto, Employee? entity = null)
        {
            if (entity is null) entity = new Employee();
            entity.Id = dto.Id;
            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;
            entity.Address = dto.Address;
            entity.MobileNumber = dto.MobileNumber;
            entity.Email = dto.Email;
            entity.Birthday = dto.Birthday;

            return entity;
        }


    }
}

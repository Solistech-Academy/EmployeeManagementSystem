using EMS.Application.DTOs.CommonDTOs;

namespace EMS.Application.DTOs.EmployeeDTOs
{
    public class EmployeeDTO : BaseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public bool IsActive { get; set; }
        public List<int> Departments { get; set; }
    }
}

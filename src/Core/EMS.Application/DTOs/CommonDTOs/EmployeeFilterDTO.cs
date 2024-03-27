using EMS.Application.Common.Enums;

namespace EMS.Application.DTOs.CommonDTOs
{
    public class EmployeeFilterDTO
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
    }
}

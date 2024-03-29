using EMS.Application.DTOs.CommonDTOs;

namespace EMS.Application.DTOs.EmployeeDTOs
{
    public class EmployeeMasterDataDTO
    {
        public EmployeeMasterDataDTO()
        {

            ListOfDepartments = new List<DropdownDTO>();
            ActiveStatus = new List<DropdownDTO>();
        }
        public List<DropdownDTO> ListOfDepartments { get; set; }
        public List<DropdownDTO> ActiveStatus { get; set; }

    }
}

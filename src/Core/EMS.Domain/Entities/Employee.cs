using EMS.Domain.Common;

namespace EMS.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public Employee() 
        {
            EmployeeDepartments = new HashSet<EmployeeDepartment>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<EmployeeDepartment> EmployeeDepartments { get; set; }
    }
}

using EMS.Domain.Common;


namespace EMS.Domain.Entities
{
    public class Department:BaseEntity
    {
        public Department()
        {
            EmployeeDepartments = new HashSet<EmployeeDepartment>();
        }
        public string Name { get; set; }
        public virtual ICollection<EmployeeDepartment> EmployeeDepartments { get; set; }
    }
}

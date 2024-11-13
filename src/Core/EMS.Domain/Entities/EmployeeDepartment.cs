namespace EMS.Domain.Entities
{
    public class EmployeeDepartment
    {
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; } = null!;

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; } = null!;
    }
}

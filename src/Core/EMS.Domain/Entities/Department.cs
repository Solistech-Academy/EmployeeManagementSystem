using EMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domain.Entities
{
    public class Department:BaseEntity
    {
        public Department()
        {
            EmployeeDepartments = new HashSet<EmployeeDepartment>();
        }
        public string? Name { get; set; }
        public virtual ICollection<EmployeeDepartment> EmployeeDepartments { get; set; }
    }
}

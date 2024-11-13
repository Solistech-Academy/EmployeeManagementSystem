using System.ComponentModel;

namespace EMS.Application.Common.Enums
{
    public enum EmployeeStatus
    {
        [Description("Is Active")]
        IsActive = 1,
        [Description("Is InActive")]
        IsInActive = 2
    }
}

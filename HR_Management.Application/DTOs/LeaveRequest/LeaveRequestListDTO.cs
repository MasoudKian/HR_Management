using HR_Management.Application.DTOs.Common;
using HR_Management.Application.DTOs.LeaveType;
using System;

namespace HR_Management.Application.DTOs.LeaveRequest
{
    public class LeaveRequestListDTO : BaseDTO
    {
        public LeaveTypeDTO LeaveType { get; set; }
        public DateTime DateRequested { get; set; }
        public bool? Aoorived { get; set; }
    }
}

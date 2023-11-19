using HR_Management.Application.DTOs.LeaveType;
using MediatR;

namespace HR_Management.Application.Features.LeaveTypes.Requests.Commands
{
    public class UpdateLeaveTypeRequestCommand : IRequest<Unit>
    {
        public LeaveTypeDTO LeaveTypeDTO { get; set; }
    }
}

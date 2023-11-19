using HR_Management.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR_Management.Application.Features.LeaveAllocations.Requests.Comands
{
    public class UpdateLeaveAllocationRequestCommand :IRequest<Unit>
    {
        public LeaveAllocationDTO LeaveAllocationDTO { get; set; }
    }
}

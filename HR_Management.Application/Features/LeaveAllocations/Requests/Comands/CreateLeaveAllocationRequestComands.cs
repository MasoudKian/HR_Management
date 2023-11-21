using HR_Management.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR_Management.Application.Features.LeaveAllocations.Requests.Comands
{
    public class CreateLeaveAllocationRequestComands : IRequest<int>
    {
        public CreateLeaveAllocationDTO CreateLeaveAllocationDTO { get; set; }
    }
}

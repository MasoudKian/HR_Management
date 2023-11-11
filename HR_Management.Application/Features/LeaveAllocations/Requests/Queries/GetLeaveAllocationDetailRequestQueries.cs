using HR_Management.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR_Management.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationDetailRequestQueries : IRequest<LeaveAllocationDTO>
    {
        public int Id { get; set; }
    }
}

using HR_Management.Application.DTOs.LeaveAllocation;
using MediatR;
using System.Collections.Generic;

namespace HR_Management.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationListRequestQueries : IRequest<List<LeaveAllocationDTO>>
    {
    }
}

using HR_Management.Application.DTOs.LeaveRequest;
using HR_Management.Domain;
using MediatR;
using System.Collections.Generic;

namespace HR_Management.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestListRequestQueries : IRequest<List<LeaveRequestListDTO>>
    {
    }
}

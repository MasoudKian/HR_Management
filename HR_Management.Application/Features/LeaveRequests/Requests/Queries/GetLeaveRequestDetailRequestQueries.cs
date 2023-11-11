using HR_Management.Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestDetailRequestQueries : IRequest<LeaveRequestDTO>
    {
        public int Id { get; set; }
    }
}

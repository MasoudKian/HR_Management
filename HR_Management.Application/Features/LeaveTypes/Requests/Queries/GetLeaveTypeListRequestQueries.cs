using HR_Management.Application.DTOs;
using MediatR;
using System.Collections.Generic;

namespace HR_Management.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeListRequestQueries : IRequest<List<LeaveTypeDTO>>
    {
    }
}

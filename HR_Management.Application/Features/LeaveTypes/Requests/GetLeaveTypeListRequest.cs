using HR_Management.Application.DTOs;
using MediatR;
using System.Collections.Generic;

namespace HR_Management.Application.Features.LeaveTypes.Requests
{
    public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDTO>>
    {
    }
}

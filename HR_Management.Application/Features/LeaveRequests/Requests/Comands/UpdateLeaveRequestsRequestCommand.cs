using HR_Management.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR_Management.Application.Features.LeaveRequests.Requests.Comands
{
    public class UpdateLeaveRequestsRequestCommand : IRequest<Unit>
    {
        public LeaveRequestDTO LeaveRequestDTO { get; set; }
    }
}

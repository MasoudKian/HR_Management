using HR_Management.Application.DTOs.LeaveRequest;
using HR_Management.Application.Responses;
using MediatR;

namespace HR_Management.Application.Features.LeaveRequests.Requests.Comands
{
    public class CreateLeaveRequestRequestsCammands : IRequest<BaseCommandResponse>
    {
        public CreateLeaveRequestDTO CreateLeaveRequestDTO { get; set; }
    }
}

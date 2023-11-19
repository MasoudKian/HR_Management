using MediatR;

namespace HR_Management.Application.Features.LeaveRequests.Requests.Comands
{
    public class DeleteLeaveRequestRequestsCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}

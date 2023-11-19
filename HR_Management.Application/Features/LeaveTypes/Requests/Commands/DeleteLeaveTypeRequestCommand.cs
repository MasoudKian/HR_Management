using MediatR;

namespace HR_Management.Application.Features.LeaveTypes.Requests.Commands
{
    public class DeleteLeaveTypeRequestCommand: IRequest<Unit>
    {
        public int Id { get; set; }
    }
}

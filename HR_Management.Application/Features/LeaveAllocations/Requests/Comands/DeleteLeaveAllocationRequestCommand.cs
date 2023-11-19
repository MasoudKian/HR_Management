using MediatR;

namespace HR_Management.Application.Features.LeaveAllocations.Requests.Comands
{
    public class DeleteLeaveAllocationRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}

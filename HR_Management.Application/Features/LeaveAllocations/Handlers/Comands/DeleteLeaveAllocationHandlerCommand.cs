using AutoMapper;
using HR_Management.Application.Exeptions;
using HR_Management.Application.Features.LeaveAllocations.Requests.Comands;
using HR_Management.Application.Persistence.Contract;
using HR_Management.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveAllocations.Handlers.Comands
{
    public class DeleteLeaveAllocationHandlerCommand 
        : IRequestHandler<DeleteLeaveAllocationRequestCommand, Unit>
    {
        #region Constructor

        private readonly ILeaveAllocationRepostiory _leaveAllocationRepostiory;
        private readonly IMapper _mapper;
        public DeleteLeaveAllocationHandlerCommand(ILeaveAllocationRepostiory leaveAllocationRepostiory
            , IMapper mapper)
        {
            _leaveAllocationRepostiory = leaveAllocationRepostiory;
            _mapper = mapper;
        }

        #endregion
        public async Task<Unit> Handle(DeleteLeaveAllocationRequestCommand request
            , CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepostiory.Get(request.Id);
            await _leaveAllocationRepostiory.Delete(leaveAllocation);

            if (leaveAllocation == null)
                throw new NotFoundExeption(nameof(LeaveAllocation), request.Id);

            return Unit.Value;
        }
    }
}

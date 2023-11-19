using AutoMapper;
using HR_Management.Application.Features.LeaveAllocations.Requests.Comands;
using HR_Management.Application.Persistence.Contract;
using HR_Management.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveAllocations.Handlers.Comands
{
    public class CreateLeaveAllocationHandlerComands
        : IRequestHandler<CreateLeaveAllocationRequestComands, int>
    {

        #region Constructor

        private readonly ILeaveAllocationRepostiory _leaveAllocationRepostiory;
        private readonly IMapper _mapper;
        public CreateLeaveAllocationHandlerComands(ILeaveAllocationRepostiory leaveAllocationRepostiory
            , IMapper mapper)
        {
            _leaveAllocationRepostiory = leaveAllocationRepostiory;
            _mapper = mapper;
        }

        #endregion

        public async Task<int> Handle(CreateLeaveAllocationRequestComands request, CancellationToken cancellationToken)
        {
            var leaveAllocation = _mapper.Map<LeaveAllocation>(request.LeaveAllocationDTO);
            leaveAllocation = await _leaveAllocationRepostiory.Add(leaveAllocation);
            return leaveAllocation.Id;
        }
    }
}

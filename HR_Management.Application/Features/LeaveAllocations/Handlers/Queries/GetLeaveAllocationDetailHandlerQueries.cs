using AutoMapper;
using HR_Management.Application.DTOs;
using HR_Management.Application.Features.LeaveAllocations.Requests.Queries;
using HR_Management.Application.Persistence.Contract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetLeaveAllocationDetailHandlerQueries :
        IRequestHandler<GetLeaveAllocationDetailRequestQueries, LeaveAllocationDTO>
    {
        #region Constructor
        private readonly ILeaveAllocationRepostiory _leaveAllocationRepostiory;
        private readonly IMapper _mapper;

        public GetLeaveAllocationDetailHandlerQueries(ILeaveAllocationRepostiory leaveAllocationRepostiory
            , IMapper mapper)
        {
            _leaveAllocationRepostiory = leaveAllocationRepostiory;
            _mapper = mapper;
        }
        #endregion

        public async Task<LeaveAllocationDTO> Handle(GetLeaveAllocationDetailRequestQueries request
            , CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepostiory
                .GetLeaveAllocationWithDetails(request.Id);
            return _mapper.Map<LeaveAllocationDTO>(leaveAllocation);
        }
    }
}

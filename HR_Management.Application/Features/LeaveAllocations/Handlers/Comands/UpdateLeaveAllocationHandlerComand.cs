using AutoMapper;
using HR_Management.Application.Features.LeaveAllocations.Requests.Comands;
using HR_Management.Application.Persistence.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveAllocations.Handlers.Comands
{
    public class UpdateLeaveAllocationHandlerComand : IRequestHandler<UpdateLeaveAllocationRequestCommand, Unit>
    {

        #region Constructor
        private readonly ILeaveAllocationRepostiory _leaveAllocationRepostiory;
        private readonly IMapper _mapper;

        public UpdateLeaveAllocationHandlerComand(ILeaveAllocationRepostiory leaveAllocationRepostiory
            ,IMapper mapper)
        {
            _leaveAllocationRepostiory = leaveAllocationRepostiory;
            _mapper = mapper;
        }

        #endregion
        public async Task<Unit> Handle(UpdateLeaveAllocationRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepostiory.Get(request.LeaveAllocationDTO.Id);
            _mapper.Map(request.LeaveAllocationDTO, leaveAllocation);
            await _leaveAllocationRepostiory.Update(leaveAllocation);

            return Unit.Value;
        }
    }
}

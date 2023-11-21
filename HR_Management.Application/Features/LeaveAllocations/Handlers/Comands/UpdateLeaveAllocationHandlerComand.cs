using AutoMapper;
using HR_Management.Application.DTOs.LeaveAllocation.Validators;
using HR_Management.Application.DTOs.LeaveType.Validators;
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
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveAllocationHandlerComand(ILeaveAllocationRepostiory leaveAllocationRepostiory
            ,IMapper mapper ,ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveAllocationRepostiory = leaveAllocationRepostiory;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        #endregion
        public async Task<Unit> Handle(UpdateLeaveAllocationRequestCommand request, CancellationToken cancellationToken)
        {
            #region CreateValidator

            var validator = new UpdateLeaveAllocationDTOValidator(_leaveTypeRepository);
            //var validator = new CreateLeaveTypeDTOValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateLeaveAllocationDTO);

            if (validationResult.IsValid == false)
                throw new Exception();

            #endregion

            var leaveAllocation = await _leaveAllocationRepostiory.Get(request.UpdateLeaveAllocationDTO.Id);
            _mapper.Map(request.UpdateLeaveAllocationDTO, leaveAllocation);
            await _leaveAllocationRepostiory.Update(leaveAllocation);

            return Unit.Value;
        }
    }
}

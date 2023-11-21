using AutoMapper;
using HR_Management.Application.DTOs.LeaveAllocation.Validators;
using HR_Management.Application.DTOs.LeaveType.Validators;
using HR_Management.Application.Features.LeaveAllocations.Requests.Comands;
using HR_Management.Application.Persistence.Contract;
using HR_Management.Domain;
using MediatR;
using System;
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
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveAllocationHandlerComands(ILeaveAllocationRepostiory leaveAllocationRepostiory
            , IMapper mapper,ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveAllocationRepostiory = leaveAllocationRepostiory;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        #endregion

        public async Task<int> Handle(CreateLeaveAllocationRequestComands request, CancellationToken cancellationToken)
        {
            #region CreateValidator

            var validator = new CreateLeaveAllocationDTOValidator(_leaveTypeRepository);
            //var validator = new CreateLeaveTypeDTOValidator();
            var validationResult = await validator.ValidateAsync(request.CreateLeaveAllocationDTO);

            if (validationResult.IsValid == false)
                throw new Exception();

            #endregion

            var leaveAllocation = _mapper.Map<LeaveAllocation>(request.CreateLeaveAllocationDTO);
            leaveAllocation = await _leaveAllocationRepostiory.Add(leaveAllocation);
            return leaveAllocation.Id;
        }
    }
}

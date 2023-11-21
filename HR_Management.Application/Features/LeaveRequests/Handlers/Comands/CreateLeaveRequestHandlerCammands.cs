using AutoMapper;
using HR_Management.Application.DTOs.LeaveRequest.Validators;
using HR_Management.Application.DTOs.LeaveType.Validators;
using HR_Management.Application.Features.LeaveRequests.Requests.Comands;
using HR_Management.Application.Persistence.Contract;
using HR_Management.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveRequests.Handlers.Comands
{
    public class CreateLeaveRequestHandlerCammands
        : IRequestHandler<CreateLeaveRequestRequestsCammands, int>
    {

        #region Constructor
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveRequestHandlerCammands(ILeaveRequestRepository leaveRequestRepository
            , IMapper mapper,ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        #endregion

        public async Task<int> Handle(CreateLeaveRequestRequestsCammands request, CancellationToken cancellationToken)
        {
            #region CreateValidator

            var validator = new CreateLeaveRequestDTOValidator(_leaveTypeRepository);
            //var validator = new CreateLeaveTypeDTOValidator();
            var validationResult = await validator.ValidateAsync(request.CreateLeaveRequestDTO);

            if (validationResult.IsValid == false)
                throw new Exception();

            #endregion

            var leaveRequest = _mapper.Map<LeaveRequest>(request.CreateLeaveRequestDTO);
            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);
            return leaveRequest.Id;
        }
    }
}

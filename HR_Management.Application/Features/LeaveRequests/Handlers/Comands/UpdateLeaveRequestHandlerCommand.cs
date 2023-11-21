using AutoMapper;
using HR_Management.Application.DTOs.LeaveRequest.Validators;
using HR_Management.Application.DTOs.LeaveType.Validators;
using HR_Management.Application.Exeptions;
using HR_Management.Application.Features.LeaveRequests.Requests.Comands;
using HR_Management.Application.Persistence.Contract;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveRequests.Handlers.Comands
{
    public class UpdateLeaveRequestHandlerCommand : IRequestHandler<UpdateLeaveRequestsRequestCommand, Unit>
    {


        #region Constructor

        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveRequestHandlerCommand(ILeaveRequestRepository leaveRequestRepository
            , IMapper mapper,ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        #endregion

        public async Task<Unit> Handle(UpdateLeaveRequestsRequestCommand request, CancellationToken cancellationToken)
        {

            #region CreateValidator

            var validator = new UpdateLeaveRequestDTOValidator(_leaveTypeRepository);
            //var validator = new CreateLeaveTypeDTOValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateLeaveRequestDTO);

            if (validationResult.IsValid == false)
                throw new ValidationExeption(validationResult);

            #endregion

            var leaveRequest = await _leaveRequestRepository.Get(request.Id);
            if (request.UpdateLeaveRequestDTO != null)
            {
                _mapper.Map(request.UpdateLeaveRequestDTO, leaveRequest);
                await _leaveRequestRepository.Update(leaveRequest);
            }
            else if (request.ChangeLeaveRequestApprovalDTO != null)
            {
                await _leaveRequestRepository
                    .ChangeApprovalStatus(leaveRequest,request.ChangeLeaveRequestApprovalDTO.Approved);
            }

            return Unit.Value;

        }
    }
}

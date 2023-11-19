using AutoMapper;
using HR_Management.Application.Features.LeaveRequests.Requests.Comands;
using HR_Management.Application.Persistence.Contract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveRequests.Handlers.Comands
{
    public class UpdateLeaveRequestHandlerCommand : IRequestHandler<UpdateLeaveRequestsRequestCommand, Unit>
    {


        #region Constructor

        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveRequestHandlerCommand(ILeaveRequestRepository leaveRequestRepository
            , IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        #endregion
        public async Task<Unit> Handle(UpdateLeaveRequestsRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.Get(request.Id);
            if (request.LeaveRequestDTO != null)
            {
                _mapper.Map(request.LeaveRequestDTO, leaveRequest);
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

using AutoMapper;
using HR_Management.Application.Features.LeaveRequests.Requests.Comands;
using HR_Management.Application.Persistence.Contract;
using HR_Management.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveRequests.Handlers.Comands
{
    public class CreateLeaveRequestHandlerCammands
        : IRequestHandler<CreateLeaveRequestRequestsCammands, int>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        #region Constructor

        public CreateLeaveRequestHandlerCammands(ILeaveRequestRepository leaveRequestRepository
            , IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        #endregion

        public async Task<int> Handle(CreateLeaveRequestRequestsCammands request, CancellationToken cancellationToken)
        {
            var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDTO);
            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);
            return leaveRequest.Id;
        }
    }
}

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
            ,IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        #endregion
        public Task<Unit> Handle(UpdateLeaveRequestsRequestCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}

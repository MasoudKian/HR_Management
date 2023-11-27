using AutoMapper;
using HR_Management.Application.Exeptions;
using HR_Management.Application.Features.LeaveRequests.Requests.Comands;
using HR_Management.Application.Contract.Persistence;
using HR_Management.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveRequests.Handlers.Comands
{
    public class DeleteLeaveRequestHandlerCommand : IRequestHandler<DeleteLeaveRequestRequestsCommand, Unit>
    {
        #region Constructor
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        public DeleteLeaveRequestHandlerCommand(ILeaveRequestRepository leaveRequestRepository
            , IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        #endregion

        public async Task<Unit> Handle(DeleteLeaveRequestRequestsCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.Get(request.Id);
            await _leaveRequestRepository.Delete(leaveRequest);

            if (leaveRequest == null)
                throw new NotFoundExeption(nameof(LeaveRequest), request.Id);

            return Unit.Value;
        }
    }
}

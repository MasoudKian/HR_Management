using AutoMapper;
using HR_Management.Application.DTOs.LeaveRequest;
using HR_Management.Application.Features.LeaveRequests.Requests.Queries;
using HR_Management.Application.Persistence.Contract;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveRequests.Handlers.Queries
{
    public class GetLeaveRequestDetailHandlerQueries
        : IRequestHandler<GetLeaveRequestDetailRequestQueries, LeaveRequestDTO>
    {
        #region Contstructor

        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestDetailHandlerQueries(ILeaveRequestRepository leaveRequestRepository
            , IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        #endregion

        public async Task<LeaveRequestDTO> Handle(GetLeaveRequestDetailRequestQueries request
            , CancellationToken cancellationToken)
        {
            var leaveReauest = await _leaveRequestRepository.Get(request.Id);
            return _mapper.Map<LeaveRequestDTO>(leaveReauest);
        }
    }
}

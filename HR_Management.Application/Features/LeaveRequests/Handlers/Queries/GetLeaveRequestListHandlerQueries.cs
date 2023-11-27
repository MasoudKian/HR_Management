using AutoMapper;
using HR_Management.Application.DTOs.LeaveRequest;
using HR_Management.Application.Features.LeaveRequests.Requests.Queries;
using HR_Management.Application.Contract.Persistence;
using HR_Management.Domain;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveRequests.Handlers.Queries
{
    public class GetLeaveRequestListHandlerQueries :
        IRequestHandler<GetLeaveRequestListRequestQueries, List<LeaveRequestListDTO>>
    {

        #region Contstructor

        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestListHandlerQueries(ILeaveRequestRepository leaveRequestRepository
            , IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        #endregion

        public async Task<List<LeaveRequestListDTO>> Handle(GetLeaveRequestListRequestQueries request
            , CancellationToken cancellationToken)
        {
            var leaveReauestList = await _leaveRequestRepository.GetLeaveRequestsWithDetails();
            return _mapper.Map<List<LeaveRequestListDTO>>(leaveReauestList);
        }
    }
}

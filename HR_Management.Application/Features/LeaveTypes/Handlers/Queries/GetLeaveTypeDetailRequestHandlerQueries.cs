using AutoMapper;
using HR_Management.Application.DTOs.LeaveType;
using HR_Management.Application.Features.LeaveTypes.Requests.Queries;
using HR_Management.Application.Contract.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLeaveTypeDetailRequestHandlerQueries :
        IRequestHandler<GetLeaveTypeDetailRequestQueries, LeaveTypeDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        #region Constructor 

        public GetLeaveTypeDetailRequestHandlerQueries(ILeaveTypeRepository leaveTypeRepository
            ,IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        #endregion
        public async Task<LeaveTypeDTO> Handle(GetLeaveTypeDetailRequestQueries request
            , CancellationToken cancellationToken)
        {
            var leavType = await _leaveTypeRepository.Get(request.Id);
            return _mapper.Map<LeaveTypeDTO>(leavType);
        }
    }
}

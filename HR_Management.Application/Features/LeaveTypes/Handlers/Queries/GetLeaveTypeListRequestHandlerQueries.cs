using HR_Management.Application.DTOs;
using HR_Management.Application.Features.LeaveTypes.Requests;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLeaveTypeListRequestHandlerQueries :
        IRequestHandler<GetLeaveTypeListRequest, List<LeaveTypeDTO>>
    {
        public Task<List<LeaveTypeDTO>> Handle(GetLeaveTypeListRequest request
            , CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}

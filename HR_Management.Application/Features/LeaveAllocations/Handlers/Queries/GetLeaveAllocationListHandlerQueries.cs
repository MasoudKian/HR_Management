﻿using AutoMapper;
using HR_Management.Application.DTOs;
using HR_Management.Application.Features.LeaveAllocations.Requests.Queries;
using HR_Management.Application.Persistence.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetLeaveAllocationListHandlerQueries :
        IRequestHandler<GetLeaveAllocationListRequestQueries, List<LeaveAllocationDTO>>
    {
        private readonly ILeaveAllocationRepostiory _leaveAllocationRepostiory;
        private readonly IMapper _mapper;

        public GetLeaveAllocationListHandlerQueries(ILeaveAllocationRepostiory leaveAllocationRepostiory
            , IMapper mapper)
        {
            _leaveAllocationRepostiory = leaveAllocationRepostiory;
            _mapper = mapper;
        }

        public async Task<List<LeaveAllocationDTO>> Handle(GetLeaveAllocationListRequestQueries request
            , CancellationToken cancellationToken)
        {
            var leaveAllocationList = await _leaveAllocationRepostiory.GetAll();
            return _mapper.Map<List<LeaveAllocationDTO>>(leaveAllocationList);
        }
    }
}
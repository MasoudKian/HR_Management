﻿using HR_Management.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR_Management.Application.Persistence.Contract
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {

        Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
        Task<List<LeaveAllocation>> GetLeaveRequestsWithDetails();
        Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvedStatus);
    }
}
 
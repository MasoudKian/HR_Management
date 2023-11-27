using HR_Management.Application.Persistence.Contract;
using HR_Management.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Persistence.Repositories
{
    public class LeaveAllocationRepostiory : GenericRepository<LeaveAllocation> ,ILeaveAllocationRepostiory
    {
        #region Constructor

        private readonly LeaveManagementDbContext _dbContext;

        public LeaveAllocationRepostiory(LeaveManagementDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            var leaveAllocations = await _dbContext.LeaveAllocations
                .Include(t=>t.LeaveType).ToListAsync();

            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocation = await _dbContext.LeaveAllocations
                .Include(t => t.LeaveType).FirstOrDefaultAsync(i=>i.Id==id);

            return leaveAllocation;
        }
    }
}

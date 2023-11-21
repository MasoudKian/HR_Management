using HR_Management.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR_Management.Persistence
{
    public class LeaveManagementDbContext : DbContext
    {
        public LeaveManagementDbContext(DbContextOptions<LeaveManagementDbContext> options ) : base( options ) 
        {
            
        }

        #region DbSets

        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

        #endregion
    }
}

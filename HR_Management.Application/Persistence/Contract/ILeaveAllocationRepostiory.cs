using HR_Management.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR_Management.Application.Persistence.Contract
{
    public interface ILeaveAllocationRepostiory : IGenericRepository<LeaveAllocation>
    {
        Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails();
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
    }
}

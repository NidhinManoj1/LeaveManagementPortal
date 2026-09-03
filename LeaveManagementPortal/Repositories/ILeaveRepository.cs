using LeaveManagementPortal.Models;

namespace LeaveManagementPortal.Repositories
{
    public interface ILeaveRepository
    {
        Task<List<LeaveRequest>> GetAllAsync();

        Task<LeaveRequest?> GetByIdAsync(int id);

        Task CreateAsync(LeaveRequest leave);

        Task UpdateStatusAsync(int id, string status);
    }
}

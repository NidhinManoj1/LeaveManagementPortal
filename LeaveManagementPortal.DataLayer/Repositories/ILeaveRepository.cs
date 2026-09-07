using LeaveManagementPortal.Common.Enums;
using LeaveManagementPortal.Model.Entities;

namespace LeaveManagementPortal.DataLayer.Repositories
{
    public interface ILeaveRepository
    {
        Task<List<LeaveRequest>> GetAllAsync();

        Task<LeaveRequest?> GetByIdAsync(int id);

        Task CreateAsync(LeaveRequest leave);

        Task UpdateStatusAsync(int id, LeaveStatus status);
    }
}

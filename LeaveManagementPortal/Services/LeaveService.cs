using LeaveManagementPortal.Models;
using LeaveManagementPortal.Repositories;

namespace LeaveManagementPortal.Services
{
    public class LeaveService
    {
        private readonly ILeaveRepository _repository;

        public LeaveService(ILeaveRepository repository)
        {
            _repository = repository;
        }

        public Task<List<LeaveRequest>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<LeaveRequest?> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task CreateAsync(LeaveRequest leave)
        {
            return _repository.CreateAsync(leave);
        }

        public Task UpdateStatusAsync(int id, string status)
        {
            return _repository.UpdateStatusAsync(id, status);
        }
    }
}

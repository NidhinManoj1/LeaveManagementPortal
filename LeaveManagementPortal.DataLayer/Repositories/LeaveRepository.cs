using Dapper;
using LeaveManagementPortal.Model.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace LeaveManagementPortal.DataLayer.Repositories
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly IConfiguration _configuration;

        public LeaveRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection CreateConnection()
        {
            var connectionString =
                _configuration.GetConnectionString("DefaultConnection");

            return new SqlConnection(connectionString);
        }


        public async Task<List<LeaveRequest>> GetAllAsync()
        {
            using var connection = CreateConnection();

            var leaves = await connection.QueryAsync<LeaveRequest>(
                "GetAllLeaveRequests",
                commandType: CommandType.StoredProcedure
            );

            return leaves.ToList();
        }


        public async Task<LeaveRequest?> GetByIdAsync(int id)
        {
            using var connection = CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@Id", id);

            return await connection.QueryFirstOrDefaultAsync<LeaveRequest>(
                "GetLeaveRequestById",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }


        public async Task CreateAsync(LeaveRequest leave)
        {
            using var connection = CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@EmployeeName", leave.EmployeeName);
            parameters.Add("@LeaveType", leave.LeaveType);
            parameters.Add("@StartDate", leave.StartDate);
            parameters.Add("@EndDate", leave.EndDate);
            parameters.Add("@Reason", leave.Reason);

            await connection.ExecuteAsync(
                "CreateLeaveRequest",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }


        public async Task UpdateStatusAsync(int id, string status)
        {
            using var connection = CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@Id", id);
            parameters.Add("@Status", status);

            await connection.ExecuteAsync(
                "UpdateLeaveStatus",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}

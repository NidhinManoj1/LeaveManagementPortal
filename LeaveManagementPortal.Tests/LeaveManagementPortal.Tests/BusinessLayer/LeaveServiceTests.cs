using Moq;
using LeaveManagementPortal.DataLayer.Repositories;
using LeaveManagementPortal.BusinessLayer.Services;
using LeaveManagementPortal.Model.Entities;
using LeaveManagementPortal.Common.Enums;

namespace LeaveManagementPortal.Tests.BusinessLayer
{
    [TestFixture]
    public class LeaveServiceTests
    {
        private Mock<ILeaveRepository> _mockRepository;
        private LeaveService _leaveService;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new Mock<ILeaveRepository>();
            _leaveService = new LeaveService(_mockRepository.Object);
        }
        [Test]
        public async Task GetAllAsync_ShouldReturnAllLeaveRequests()
        {
            // Arrange
            var leaves = new List<LeaveRequest>
            {
                new LeaveRequest(),
                new LeaveRequest()
            };

            _mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(leaves);

            // Act
            var result = await _leaveService.GetAllAsync();

            // Assert
            Assert.That(result, Is.EqualTo(leaves));
            _mockRepository.Verify(r => r.GetAllAsync(), Times.Once);
        }

        [Test]
        public async Task GetByIdAsync_ShouldReturnLeaveRequest()
        {
            // Arrange
            int id = 1;

            var leave = new LeaveRequest();

            _mockRepository.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(leave);

            // Act
            var result = await _leaveService.GetByIdAsync(id);

            // Assert
            Assert.That(result, Is.EqualTo(leave));
            _mockRepository.Verify(r => r.GetByIdAsync(id), Times.Once);
        }

        [Test]
        public async Task CreateAsync_ShouldCallRepositoryCreate()
        {
            // Arrange
            var leave = new LeaveRequest()
            {
                Id = 1,
                EmployeeName = "Nidhin Manoj",
                LeaveType = LeaveType.SickLeave,
                StartDate = new DateTime(2026, 9, 29),
                EndDate = new DateTime(2026, 9, 29),
                Reason = "Personal Reasons",
                Status = LeaveStatus.Pending,
                CreatedDate = DateTime.Now
            };

            _mockRepository.Setup(r => r.CreateAsync(leave)).Returns(Task.CompletedTask);

            // Act
            await _leaveService.CreateAsync(leave);

            // Assert
            _mockRepository.Verify(r => r.CreateAsync(leave), Times.Once);
        }

        [Test]
        public async Task UpdateStatusAsync_ShouldCallRepositoryUpdateStatus()
        {
            // Arrange
            int id = 1;
            LeaveStatus status = LeaveStatus.Approved;

            _mockRepository.Setup(r => r.UpdateStatusAsync(id, status)).Returns(Task.CompletedTask);

            // Act
            await _leaveService.UpdateStatusAsync(id, status);

            // Assert
            _mockRepository.Verify(r => r.UpdateStatusAsync(id, status), Times.Once);
        }

        [Test]
        public async Task GetByIdAsync_WhenLeaveDoesNotExist_ShouldReturnNull()
        {
            // Arrange
            int id = 999;

            _mockRepository.Setup(r => r.GetByIdAsync(id)).ReturnsAsync((LeaveRequest?)null);

            // Act
            var result = await _leaveService.GetByIdAsync(id);

            // Assert
            Assert.That(result, Is.Null);
        }
    }
}

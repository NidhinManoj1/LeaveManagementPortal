using System.ComponentModel.DataAnnotations;

namespace LeaveManagementPortal.Model.Entities
{
    public class LeaveRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee name is required.")]
        [StringLength(100, ErrorMessage = "Employee name cannot exceed 100 characters.")]
        public string EmployeeName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Leave type is required.")]
        public string LeaveType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Start date is required.")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "End date is required.")]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Reason is required.")]
        [StringLength(500, ErrorMessage = "Reason cannot exceed 500 characters.")]
        public string Reason { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }
    }
}

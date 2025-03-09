namespace EmployeeAdminPortal.Models
{
    public class UpdateEmployeeDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; } //make required property
        public string? Phone { get; set; } //make nullable property
        public decimal Salary { get; set; }

    }
}

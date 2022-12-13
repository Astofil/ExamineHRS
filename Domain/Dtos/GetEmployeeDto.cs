using Domain.Entities;

namespace Domain.Dtos;

public class GetEmployeeDto
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime HireDate { get; set; }
    public int Salary { get; set; }
    public int CommissionPct { get; set; }
    public string JobName { get; set; }
    public string DepartmentName { get; set; }
    
}
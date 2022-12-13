using Microsoft.AspNetCore.Http;
namespace Domain.Entities;

public class Employee
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime HireDate { get; set; }

    public int JobId { get; set; }
    public virtual Job Job { get; set; }
    public int Salary { get; set; }
    public int CommissionPct { get; set; }

    public int ManagerId { get; set; }
    public virtual Employee Manager { get; set; }

    public int DepartmentId { get; set; }
    public virtual Department Department { get; set; }

    public virtual List<JobHistory> JobHistories { get; set; }

    // public IFormFile File { get; set; }

    //Uploading File
}

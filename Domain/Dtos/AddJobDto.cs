using Domain.Entities;

namespace Domain.Dtos;

public class AddJobDto
{
    public int JobId { get; set; }
    public string JobTitle { get; set; }
    public int MinSalary { get; set; }
    public int MaxSalary { get; set; }
}
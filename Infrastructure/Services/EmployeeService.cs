using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class EmployeeService
{
    private readonly DataContext _context;
    public EmployeeService(DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<GetEmployeeDto>>> GetEmployee()
    {
        var list = await _context.Employees.Select(t => new GetEmployeeDto()
        {
            EmployeeId = t.EmployeeId,
            FirstName = t.FirstName,
            LastName = t.LastName,
            Email = t.Email,
            PhoneNumber = t.PhoneNumber,
            HireDate = t.HireDate,
            Salary = t.Salary,
            CommissionPct = t.CommissionPct,
            JobName = t.Job.JobTitle,
            DepartmentName = t.Department.DepartmentName
        }).ToListAsync();
        return new Response<List<GetEmployeeDto>>(list);
    }

    public async Task<Response<AddEmployeeDto>> AddEmployee(AddEmployeeDto employee)
    {
        var newEmployee = new Employee()
        {
            EmployeeId = employee.EmployeeId,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            PhoneNumber = employee.PhoneNumber,
            HireDate = employee.HireDate,
            Salary = employee.Salary,
            CommissionPct = employee.CommissionPct,
            JobId = employee.JobId,
            ManagerId = employee.ManagerId,
            DepartmentId = employee.DepartmentId
        };
        _context.Employees.Add(newEmployee);
        await _context.SaveChangesAsync();
        return new Response<AddEmployeeDto>(employee);
    }

    public async Task<Response<AddEmployeeDto>> UpdateEmployee(AddEmployeeDto employee)
    {
        var find = await _context.Employees.FindAsync(employee.EmployeeId);
        find.EmployeeId = employee.EmployeeId;
        find.FirstName = employee.FirstName;
        find.LastName = employee.LastName;
        find.Email = employee.Email;
        find.PhoneNumber = employee.PhoneNumber;
        find.HireDate = employee.HireDate;
        find.Salary = employee.Salary;
        find.CommissionPct = employee.CommissionPct;
        find.JobId = employee.JobId;
        find.ManagerId = employee.ManagerId;
        find.DepartmentId = employee.DepartmentId;
        await _context.SaveChangesAsync();
        return new Response<AddEmployeeDto>(employee);
    }

    public async Task<Response<string>> DeleteEmployee(int id)
    {
        var find = await _context.Employees.FindAsync(id);
        _context.Employees.Remove(find);
        var response = await _context.SaveChangesAsync();
        if(response > 0)
            return new Response<string>("Employees succesfully deleted");
        return new Response<string>(/*HttpStatusCode.BadRequest ,*/ "Object not found");
    }
}
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class EmployeeController
{
    private readonly EmployeeService _employeeService;
    public EmployeeController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<Response<List<GetEmployeeDto>>> GetEmployee()
    {
        return await _employeeService.GetEmployee();
    }

    [HttpPut]
    public async Task<Response<AddEmployeeDto>> AddEmployee(AddEmployeeDto employee)
    {
        return await _employeeService.AddEmployee(employee);
    }

    [HttpPost]
    public async Task<Response<AddEmployeeDto>> UpdateEmployee(AddEmployeeDto employee)
    {
        return await _employeeService.UpdateEmployee(employee);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteEmployee(int id)
    {
        return await _employeeService.DeleteEmployee(id);
    }
}
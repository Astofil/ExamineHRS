using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class DepartmentController
{
    private readonly DepartmentService _departmentService;
    public DepartmentController(DepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet]
    public async Task<Response<List<GetDepartmentDto>>> GetDepartment()
    {
        return await _departmentService.GetDepartment();
    }

    [HttpPut]
    public async Task<Response<AddDepartmentDto>> AddDepartment(AddDepartmentDto department)
    {
        return await _departmentService.AddDepartment(department);
    }

    [HttpPost]
    public async Task<Response<AddDepartmentDto>> UpdateDepartment(AddDepartmentDto department)
    {
        return await _departmentService.UpdateDepartment(department);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteDepartment(int id)
    {
        return await _departmentService.DeleteDepartment(id);
    }
}
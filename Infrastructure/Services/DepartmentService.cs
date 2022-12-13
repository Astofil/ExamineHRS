using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class DepartmentService
{
    private readonly DataContext _context;
    public DepartmentService(DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<GetDepartmentDto>>> GetDepartment()
    {
        var list = await _context.Departments.Select(t => new GetDepartmentDto()
        {
            DepartmentId = t.DepartmentId,
            DepartmentName = t.DepartmentName,
            StreetAddress = t.Location.StreetAddress,
            PostalCode = t.Location.PostalCode,
            City = t.Location.City,
            StateProvince = t.Location.StateProvince
        }).ToListAsync();
        return new Response<List<GetDepartmentDto>>(list);
    }

    public async Task<Response<AddDepartmentDto>> AddDepartment(AddDepartmentDto department)
    {
        var newDepartment = new Department()
        {
            DepartmentId = department.DepartmentId,
            DepartmentName = department.DepartmentName,
            LocationId = department.LocationId
        };
        _context.Departments.Add(newDepartment);
        await _context.SaveChangesAsync();
        return new Response<AddDepartmentDto>(department);
    }

    public async Task<Response<AddDepartmentDto>> UpdateDepartment(AddDepartmentDto department)
    {
        var find = await _context.Departments.FindAsync(department.DepartmentId);
        find.DepartmentId = department.DepartmentId;
        find.DepartmentName = department.DepartmentName;
        find.LocationId = department.LocationId;
        await _context.SaveChangesAsync();
        return new Response<AddDepartmentDto>(department);
    }

    public async Task<Response<string>> DeleteDepartment(int id)
    {
        var find = await _context.Departments.FindAsync(id);
        _context.Departments.Remove(find);
        var response = await _context.SaveChangesAsync();
        if(response > 0)
            return new Response<string>("Department succesfully deleted");
        return new Response<string>(/*HttpStatusCode.BadRequest ,*/ "Object not found");
    }
}
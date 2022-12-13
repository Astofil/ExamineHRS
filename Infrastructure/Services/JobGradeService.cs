using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class JobGradeService
{
    private readonly DataContext _context;
    public JobGradeService(DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<GetJobGradeDto>>> GetJobGrade()
    {
        var list = await _context.JobGrades.Select(t => new GetJobGradeDto()
        {
            GradeLevel = t.GradeLevel,
            LowestSalary = t.LowestSalary,
            HighestSalary = t.HighestSalary,
        }).ToListAsync();
        return new Response<List<GetJobGradeDto>>(list);
    }

    public async Task<Response<AddJobGradeDto>> AddJobGrade(AddJobGradeDto jobGrade)
    {
        var newJobGrade = new JobGrade()
        {
            GradeLevel = jobGrade.GradeLevel,
            LowestSalary = jobGrade.LowestSalary,
            HighestSalary = jobGrade.HighestSalary,
        };
        _context.JobGrades.Add(newJobGrade);
        await _context.SaveChangesAsync();
        return new Response<AddJobGradeDto>(jobGrade);
    }

    public async Task<Response<AddJobGradeDto>> UpdateJobGrade(AddJobGradeDto jobGrade)
    {
        var find = await _context.JobGrades.FindAsync(jobGrade.GradeLevel);
        find.GradeLevel = jobGrade.GradeLevel;
        find.LowestSalary = jobGrade.LowestSalary;
        find.HighestSalary = jobGrade.HighestSalary;
        await _context.SaveChangesAsync();
        return new Response<AddJobGradeDto>(jobGrade);
    }

    public async Task<Response<string>> DeleteJobGrade(string GradeLevel)
    {
        var find = await _context.JobGrades.FindAsync(GradeLevel);
        _context.JobGrades.Remove(find);
        var response = await _context.SaveChangesAsync();
        if(response > 0)
            return new Response<string>("JobGrade succesfully deleted");
        return new Response<string>(/*HttpStatusCode.BadRequest ,*/ "Object not found");
    }
}
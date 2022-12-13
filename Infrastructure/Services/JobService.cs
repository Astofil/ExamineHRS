using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class JobService
{
    private readonly DataContext _context;
    public JobService(DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<GetJobDto>>> GetJob()
    {
        var list = await _context.Jobs.Select(t => new GetJobDto()
        {
            JobId = t.JobId,
            JobTitle = t.JobTitle,
            MinSalary = t.MinSalary,
            MaxSalary = t.MaxSalary,
        }).ToListAsync();
        return new Response<List<GetJobDto>>(list);
    }

    public async Task<Response<AddJobDto>> AddJob(AddJobDto job)
    {
        var newJob = new Job()
        {
            JobId = job.JobId,
            JobTitle = job.JobTitle,
            MinSalary = job.MinSalary,
            MaxSalary = job.MaxSalary,
        };
        _context.Jobs.Add(newJob);
        await _context.SaveChangesAsync();
        return new Response<AddJobDto>(job);
    }

    public async Task<Response<AddJobDto>> UpdateJob(AddJobDto job)
    {
        var find = await _context.Jobs.FindAsync(job.JobId);
        find.JobId = job.JobId;
        find.JobTitle = job.JobTitle;
        find.MinSalary = job.MinSalary;
        find.MaxSalary = job.MaxSalary;
        await _context.SaveChangesAsync();
        return new Response<AddJobDto>(job);
    }

    public async Task<Response<string>> DeleteJob(int id)
    {
        var find = await _context.Jobs.FindAsync(id);
        _context.Jobs.Remove(find);
        var response = await _context.SaveChangesAsync();
        if(response > 0)
            return new Response<string>("Job succesfully deleted");
        return new Response<string>(/*HttpStatusCode.BadRequest ,*/ "Object not found");
    }
}
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class JobHistoryService
{
    private readonly DataContext _context;
    public JobHistoryService(DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<GetJobHistoryDto>>> GetJobHistory()
    {
        var list = await _context.JobHistories.Select(t => new GetJobHistoryDto()
        {
            EmployeeId = t.EmployeeId,
            StartDate = t.StartDate,
            EndDate = t.EndDate,
            JobTitle = t.Job.JobTitle,
            DepartmentName = t.Department.DepartmentName,
        }).ToListAsync();
        return new Response<List<GetJobHistoryDto>>(list);
    }

    public async Task<Response<AddJobHistoryDto>> AddJobHistory(AddJobHistoryDto jobHistory)
    {
        var newJobHistory = new JobHistory()
        {
            EmployeeId = jobHistory.EmployeeId,
            StartDate = jobHistory.StartDate,
            EndDate = jobHistory.EndDate,
            JobId = jobHistory.JobId,
            DepartmentId = jobHistory.DepartmentId
        };
        _context.JobHistories.Add(newJobHistory);
        await _context.SaveChangesAsync();
        return new Response<AddJobHistoryDto>(jobHistory);
    }

    public async Task<Response<AddJobHistoryDto>> UpdateJobHistory(AddJobHistoryDto jobHistory)
    {
        var find = await _context.JobHistories.FindAsync(jobHistory.EmployeeId);
        find.EmployeeId = jobHistory.EmployeeId;
        find.StartDate = jobHistory.StartDate;
        find.EndDate = jobHistory.EndDate;
        find.JobId = jobHistory.JobId;
        find.DepartmentId = jobHistory.DepartmentId;
        await _context.SaveChangesAsync();
        return new Response<AddJobHistoryDto>(jobHistory);
    }

    public async Task<Response<string>> DeleteJobHistory(int id)
    {
        var find = await _context.JobHistories.FindAsync(id);
        _context.JobHistories.Remove(find);
        var response = await _context.SaveChangesAsync();
        if(response > 0)
            return new Response<string>("JobHistory succesfully deleted");
        return new Response<string>(/*HttpStatusCode.BadRequest ,*/ "Object not found");
    }
}
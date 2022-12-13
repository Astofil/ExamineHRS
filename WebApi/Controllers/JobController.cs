using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class JobController
{
    private readonly JobService _jobService;
    public JobController(JobService jobService)
    {
        _jobService = jobService;
    }

    [HttpGet]
    public async Task<Response<List<GetJobDto>>> GetJob()
    {
        return await _jobService.GetJob();
    }

    [HttpPut]
    public async Task<Response<AddJobDto>> AddJob(AddJobDto job)
    {
        return await _jobService.AddJob(job);
    }

    [HttpPost]
    public async Task<Response<AddJobDto>> UpdateJob(AddJobDto job)
    {
        return await _jobService.UpdateJob(job);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteJob(int id)
    {
        return await _jobService.DeleteJob(id);
    }
}
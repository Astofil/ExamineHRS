using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class JobHistoryController
{
    private readonly JobHistoryService _jobHistoryService;
    public JobHistoryController(JobHistoryService jobHistoryService)
    {
        _jobHistoryService = jobHistoryService;
    }

    [HttpGet]
    public async Task<Response<List<GetJobHistoryDto>>> GetJobHistory()
    {
        return await _jobHistoryService.GetJobHistory();
    }

    [HttpPut]
    public async Task<Response<AddJobHistoryDto>> AddJobHistory(AddJobHistoryDto jobHistory)
    {
        return await _jobHistoryService.AddJobHistory(jobHistory);
    }

    [HttpPost]
    public async Task<Response<AddJobHistoryDto>> UpdateJobHistory(AddJobHistoryDto jobHistory)
    {
        return await _jobHistoryService.UpdateJobHistory(jobHistory);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteJobHistory(int id)
    {
        return await _jobHistoryService.DeleteJobHistory(id);
    }
}
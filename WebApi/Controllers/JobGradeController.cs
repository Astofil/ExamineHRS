using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class JobGradeController
{
    private readonly JobGradeService _jobGradeService;
    public JobGradeController(JobGradeService jobGradeService)
    {
        _jobGradeService = jobGradeService;
    }

    [HttpGet]
    public async Task<Response<List<GetJobGradeDto>>> GetJobGrade()
    {
        return await _jobGradeService.GetJobGrade();
    }

    [HttpPut]
    public async Task<Response<AddJobGradeDto>> AddJobGrade(AddJobGradeDto jobGrade)
    {
        return await _jobGradeService.AddJobGrade(jobGrade);
    }

    [HttpPost]
    public async Task<Response<AddJobGradeDto>> UpdateJobGrade(AddJobGradeDto jobGrade)
    {
        return await _jobGradeService.UpdateJobGrade(jobGrade);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteJobGrade(string jobGrade)
    {
        return await _jobGradeService.DeleteJobGrade(jobGrade);
    }
}
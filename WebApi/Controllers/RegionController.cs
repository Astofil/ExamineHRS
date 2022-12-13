using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class RegionController
{
    private readonly RegionService _regionService;
    public RegionController(RegionService regionService)
    {
        _regionService = regionService;
    }

    [HttpGet]
    public async Task<Response<List<GetRegionDto>>> GetRegion()
    {
        return await _regionService.GetRegion();
    }

    [HttpPut]
    public async Task<Response<AddRegionDto>> AddRegion(AddRegionDto region)
    {
        return await _regionService.AddRegion(region);
    }

    [HttpPost]
    public async Task<Response<AddRegionDto>> UpdateRegion(AddRegionDto region)
    {
        return await _regionService.UpdateRegion(region);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteRegion(int id)
    {
        return await _regionService.DeleteRegion(id);
    }
}
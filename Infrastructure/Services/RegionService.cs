using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class RegionService
{
    private readonly DataContext _context;
    public RegionService(DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<GetRegionDto>>> GetRegion()
    {
        var list = await _context.Regions.Select(t => new GetRegionDto()
        {
            RegionId = t.RegionId,
            RegionName = t.RegionName
        }).ToListAsync();
        return new Response<List<GetRegionDto>>(list);
    }

    public async Task<Response<AddRegionDto>> AddRegion(AddRegionDto region)
    {
        var newRegion = new Region()
        {
            RegionId = region.RegionId,
            RegionName = region.RegionName
        };
        _context.Regions.Add(newRegion);
        await _context.SaveChangesAsync();
        return new Response<AddRegionDto>(region);
    }

    public async Task<Response<AddRegionDto>> UpdateRegion(AddRegionDto region)
    {
        var find = await _context.Regions.FindAsync(region.RegionId);
        find.RegionId = region.RegionId;
        find.RegionName = region.RegionName;
        await _context.SaveChangesAsync();
        return new Response<AddRegionDto>(region);
    }

    public async Task<Response<string>> DeleteRegion(int id)
    {
        var find = await _context.Regions.FindAsync(id);
        _context.Regions.Remove(find);
        var response = await _context.SaveChangesAsync();
        if(response > 0)
            return new Response<string>("Region succesfully deleted");
        return new Response<string>(/*HttpStatusCode.BadRequest ,*/ "Object not found");
    }
}
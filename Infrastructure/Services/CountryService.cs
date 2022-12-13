using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CountryService
{
    private readonly DataContext _context;
    public CountryService(DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<GetCountryDto>>> GetCountry()
    {
        var list = await _context.Countries.Select(t => new GetCountryDto()
        {
            CountryId = t.CountryId,
            CountryName = t.CountryName,
            RegionName = t.Region.RegionName
        }).ToListAsync();
        return new Response<List<GetCountryDto>>(list);
    }

    public async Task<Response<AddCountryDto>> AddCountry(AddCountryDto country)
    {
        var newCountry = new Country()
        {
            CountryId = country.CountryId,
            CountryName = country.CountryName,
            RegionId = country.RegionId
        };
        _context.Countries.Add(newCountry);
        await _context.SaveChangesAsync();
        return new Response<AddCountryDto>(country);
    }

    public async Task<Response<AddCountryDto>> UpdateCountry(AddCountryDto country)
    {
        var find = await _context.Countries.FindAsync(country.CountryId);
        find.CountryId = country.CountryId;
        find.CountryName = country.CountryName;
        find.RegionId = country.RegionId;
        await _context.SaveChangesAsync();
        return new Response<AddCountryDto>(country);
    }

    public async Task<Response<string>> DeleteCountry(int id)
    {
        var find = await _context.Countries.FindAsync(id);
        _context.Countries.Remove(find);
        var response = await _context.SaveChangesAsync();
        if(response > 0)
            return new Response<string>("Country succesfully deleted");
        return new Response<string>(/*HttpStatusCode.BadRequest ,*/ "Object not found");
    }
}
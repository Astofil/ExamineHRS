using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class LocationService
{
    private readonly DataContext _context;
    public LocationService(DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<GetLocationDto>>> GetLocation()
    {
        var list = await _context.Locations.Select(t => new GetLocationDto()
        {
            LocationId = t.LocationId,
            StreetAddress = t.StreetAddress,
            PostalCode = t.PostalCode,
            City = t.City,
            StateProvince = t.StateProvince,
            CountryName = t.Country.CountryName
        }).ToListAsync();
        return new Response<List<GetLocationDto>>(list);
    }

    public async Task<Response<AddLocationDto>> AddLocation(AddLocationDto location)
    {
        var newLocation = new Location()
        {
            LocationId = location.LocationId,
            StreetAddress = location.StreetAddress,
            PostalCode = location.PostalCode,
            City = location.City,
            StateProvince = location.StateProvince,
            CountryId = location.CountryId
        };
        _context.Locations.Add(newLocation);
        await _context.SaveChangesAsync();
        return new Response<AddLocationDto>(location);
    }

    public async Task<Response<AddLocationDto>> UpdateLocation(AddLocationDto location)
    {
        var find = await _context.Locations.FindAsync(location.CountryId);
        find.LocationId = location.LocationId;
        find.StreetAddress = location.StreetAddress;
        find.PostalCode = location.PostalCode;
        find.City = location.City;
        find.StateProvince = location.StateProvince;
        find.CountryId = location.CountryId;
        await _context.SaveChangesAsync();
        return new Response<AddLocationDto>(location);
    }

    public async Task<Response<string>> DeleteLocation(int id)
    {
        var find = await _context.Locations.FindAsync(id);
        _context.Locations.Remove(find);
        var response = await _context.SaveChangesAsync();
        if(response > 0)
            return new Response<string>("Location succesfully deleted");
        return new Response<string>(/*HttpStatusCode.BadRequest ,*/ "Object not found");
    }
}
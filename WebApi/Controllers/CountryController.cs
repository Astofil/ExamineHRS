using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class CountryController
{
    private readonly CountryService _countryService;
    public CountryController(CountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet]
    public async Task<Response<List<GetCountryDto>>> GetCountry()
    {
        return await _countryService.GetCountry();
    }

    [HttpPut]
    public async Task<Response<AddCountryDto>> AddCountry(AddCountryDto country)
    {
        return await _countryService.AddCountry(country);
    }

    [HttpPost]
    public async Task<Response<AddCountryDto>> UpdateCountry(AddCountryDto country)
    {
        return await _countryService.UpdateCountry(country);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteCountry(int id)
    {
        return await _countryService.DeleteCountry(id);
    }
}
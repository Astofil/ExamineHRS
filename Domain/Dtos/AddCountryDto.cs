using Domain.Entities;

namespace Domain.Dtos;

public class AddCountryDto
{
    public int CountryId { get; set; }
    public string CountryName { get; set; }
    public int RegionId { get; set; }
}

using Data.Models;

namespace WebAPI.Repositories.CommonRepositories
{
    public interface ICommonRepository
    {
        public City GetCityFromId(long id);
        Country GetCountryFromId(long id);
        List<Country> GetCountries(long? cityId);
        List<City> GetCities(long? countryId);
    }
}

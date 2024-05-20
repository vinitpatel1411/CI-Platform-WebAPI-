using Data.Context;
using Data.Models;

namespace WebAPI.Repositories.CommonRepositories
{
    public class CommonRepository:ICommonRepository
    {
        private readonly DefaultContext _context;

        public CommonRepository(DefaultContext context) 
        {
            _context = context;
        }

        public City GetCityFromId(long id) 
        {
            return _context.Cities.Where(x => x.CityId == id).FirstOrDefault();
        }

        public Country GetCountryFromId(long id)
        {
            return _context.Countries.Where(x => x.CountryId == id).FirstOrDefault();
        }

        public List<Country> GetCountries(long? cityId)
        {
            if(cityId.HasValue && cityId.Value > 0)
            {
                var city = GetCityFromId(cityId.Value);
                return _context.Countries.Where(x => x.CountryId == city.CountryId).ToList();
            }
            else
                return _context.Countries.ToList();
        }

        public List<City> GetCities(long? countryId)
        {
            if(countryId.HasValue && countryId.Value > 0) 
                return _context.Cities.Where(x=> x.CountryId == countryId).ToList();
            else
                return _context.Cities.ToList();
        }
    }
}

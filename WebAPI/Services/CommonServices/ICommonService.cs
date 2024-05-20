using Data.Models;
using WebAPI.Data.DTO;

namespace WebAPI.Services.CommonServices
{
    public interface ICommonService
    {
        List<countryDTO> GetCountries(long? cityId);
        List<cityDTO> GetCities(long? countryId);
    }
}

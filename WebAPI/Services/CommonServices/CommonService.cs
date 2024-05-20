using AutoMapper;
using Data.Models;
using WebAPI.Data.DTO;
using WebAPI.Repositories.CommonRepositories;

namespace WebAPI.Services.CommonServices
{
    public class CommonService : ICommonService
    {
        private readonly IMapper _mapper;
        private readonly ICommonRepository _commonRepository;
        public CommonService(IMapper mapper, ICommonRepository commonRepository) 
        {
            _mapper = mapper;
            _commonRepository = commonRepository;
        }
        public List<cityDTO> GetCities(long? countryId)
        {
            var city = _commonRepository.GetCities(countryId);
            return _mapper.Map<List<cityDTO>>(city);
        }

        public List<countryDTO> GetCountries(long? cityId)
        {
            var country = _commonRepository.GetCountries(cityId);
            return _mapper.Map<List<countryDTO>>(country);
        }
    }
}

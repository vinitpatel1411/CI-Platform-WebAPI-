using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebAPI.Common;
using WebAPI.Services.CommonServices;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ICommonService _commonService;

        public CommonController(ICommonService commonService) 
        {
            _commonService = commonService;
        }

        [HttpGet]
        [Route("getcities")]
        public ActionResult GetCities(long? countryId)
        {
            var cities = _commonService.GetCities(countryId);
            return cities != null 
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS}, cities)) 
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.NoContent, new List<string> { Constants.NO_DATA }));
        }

        [HttpGet]
        [Route("getcountries")]
        public ActionResult GetCountries(long? cityId)
        {
            var countries = _commonService.GetCountries(cityId);
            return countries != null
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, countries))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.NoContent, new List<string> { Constants.NO_DATA }));
        }
    }
}

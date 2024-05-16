using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebAPI.Common;
using WebAPI.Services.MissionServices;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly IMissionService _missionService;
        public MissionController(IMissionService missionService) 
        {
            _missionService = missionService;
        }

        [HttpGet]
        [Route("missions")]
        public ActionResult GetMission(int userId) 
        {
            var missionList = _missionService.GetMissions(userId);
            return missionList != null 
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, missionList))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.NoContent, new List<string> { Constants.NO_DATA }));
        }
    }
}

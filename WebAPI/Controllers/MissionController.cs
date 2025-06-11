using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebAPI.Common;
using WebAPI.Data.DTO;
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

        [HttpPost]
        [Route("addMission")]
        public ActionResult AddMission(missionDTO missionDTO)
        {
            try
            {
                _missionService.AddMission(missionDTO);
                return this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }));
            }
            catch (Exception ex)
            {
                return this.Ok(new ApiResponse(HttpStatusCode.InternalServerError, new List<string> { Constants.ERROR }));
            }
        }

        [HttpGet]
        [Route("getMissionSkills")]
        public ActionResult GetMissionSkills()
        {
            var missionSkills = _missionService.GetMissionSkills();
            return missionSkills != null
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, missionSkills))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.NoContent, new List<string> { Constants.NO_DATA }));
        }

        [HttpGet]
        [Route("getSkills")]
        public ActionResult GetSkills()
        {
            var skills = _missionService.GetSkills();

            return skills != null
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, skills))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.NoContent, new List<string> { Constants.NO_DATA }));
        }

        [HttpGet]
        [Route("getMissionList")]
        public ActionResult GetMissionList()
        {
            var missions = _missionService.GetMissionList();

            return missions != null
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, missions))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.NoContent, new List<string> { Constants.NO_DATA }));
        }

        [HttpGet]
        [Route("getMissionSkills/{missionId}")]
        public ActionResult GetMissionSkils(long missionId) 
        {
            var missionSkills = _missionService.GetMissionSkills(missionId);

            return missionSkills != null
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, missionSkills))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.NoContent, new List<string> { Constants.NO_DATA }));
        }

        [HttpPost]
        [Route("updateMission")]
        public ActionResult UpdateMission(missionDTO missionDTO)
        {
            try
            {
                _missionService.UpdateMission(missionDTO);
                return this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }));
            }
            catch (Exception ex)
            {
                return this.Ok(new ApiResponse(HttpStatusCode.InternalServerError, new List<string> { Constants.ERROR }, ex.Message));
            }
        }

        [HttpDelete]
        [Route("deleteMission")]
        public ActionResult DeleteMission(long missionId)
        {
            try
            {
                _missionService.DeleteMission(missionId);
                return this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }));
            }
            catch (Exception ex)
            {
                return this.Ok(new ApiResponse(HttpStatusCode.InternalServerError, new List<string> { Constants.ERROR }, ex.Message));
            }
        }
    }
}

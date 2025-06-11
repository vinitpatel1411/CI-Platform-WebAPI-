using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebAPI.Common;
using WebAPI.Data.DTO;
using WebAPI.Services.MissionThemeServices;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionThemeController : ControllerBase
    {
        private readonly IMissionThemeService _missionThemeService;

        public MissionThemeController(IMissionThemeService missionThemeService)
        {
            _missionThemeService = missionThemeService;
        }

        [HttpGet]
        [Route("getMissionThemes")]
        public ActionResult GetMissionThemes()
        {
            var missionThemes = _missionThemeService.GetMissionThemes();
            return missionThemes != null
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, missionThemes))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.InternalServerError, new List<string> { Constants.ERROR }));
        }

        [HttpPost]
        [Route("addMissionTheme")]
        public ActionResult AddMissionTheme(string title)
        {
            try
            {
                _missionThemeService.AddMissionTheme(title);
                return this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }));
            }
            catch(Exception ex)
            {
                return this.Ok(new ApiResponse(HttpStatusCode.InternalServerError, new List<string>() { Constants.ERROR } , ex.Message ));
            }
        }

        [HttpGet]
        [Route("getMissionThemeFromId")]
        public ActionResult GetMissionThemeFromId(long id) 
        {
            var missionTheme = _missionThemeService.GetMissionThemefromId(id);
            return missionTheme != null
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, missionTheme))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.InternalServerError, new List<string> { Constants.ERROR }));
        }

        [HttpPost]
        [Route("editMissionTheme")]
        public ActionResult EditMissionTheme(missionThemeDTO missionThemeDTO)
        {
            try
            {
                _missionThemeService.EditMissionTheme(missionThemeDTO);
                return this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }));
            }
            catch (Exception ex)
            {
                return this.Ok(new ApiResponse(HttpStatusCode.InternalServerError, new List<string>() { Constants.ERROR }, ex.Message));
            }
        }

        [HttpDelete]
        [Route("deleteMissionTheme/{id}")]
        public ActionResult DeleteMissionTheme(long id)
        {
            try
            {
                _missionThemeService.DeleteMissionTheme(id);
                return this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }));
            }
            catch (Exception ex)
            {
                return this.Ok(new ApiResponse(HttpStatusCode.InternalServerError, new List<string>() { Constants.ERROR }, ex.Message));
            }
        }
    }
}

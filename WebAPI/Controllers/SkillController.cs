using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebAPI.Common;
using WebAPI.Data.DTO;
using WebAPI.Services.SkillServices;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillController (ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        [Route("getSkills")]
        public ActionResult GetSkills()
        {
            var skills = _skillService.GetSkills();

            return skills != null 
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS} , skills))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string>() { Constants.ERROR }));
        }

        [HttpPost]
        [Route("updateSkillStatus/{skillId}")]
        public ActionResult UpdateSkillStatus(long skillId)
        {
            try
            {
                _skillService.UpdateSkillStatus(skillId);
                return this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }));
            }
            catch(Exception ex)
            {
                return this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.ERROR } , ex.Message));
            }
        }

        [HttpPost]
        [Route("addSkill")]
        public ActionResult AddSkill(skillDTO skillDTO)
        {
            try
            {
                _skillService.AddSkill(skillDTO);
                return this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }));
            }
            catch (Exception ex)
            {
                return this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.ERROR }, ex.Message));
            }
        }

        [HttpPost]
        [Route("updateSkill")]
        public ActionResult UpdateSKill(skillDTO skillDTO)
        {
            try
            {
                _skillService.UpdateSkill(skillDTO);
                return this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }));
            }
            catch (Exception ex)
            {
                return this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.ERROR }, ex.Message));
            }
        }

        [HttpGet]
        [Route("getSkillById/{skillId}")]
        public ActionResult GetSkillById(long skillId) 
        {
            var skill = _skillService.GetSkillById(skillId);

            return skill != null
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, skill))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string>() { Constants.ERROR }));
        }
    }
}

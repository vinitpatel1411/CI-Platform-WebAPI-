using WebAPI.Data.DTO;

namespace WebAPI.Services.SkillServices
{
    public interface ISkillService
    {
        public List<skillDTO> GetSkills();
        public void UpdateSkillStatus(long skillId);
        public void AddSkill(skillDTO skillDTO);
        public void UpdateSkill(skillDTO skillDTO);
        public skillDTO GetSkillById(long skillId);
    }
}

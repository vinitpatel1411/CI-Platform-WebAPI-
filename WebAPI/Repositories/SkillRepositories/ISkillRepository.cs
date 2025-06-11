using Data.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data.DTO;

namespace WebAPI.Repositories.SkillRepositories
{
    public interface ISkillRepository
    {
        public List<skillDTO> GetSkills();
        public void UpdateSkillStatus(long skillId);
        public void AddSkill(Skill skill);
        public void UpdateSkill(Skill skill);
        public Skill GetSkillById(long id);
    }
}

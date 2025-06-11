using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data.DTO;

namespace WebAPI.Repositories.SkillRepositories
{
    public class SkillRepository:ISkillRepository
    {
        private readonly DefaultContext _context;
            
        public SkillRepository(DefaultContext context)
        {
            _context = context;
        }

        public List<skillDTO> GetSkills()
        {
            var skills = (from t in _context.Skills
                          //where t.Status == true
                          where t.DeletedAt == null
                          select new skillDTO
                          {
                              skillId = t.SkillId,
                              skillName = t.SkillName,
                              status = t.Status == true ? 1 : 0,
                          }).ToList();

            return skills;
        }

        public void UpdateSkillStatus(long skillId)
        {
            var skill = _context.Skills.Where(s => s.SkillId == skillId).FirstOrDefault();

            if(skill != null)
            {
                skill.Status = !skill.Status;
                _context.Skills.Update(skill);
            }
            _context.SaveChanges();
        }

        public void AddSkill(Skill skill)
        {
            _context.Skills.Add(skill); 
            _context.SaveChanges();
        }

        public void UpdateSkill(Skill skill)
        {
            _context.Skills.Update(skill);
            _context.SaveChanges();
        }

        public Skill GetSkillById(long id)
        {
            return _context.Skills.Where(s => s.SkillId == id).FirstOrDefault();
        }
    }
}

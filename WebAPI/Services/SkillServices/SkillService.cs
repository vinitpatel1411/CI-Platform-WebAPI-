using AutoMapper;
using Data.Models;
using WebAPI.Data.DTO;
using WebAPI.Repositories.SkillRepositories;

namespace WebAPI.Services.SkillServices
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;

        public SkillService(ISkillRepository skillRepository, IMapper mapper)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
        }

        public List<skillDTO> GetSkills()
        {
            return _skillRepository.GetSkills();
        }

        public void UpdateSkillStatus(long skillId)
        {
            _skillRepository.UpdateSkillStatus(skillId);    
        }

        public void AddSkill(skillDTO skillDTO)
        {
            var skill = _mapper.Map<Skill>(skillDTO);
            skill.CreatedAt = DateTime.Now;
            skill.Status = true;

            _skillRepository.AddSkill(skill);
        }

        public void UpdateSkill(skillDTO skillDTO)
        {
            var skill = _skillRepository.GetSkillById(skillDTO.skillId);
            if(skill != null)
            {
                skill.SkillName = skillDTO.skillName;
                skill.UpdatedAt = DateTime.Now;
                _skillRepository.UpdateSkill(skill);
            }
        }

        public skillDTO GetSkillById(long skillId)
        {
            return _mapper.Map<skillDTO>(_skillRepository.GetSkillById(skillId));
        }
    }
}

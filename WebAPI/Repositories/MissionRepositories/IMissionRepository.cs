using Data.Models;
using WebAPI.Data.DTO;

namespace WebAPI.Repositories.MissionRepositories
{
    public interface IMissionRepository
    {
        public List<missionListDTO> GetMissions(int userId);
        public void AddMission(Mission mission);
        public List<missionSkillDTO> GetMissionSkills();
        public List<skillDTO> GetSkills();
        public void AddMissionSkills(List<MissionSkill> missionSkills);
        public List<missionDTO> GetMissionList();
        public List<skillDTO> GetMissionSkills(long missionId);
        public void UpdateMission(Mission mission);
        public void UpdateMissionSkills(List<MissionSkill> missionSkills);
        public Mission GetMissionFromId(long missionId);
        public void DeleteMission(long missionId);
    }
}

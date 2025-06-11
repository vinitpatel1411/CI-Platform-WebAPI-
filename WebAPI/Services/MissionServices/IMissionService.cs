using WebAPI.Data.DTO;

namespace WebAPI.Services.MissionServices
{
    public interface IMissionService
    {
        public List<missionListDTO> GetMissions(int userId);
        public void AddMission(missionDTO missionDTO);
        public List<missionSkillDTO> GetMissionSkills();
        public List<skillDTO> GetSkills();
        public List<missionDTO> GetMissionList();
        public List<skillDTO> GetMissionSkills(long missionId);
        public void UpdateMission(missionDTO missionDTO);
        public void DeleteMission(long missionId);
    }
}

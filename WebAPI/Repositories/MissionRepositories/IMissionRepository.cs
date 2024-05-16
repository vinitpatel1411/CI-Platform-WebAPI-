using WebAPI.Data.DTO;

namespace WebAPI.Repositories.MissionRepositories
{
    public interface IMissionRepository
    {
        public List<missionListDTO> GetMissions(int userId);
    }
}

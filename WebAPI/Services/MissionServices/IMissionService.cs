using WebAPI.Data.DTO;

namespace WebAPI.Services.MissionServices
{
    public interface IMissionService
    {
        public List<missionListDTO> GetMissions(int userId);
    }
}

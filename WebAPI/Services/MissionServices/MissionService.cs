using WebAPI.Data.DTO;
using WebAPI.Repositories.MissionRepositories;

namespace WebAPI.Services.MissionServices
{
    public class MissionService:IMissionService
    {
        private readonly IMissionRepository _missionRepository;
        public MissionService(IMissionRepository missionRepository) 
        {
            _missionRepository = missionRepository;
        }
        public List<missionListDTO> GetMissions(int userId)
        {
            return _missionRepository.GetMissions(userId);
        }
    }
}

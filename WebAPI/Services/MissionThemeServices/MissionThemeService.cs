using AutoMapper;
using Data.Models;
using WebAPI.Data.DTO;
using WebAPI.Repositories.MissionRepositories;
using WebAPI.Repositories.MissionThemeRepositories;
using WebAPI.Services.MissionServices;

namespace WebAPI.Services.MissionThemeServices
{
    public class MissionThemeService : IMissionThemeService
    {
        private readonly IMissionThemesRepository _missionThemesRepository;
        private readonly IMapper _mapper;

        public MissionThemeService(IMissionThemesRepository missionThemesRepository, IMapper mapper)
        {
            _mapper = mapper;
            _missionThemesRepository = missionThemesRepository;
        }

        public List<missionThemeDTO> GetMissionThemes()
        {
            var missionThemes = _missionThemesRepository.GetMissionThemes();
            var misssionThemeDTOs = _mapper.Map<List<MissionTheme>,List<missionThemeDTO>>(missionThemes);
            return misssionThemeDTOs;
        }

        public void AddMissionTheme(string title)
        {
            _missionThemesRepository.AddMissionTheme(title);
        }

        public missionThemeDTO GetMissionThemefromId(long id)
        {
            var missionTheme = _missionThemesRepository.GetMissionThemefromId(id);
            var missionThemeDTO = _mapper.Map<missionThemeDTO>(missionTheme);
            return missionThemeDTO;
        }

        public void EditMissionTheme(missionThemeDTO missionThemeDTO)
        {
            _missionThemesRepository.EditMissionTheme(missionThemeDTO);
        }

        public void DeleteMissionTheme(long id)
        {
            _missionThemesRepository.DeleteMissionTheme(id);
        }
    }
}

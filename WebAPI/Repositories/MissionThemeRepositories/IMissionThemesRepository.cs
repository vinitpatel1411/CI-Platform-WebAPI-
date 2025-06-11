using Data.Models;
using WebAPI.Data.DTO;

namespace WebAPI.Repositories.MissionThemeRepositories
{
    public interface IMissionThemesRepository
    {
        public List<MissionTheme> GetMissionThemes();
        public void AddMissionTheme(string title);
        public MissionTheme GetMissionThemefromId(long id);
        public void EditMissionTheme(missionThemeDTO missionThemeDTO);
        public void DeleteMissionTheme(long id);
    }
}

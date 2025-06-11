using WebAPI.Data.DTO;

namespace WebAPI.Services.MissionThemeServices
{
    public interface IMissionThemeService
    {
        public List<missionThemeDTO> GetMissionThemes();
        public void AddMissionTheme(string title);
        public missionThemeDTO GetMissionThemefromId(long id);
        public void EditMissionTheme(missionThemeDTO missionThemeDTO);
        public void DeleteMissionTheme(long id);
    }
}

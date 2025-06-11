using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data.DTO;

namespace WebAPI.Repositories.MissionThemeRepositories
{
    public class MissionThemeRepository : IMissionThemesRepository
    {
        private readonly DefaultContext _context;
        public MissionThemeRepository(DefaultContext context) 
        {
            _context = context;
        }
        public List<MissionTheme> GetMissionThemes()
        {
            var missionThemes = _context.MissionThemes.Where( m=>m.Status == true).ToList();
            return missionThemes;
        }

        public void AddMissionTheme(string title)
        {
            var missionTheme = new MissionTheme();
            missionTheme.Title = title; 
            missionTheme.CreatedAt = DateTime.Now;
            missionTheme.Status = true;

            _context.MissionThemes.Add(missionTheme);
            _context.SaveChanges();
        }

        public MissionTheme GetMissionThemefromId(long id) 
        {
            var missionTheme = _context.MissionThemes.Where(m => m.MissionThemeId == id).FirstOrDefault();
            return missionTheme;
        }

        public void EditMissionTheme(missionThemeDTO missionThemeDTO)
        {
            var missionTheme = _context.MissionThemes.Where(m => m.MissionThemeId == missionThemeDTO.id).FirstOrDefault();
            if (missionTheme != null)
            {
                missionTheme.Title = !String.IsNullOrEmpty(missionThemeDTO.title) ? missionThemeDTO.title : missionTheme.Title;
                missionTheme.UpdatedAt = DateTime.Now;
            }
            _context.SaveChanges();
        }

        public void DeleteMissionTheme(long id)
        {
            var missionTheme = _context.MissionThemes.Where(m => m.MissionThemeId == id).FirstOrDefault();
            if (missionTheme != null)
            {
                missionTheme.Status = false;
                missionTheme.DeletedAt = DateTime.Now;
                _context.MissionThemes.Update(missionTheme);
            }
            _context.SaveChanges();
        }
    }
}

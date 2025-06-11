using AutoMapper;
using Data.Models;
using System.Globalization;
using WebAPI.Data.DTO;
using WebAPI.Repositories.MissionRepositories;

namespace WebAPI.Services.MissionServices
{
    public class MissionService:IMissionService
    {
        private readonly IMissionRepository _missionRepository;
        private readonly IMapper _mapper;
        public MissionService(IMissionRepository missionRepository, IMapper mapper) 
        {
            _missionRepository = missionRepository;
        }
        public List<missionListDTO> GetMissions(int userId)
        {
            return _missionRepository.GetMissions(userId);
        }

        public void AddMission(missionDTO missionDTO) 
        {
            List<MissionSkill> missionSkills = new List<MissionSkill>(); 
            var mission = new Mission
            {
                Title = missionDTO.title,
                Description = missionDTO.description,
                ShortDescription = missionDTO.shortDescription,
                Organization = missionDTO.organization,
                StartDate = missionDTO.startDate != null ? DateTime.ParseExact(missionDTO.startDate, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture) : (DateTime?)null,
                EndDate = missionDTO.endDate != null ? DateTime.ParseExact(missionDTO.endDate, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture) : (DateTime?)null,
                RegistrationDeadlineDate = missionDTO.registrationDeadlineDate != null ? DateTime.ParseExact(missionDTO.registrationDeadlineDate, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture) : (DateTime?)null,
                CityId = missionDTO.cityId ?? 0,
                CountryId = missionDTO.countryId ?? 0,
                TotalSeats = missionDTO.totalSeats ?? 0,
                ThemeId = missionDTO.themeId ?? 0,
                Availability = missionDTO.availability,
                MissionType = missionDTO.missionType,
                CreatedAt = DateTime.Now
            };
            //var mission = _mapper.Map<missionDTO, Mission>(missionDTO);
            _missionRepository.AddMission(mission);

            foreach(var skillDTO in missionDTO.skills)
            {
                var missionSkill = new MissionSkill
                {
                    MissionId = mission.MissionId,
                    SkillId = skillDTO.skillId,
                    CreatedAt = DateTime.Now
                };
                missionSkills.Add(missionSkill);
            }
            _missionRepository.AddMissionSkills(missionSkills);
        }

        public List<missionSkillDTO> GetMissionSkills()
        {
            return _missionRepository.GetMissionSkills();
        }

        public List<skillDTO> GetSkills()
        {
            return _missionRepository.GetSkills();
        }

        public List<missionDTO> GetMissionList()
        {
            return _missionRepository.GetMissionList();
        }

        public List<skillDTO> GetMissionSkills(long missionId)
        {
            return _missionRepository.GetMissionSkills(missionId);
        }

        public void UpdateMission(missionDTO missionDTO)
        {
            List<MissionSkill> missionSkills = new List<MissionSkill>();
            var mission = _missionRepository.GetMissionFromId(missionDTO.id);
            mission.MissionId = missionDTO.id;
            mission.Title = missionDTO.title;
            mission.Description = missionDTO.description;
            mission.ShortDescription = missionDTO.shortDescription;
            mission.Organization = missionDTO.organization;
            mission.StartDate = missionDTO.startDate != null ? DateTime.ParseExact(missionDTO.startDate, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture) : (DateTime?)null;
            mission.EndDate = missionDTO.endDate != null ? DateTime.ParseExact(missionDTO.endDate, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture) : (DateTime?)null;
            mission.RegistrationDeadlineDate = missionDTO.registrationDeadlineDate != null ? DateTime.ParseExact(missionDTO.registrationDeadlineDate, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture) : (DateTime?)null;
            mission.CityId = missionDTO.cityId ?? 0;
            mission.CountryId = missionDTO.countryId ?? 0;
            mission.TotalSeats = missionDTO.totalSeats ?? 0;
            mission.ThemeId = missionDTO.themeId ?? 0;
            mission.Availability = missionDTO.availability;
            mission.MissionType = missionDTO.missionType;
            mission.UpdatedAt = DateTime.Now;
            //var mission = _mapper.Map<missionDTO, Mission>(missionDTO);
            _missionRepository.UpdateMission(mission);

            foreach (var skillDTO in missionDTO.skills)
            {
                var missionSkill = new MissionSkill
                {
                    MissionId = mission.MissionId,
                    SkillId = skillDTO.skillId,
                    CreatedAt = DateTime.Now
                };
                missionSkills.Add(missionSkill);
            }
            _missionRepository.UpdateMissionSkills(missionSkills);
        }

        public void DeleteMission(long missionId)
        {
            _missionRepository.DeleteMission(missionId);
        }
    }
}

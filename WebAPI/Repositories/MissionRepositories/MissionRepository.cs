using Data.Context;
using Data.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Data.DTO;

namespace WebAPI.Repositories.MissionRepositories
{
    public class MissionRepository:IMissionRepository
    {
        private readonly DefaultContext _context;
        public MissionRepository(DefaultContext context) 
        {
            _context = context;
        }
        public List<missionListDTO> GetMissions(int userId)
        {
            //var missionCards = (from m in _context.Mission
            //                    join media in _context.MissionMedia on m.MissionId equals media.MissionId
            //                    join theme in _context.MissionTheme on m.ThemeId equals theme.MissionThemeId
            //                    join rating in _context.MissionRating on m.MissionId equals rating.MissionId into ratings
            //                    join goal in _context.GoalMission on m.MissionId equals goal.MissionId
            //                    join mApplication in _context.MissionApplication on m.MissionId equals mApplication.MissionId into mApplications
            //                    join mSkill in _context.MissionSkill on m.MissionId equals mSkill.MissionId
            //                    join skill in _context.Skill on mSkill.SkillId equals skill.SkillId
            //                    join favMission in _context.FavouriteMission on m.MissionId equals favMission.MissionId
            //                    join mApplied in _context.MissionApplication on m.MissionId equals mApplied.MissionId
            //                    join city in _context.City on m.CityId equals city.CityId
            //                    join country in _context.country on m.CountryId equals country.CountryId
            //                    where m.DeletedAt == null
            //                    select new missionListDTO
            //                    {
            //                        MissionId = m.MissionId,
            //                        MissionImage = media.MediaType == "Image" ? media.MediaName : string.Empty,
            //                        //MissionImage = (m.MissionMedia != null && m.MissionMedia.Count > 0) ? m.MissionMedia.Where(a => a.MediaType == "Image").FirstOrDefault().MediaName : string.Empty,
            //                        //MissionImagePath = (m.MissionMedia != null && m.MissionMedia.Count > 0) ? m.MissionMedia.Where(a => a.MediaType == "Image").FirstOrDefault().MediaPath : string.Empty,
            //                        MissionImagePath = media.MediaType == "Image" ? media.MediaPath : string.Empty,
            //                        City = city.Name,
            //                        CityId = m.CityId,
            //                        Country = country.Name,
            //                        CountryId = m.CountryId,
            //                        Theme = theme.Title,
            //                        ThemeId = m.ThemeId,
            //                        Title = m.Title,
            //                        ShortDescription = m.ShortDescription,
            //                        OrganizationName = m.OrganizationName,
            //                        Rating = Convert.ToInt32(ratings.Any() ? ratings.Average(r => r.Rating) : 0),
            //                        MissionType = m.MissionType,
            //                        GoalValue = goal.GoalValue == null ? 0 : goal.GoalValue,
            //                        GoalObjectiveText = String.IsNullOrEmpty(goal.GoalObjectiveText) ? string.Empty : goal.GoalObjectiveText,
            //                        StartDate = m.StartDate,
            //                        CreatedAt = m.CreatedAt,
            //                        EndDate = m.EndDate,
            //                        SeatsLeft = goal.GoalValue - mApplications.Count(),
            //                        Skill = String.IsNullOrEmpty(skill.SkillName) ? string.Empty : skill.SkillName,
            //                        IsFavourite = favMission.MissionId == 0 ? false : true,
            //                        MissionApplied = mApplied.MissionId == 0 ? false : true
            //                    }).OrderBy(x => x.MissionId);
            //var temp = missionCards.ToList();
            //return temp;
            var missionCards = _context.Missions
                .Where(m => m.DeletedAt == null)
                .Select(m => new missionListDTO
                {
                    MissionId = m.MissionId,
                    MissionImage = m.MissionMedia.Any(media => media.MediaType == "Image") ? m.MissionMedia.FirstOrDefault(media => media.MediaType == "Image").MediaName : string.Empty,
                    MissionImagePath = m.MissionMedia.Any(media => media.MediaType == "Image") ? m.MissionMedia.FirstOrDefault(media => media.MediaType == "Image").MediaPath : string.Empty,
                    City = m.City.Name,
                    CityId = m.CityId,
                    Country = m.Country.Name,
                    CountryId = m.CountryId,
                    Theme = m.Theme.Title,
                    ThemeId = m.ThemeId,
                    Title = m.Title,
                    ShortDescription = m.ShortDescription,
                    OrganizationName = m.OrganizationName,
                    Rating = m.MissionRatings.Any() ? (int)m.MissionRatings.Average(r => r.Rating) : 0,
                    MissionType = m.MissionType,
                    GoalValue = m.GoalMissions.Count > 0 ? Convert.ToInt32(m.GoalMissions.FirstOrDefault().GoalValue) : 0,
                    GoalObjectiveText = m.GoalMissions.Count > 0 ? m.GoalMissions.FirstOrDefault().GoalObjectiveText : string.Empty,
                    StartDate = m.StartDate,
                    CreatedAt = m.CreatedAt,
                    EndDate = m.EndDate,
                    SeatsLeft = m.GoalMissions.Count > 0 ? m.GoalMissions.FirstOrDefault().GoalValue - m.MissionApplications.Count() : 0,
                    Skill = m.MissionSkills.Count > 0 ? m.MissionSkills.FirstOrDefault().Skill.SkillName : string.Empty,
                    IsFavourite = m.FavouriteMissions.Count > 0 ? m.FavouriteMissions.Where(x => x.MissionId == m.MissionId && x.UserId == userId).Count() > 0 : false,
                    MissionApplied = m.MissionApplications.Count() > 0 ? true : false
                }).OrderBy(x => x.MissionId).ToList();

            return missionCards;
        }

        public List<missionListDTO> GetMissionsByFilter(missionSearchDTO missionSearchDTO)
        {
            var missionCards = GetMissions(Convert.ToInt32(missionSearchDTO.UserId));

            if (missionSearchDTO.CountryId != null && missionSearchDTO.CountryId.Count() > 0)
            {
                missionCards = missionCards.Where(m => missionSearchDTO.CountryId.Contains(m.CountryId)).ToList();
            }
            if (missionSearchDTO.CityId != null && missionSearchDTO.CityId.Count() > 0)
            {
                missionCards = missionCards.Where(m => missionSearchDTO.CityId.Contains(m.CityId)).ToList();
            }
            if (missionSearchDTO.ThemeId != null && missionSearchDTO.ThemeId.Count() > 0)
            {
                missionCards = missionCards.Where(m => missionSearchDTO.ThemeId.Contains(m.ThemeId)).ToList();
            }
            if (missionSearchDTO.SkillId != null && missionSearchDTO.SkillId.Count() > 0)
            {

                var x = _context.MissionSkills.Where(a => missionSearchDTO.SkillId.Contains(a.SkillId)).ToList();
                var list = new List<long>();

                foreach (var n in x)
                {
                    list.Add(n.MissionId);

                }
                missionCards = missionCards.Where(a => list.Contains(a.MissionId)).ToList();

            }

            if (!string.IsNullOrEmpty(missionSearchDTO.SearchByText))
            {
                missionCards = missionCards.Where(a => a.Title.ToLower().StartsWith(missionSearchDTO.SearchByText.ToLower()) || a.OrganizationName.ToLower().StartsWith(missionSearchDTO.SearchByText.ToLower())).ToList();
            }

            switch (missionSearchDTO.SortOrder)
            {
                case "Newest":
                    missionCards = missionCards.OrderBy(s => s.CreatedAt).ToList();
                    break;
                case "Oldest":
                    missionCards = missionCards.OrderByDescending(s => s.CreatedAt).ToList();
                    break;
                    // case 3:
                    //     missionCards = missionCards.OrderBy(s => s.EndDate).ToList();
                    //     break;
            }
            switch (missionSearchDTO.ExploreBy)
            {
                //case 0:
                //    missionCards.Missions = missionCards.Missions.ToList();
                //    break;
                //case 1:
                //    missionCards.Missions = missionCards.Missions.GroupBy(m => m.ThemeId).OrderByDescending(a => a.Count()).SelectMany(a => a).ToList();
                //    break;
                //case 2:
                //    missionCards.Missions = missionCards.Missions.Where(a => a.MissionRatings.Any()).OrderByDescending(a => a.MissionRatings.Average(r => Convert.ToInt64(r.Rating))).ToList();
                //    break;
                //case 3:
                //    missionCards.Missions = missionCards.Missions.OrderByDescending(a => a.FavoriteMissions.Count()).ToList();
                //    break;
            }

            return missionCards;
        }

        public List<missionListDTO> GetRelatedMission(relatedMissionDTO RelatedMissionDTO)
        {
            var missionCards = GetMissions(RelatedMissionDTO.UserId);

            var Relatedmissions = new List<missionListDTO>();

            var relatedcity = missionCards.Where(u => u.CityId == RelatedMissionDTO.CityId && u.MissionId != RelatedMissionDTO.MissionId).ToList();
            Relatedmissions.AddRange(relatedcity);

            if (Relatedmissions.Count() < 3)
            {
                var relatedCountry = missionCards.Where(u => u.CityId != RelatedMissionDTO.CityId && u.CountryId == RelatedMissionDTO.CountryId && u.MissionId != RelatedMissionDTO.MissionId).ToList();
                Relatedmissions.AddRange(relatedCountry);
            }
            if (Relatedmissions.Count() < 3)
            {
                var relatedTheme = missionCards.Where(u => u.CityId != RelatedMissionDTO.CityId && u.CountryId != RelatedMissionDTO.CountryId && u.ThemeId == RelatedMissionDTO.ThemeId && u.MissionId != RelatedMissionDTO.MissionId).ToList();
                Relatedmissions.AddRange(relatedTheme);
            }

            Relatedmissions = Relatedmissions.Take(3).ToList();

            return Relatedmissions;
        }

        public bool AddToFavourite(addToFavouriteDTO addToFavouriteDTO)
        {
            if (addToFavouriteDTO != null)
            {
                FavouriteMission existingFavouriteMission = _context.FavouriteMissions.Where(x => x.MissionId == addToFavouriteDTO.MissionId && x.UserId == addToFavouriteDTO.UserId).FirstOrDefault();
                if (existingFavouriteMission != null)
                {
                    _context.FavouriteMissions.Remove(existingFavouriteMission);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    FavouriteMission favouriteMission = new()
                    {
                        MissionId = addToFavouriteDTO.MissionId,
                        UserId = addToFavouriteDTO.UserId,
                        CreatedAt = DateTime.Now
                    };
                    _context.FavouriteMissions.Add(favouriteMission);
                    _context.SaveChanges();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public volunteeringMissionDTO GetVolunteeringMission(long missionId, long userId)
        {
            var missionRating = _context.MissionRatings.FirstOrDefault(x => x.MissionId == missionId && x.UserId == userId);
            var appliedVolunteers = _context.MissionApplications
                .Include(x => x.User)
                .Where(x => x.MissionId == missionId)
                .ToList();

            var mission = (from m in _context.Missions
                           where (m.DeletedAt == null && (m.MissionId == missionId))
                           select new volunteeringMissionDTO
                           {
                               MissionId = m.MissionId,
                               City = m.City.Name,
                               CityId = m.CityId,
                               CountryId = m.CountryId,
                               ThemeId = m.ThemeId,
                               Theme = m.Theme.Title,
                               Title = m.Title,
                               ShortDescription = m.ShortDescription,
                               Description = m.Description,
                               OrganizationName = m.OrganizationName,
                               UserRating = missionRating != null ? missionRating.Rating ?? 0 : 0,
                               Rating = (m.MissionRatings != null && m.MissionRatings.Count > 0) ? (int)m.MissionRatings.Where(x => x.MissionId == missionId).Average(x => x.Rating) : 0,
                               CountOfUsersRated = (m.MissionRatings != null) ? m.MissionRatings.Count(x => x.MissionId == missionId) : (int)0,
                               MissionType = m.MissionType,
                               GoalValue = (m.GoalMissions != null && m.GoalMissions.Count > 0) ? Convert.ToInt32(m.GoalMissions.FirstOrDefault().GoalValue) : 0,
                               GoalObjectiveText = (m.GoalMissions != null && m.GoalMissions.Count > 0) ? m.GoalMissions.FirstOrDefault().GoalObjectiveText : string.Empty,
                               StartDate = m.StartDate,
                               EndDate = m.EndDate,
                               SeatsLeft = (m.GoalMissions != null && m.GoalMissions.Count > 0) ? m.GoalMissions.FirstOrDefault().GoalValue - m.MissionApplications.Count() : 0,
                               IsFavourite = (m.FavouriteMissions != null && m.FavouriteMissions.Count > 0) ? m.FavouriteMissions.Where(x => x.MissionId == m.MissionId && x.UserId == userId).Count() > 0 : false,
                               missionSkills = m.MissionSkills.Where(x => x.Skill != null).Select(y => y.Skill.SkillName).ToList(),
                               missionMedias = m.MissionMedia.ToList(),
                               comments = m.Comments.Select(x => new Comment
                               {
                                   CommentId = x.CommentId,
                                   UserId = x.UserId,
                                   MissionId = x.MissionId,
                                   ApprovalStatus = x.ApprovalStatus,
                                   CommentMessage = x.CommentMessage,
                                   CreatedAt = x.CreatedAt,
                                   UpdatedAt = x.UpdatedAt,
                                   DeletedAt = x.DeletedAt,
                                   User = new User()
                                   {
                                       Id = x.User.Id,
                                       Avatar = x.User.Avatar,
                                       Firstname = x.User.Firstname,
                                       Lastname = x.User.Lastname,
                                   },
                               }).ToList(),
                               volunteres = appliedVolunteers.Select(x => new User
                               {
                                   Id = x.UserId,
                                   Avatar = x.User.Avatar,
                                   Firstname = x.User.Firstname,
                                   Lastname = x.User.Lastname
                               }).ToList(),
                           }).FirstOrDefault();
            return mission;
        }
        public bool AddRecommandToWorker(int missionId, int userId, List<recommandUserDTO> body)
        {
            var user = _context.Users.Where(a => a.Id == userId).FirstOrDefault();
            var link = "http://localhost:4200/volunteering-mission/" + missionId;
            string subject = "Mission Invitation";
            string mailBody = @"<body style=""font-family: Arial, sans-serif; margin: 0; padding: 0;"">
                                <div style=""max-width: 600px; margin: 20px auto; background-color: #fff; border-radius: 10px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); padding: 20px;"">
                                <h1 style=""color: #333; text-align: center;"">Mission Invitation</h1>
                                <div style=""margin-top: 20px;"">
                                <p>Hi there!</p>
                                <p>You have received a mission invitation from " + user.Firstname + " " + user.Lastname + @".</p>
                                <p><a href=" + link + @" style=""display: inline-block; background-color: #007bff; color: #fff; text-decoration: none; padding: 10px 20px; border-radius: 5px; transition: background-color 0.3s ease;"" target=""_blank"">View Invitation</a></p>
                                </div>
                                </div>
                                </body>";

            foreach (var x in body)
            {
                if (!string.IsNullOrEmpty(x.email))
                {
                    Helper.SendEmail(mailBody, subject, x.email);
                }
            }
            return true;
        }

        public void SaveMissionApplication(long missionId, int userId)
        {
            bool isAlreadyApplied = _context.MissionApplications
                .Any(x => x.UserId == userId && x.MissionId == missionId);

            if (isAlreadyApplied)
            {
                return;
            }

            var application = new MissionApplication
            {
                MissionId = missionId,
                UserId = userId,
                CreatedAt = DateTime.UtcNow
            };

            _context.MissionApplications.Add(application);
            _context.SaveChanges();
        }
        public void SaveComment(commentDTO commentObj)
        {
            Comment comment = new Comment()
            {
                MissionId = commentObj.MissionId,
                UserId = commentObj.UserId,
                CreatedAt = DateTime.UtcNow.ToLocalTime(),
                ApprovalStatus = commentObj.ApprovalStatus,
                CommentMessage = commentObj.commentMessage
            };
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
        public void SaveRatings(missionRatingDTO ratingsObj)
        {
            MissionRating existingRating = _context.MissionRatings.FirstOrDefault(r => r.MissionId == ratingsObj.MissionId && r.UserId == ratingsObj.UserId);

            if (existingRating != null)
            {
                existingRating.Rating = ratingsObj.Ratings;
                existingRating.CreatedAt = DateTime.UtcNow.ToLocalTime();
                _context.SaveChanges();
            }
            else
            {
                MissionRating ratings = new MissionRating()
                {
                    MissionId = ratingsObj.MissionId,
                    UserId = ratingsObj.UserId,
                    CreatedAt = DateTime.UtcNow.ToLocalTime(),
                    Rating = ratingsObj.Ratings
                };

                _context.MissionRatings.Add(ratings);
                _context.SaveChanges();
            }
        }

        public bool CheckMissionApplied(long missionId, int userId)
        {
            bool isAlreadyApplied = _context.MissionApplications
                .Any(x => x.UserId == userId && x.MissionId == missionId);

            return isAlreadyApplied;
        }
    }
}

﻿using System;
using System.Collections.Generic;

namespace Data.Models
{ 
    public partial class Mission
    {
        public Mission()
        {
            Comments = new HashSet<Comment>();
            FavouriteMissions = new HashSet<FavouriteMission>();
            GoalMissions = new HashSet<GoalMission>();
            MissionApplications = new HashSet<MissionApplication>();
            MissionMedia = new HashSet<MissionMedia>();
            MissionRatings = new HashSet<MissionRating>();
            MissionSkills = new HashSet<MissionSkill>();
            Stories = new HashSet<Story>();
        }

        public long MissionId { get; set; }
        public long ThemeId { get; set; }
        public long CityId { get; set; }
        public long CountryId { get; set; }
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? RegistrationDeadlineDate { get; set; }
        public string? MissionType { get; set; }
        public bool? Status { get; set; }
        public string? Organization { get; set; }
        public string? Availability { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public long? TotalSeats { get; set; }

        public virtual City City { get; set; } = null!;
        public virtual Country Country { get; set; } = null!;
        public virtual MissionTheme Theme { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<FavouriteMission> FavouriteMissions { get; set; }
        public virtual ICollection<GoalMission> GoalMissions { get; set; }
        public virtual ICollection<MissionApplication> MissionApplications { get; set; }
        public virtual ICollection<MissionMedia> MissionMedia { get; set; }
        public virtual ICollection<MissionRating> MissionRatings { get; set; }
        public virtual ICollection<MissionSkill> MissionSkills { get; set; }
        public virtual ICollection<Story> Stories { get; set; }
    }
}

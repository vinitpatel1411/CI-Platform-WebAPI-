﻿using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Skill
    {
        public Skill()
        {
            MissionSkills = new HashSet<MissionSkill>();
        }

        public long SkillId { get; set; }
        public string? SkillName { get; set; }
        public bool? Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<MissionSkill> MissionSkills { get; set; }
    }
}

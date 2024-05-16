﻿using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class MissionMedia
    {
        public long MissionMediaId { get; set; }
        public long MissionId { get; set; }
        public string? MediaName { get; set; }
        public string? MediaType { get; set; }
        public string? MediaPath { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Mission Mission { get; set; } = null!;
    }
}

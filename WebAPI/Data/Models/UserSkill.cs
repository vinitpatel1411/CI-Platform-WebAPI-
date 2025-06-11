using Data.Models;

namespace WebAPI.Data.Models
{
    public partial class UserSkill
    {
        public long UserSkillId { get; set; }
        public long SkillId { get; set; }
        public int userId { get;set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual Skill Skill { get; set; } = null!;
    }
}

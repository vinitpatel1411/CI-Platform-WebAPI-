namespace WebAPI.Data.DTO
{
    public class missionSkillDTO
    {
        public long missionId {  get; set; }
        public List<skillDTO> skills { get;set; }
    }

    public class skillDTO
    {
        public long skillId { get; set; }
        public string? skillName { get; set; }
        public int? status { get; set; }
    }
}

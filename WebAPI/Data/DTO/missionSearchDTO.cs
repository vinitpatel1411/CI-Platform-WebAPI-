namespace WebAPI.Data.DTO
{
    public class missionSearchDTO
    {
        public List<long>? CityId { get; set; }
        public List<long>? CountryId { get; set; }
        public List<long>? ThemeId { get; set; }
        public List<long>? SkillId { get; set; }
        public string? SortOrder { get; set; }
        public long? ExploreBy { get; set; }
        public string? SearchByText { get; set; }
        public long? UserId { get; set; }
    }
}

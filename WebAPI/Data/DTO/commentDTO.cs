namespace WebAPI.Data.DTO
{
    public class commentDTO
    {
        public long MissionId { get; set; }
        public int UserId { get; set; }

        public string? ApprovalStatus { get; set; }
        public string? commentMessage { get; set; }
    }
}

namespace WebAPI.Data.DTO
{
    public class missionDTO
    {
        public long id { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? shortDescription { get; set; }
        public string? organization { get; set; }
        public string? startDate { get; set; }
        public string? endDate { get; set; }
        public string? registrationDeadlineDate { get; set; }
        public long? cityId { get; set; }
        //public string? city { get; set; }
        public long? countryId { get; set; }
        //public string? country { get; set; }
        public long? totalSeats { get; set; }
        public long? themeId { get; set; }
        public string? availability { get; set;}
        public string? missionType { get; set; }

        public List<skillDTO> skills { get; set; }

    }
}

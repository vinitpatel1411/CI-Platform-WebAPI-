namespace WebAPI.Data.DTO
{
    public class recommandUserDTO
    {
        public int id { get; set; }
        public string? firstname { get; set; }

        public string? lastname { get; set; }

        public string? email { get; set; }
        public bool? completed { get; set; } = false;
    }
}

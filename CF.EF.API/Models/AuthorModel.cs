namespace CF.EF.API.Models
{
    public class AuthorModel
    {
        public long AuthorId { get; set; }
        public required string AuthorName { get; set; }
        public string? AuthorEmail { get; set; }
        public string? Remarks { get; set; }
    }
}

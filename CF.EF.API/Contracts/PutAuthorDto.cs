namespace CF.EF.API.Contracts
{
    public class PutAuthorDto
    {
        public required string AuthorName { get; set; }
        public string? AuthorEmail { get; set; }
        public string? Remarks { get; set; }
    }
}

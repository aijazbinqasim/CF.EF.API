namespace CF.EF.API.Contracts
{
    public class GetAuthorDto
    {
        public long AuthorId { get; set; }
        public required string AuthorName { get; set; }
        public string? AuthorEmail { get; set; }
        public string? Remarks { get; set; }
    }
}

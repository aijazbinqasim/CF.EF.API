using FluentValidation;

namespace CF.EF.API.Contracts
{
    public class PutAuthorDto
    {
        public required string AuthorName { get; set; }
        public string? AuthorEmail { get; set; }
        public string? Remarks { get; set; }
    }

    public class PutAuthorDtoValidator : AbstractValidator<PutAuthorDto>
    {
        public PutAuthorDtoValidator()
        {
            RuleFor(x => x.AuthorName)
                .NotEmpty();

            RuleFor(x => x.AuthorEmail)
                .EmailAddress()
                .When(x => x.AuthorEmail != null);
        }
    }
}

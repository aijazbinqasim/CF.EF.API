using FluentValidation;

namespace CF.EF.API.Contracts
{
    public class PostAuthorDto
    {
        public required string AuthorName { get; set; }
        public string? AuthorEmail { get; set; }
        public string? Remarks { get; set; }
    }

    public class PostAuthorDtoValidator : AbstractValidator<PostAuthorDto>
    {
        public PostAuthorDtoValidator()
        {
            RuleFor(x => x.AuthorName)
                .NotEmpty();

            RuleFor(x => x.AuthorEmail)
                .EmailAddress()
                .When(x => x.AuthorEmail != null);
        }
    }
}

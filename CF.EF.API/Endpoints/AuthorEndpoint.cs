using CF.EF.API.Contracts;
using CF.EF.API.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CF.EF.API.Endpoints
{
    public static class AuthorEndpoint
    {
        public static IEndpointRouteBuilder MapAuthorEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapPost("/authors", async ([FromBody] PostAuthorDto author, IAuthorService authorService,
                IValidator<PostAuthorDto> validator) =>
            {
                var vResult = await validator.ValidateAsync(author);

                if (!vResult.IsValid)
                    return Results.BadRequest(vResult.Errors.Select(e => e.ErrorMessage).ToList());
                
                var getCreatedAuthor = await authorService.CreateAuthorAsync(author);
                return Results.Created($"/authors/{getCreatedAuthor.AuthorId}", getCreatedAuthor);

            });

            app.MapGet("/authors", async (IAuthorService authorService) =>
            {
                var getAllAuthors =  await authorService.GetAuthorsAsync();
                return Results.Ok(getAllAuthors);

            });

            app.MapGet("/authors/{authorId:long}", async ([FromRoute] long authorId, IAuthorService authorService) =>
            {
                var author =  await authorService.GetAuthorByIdAsync(authorId);
                return author is not null ? Results.Ok(author) : Results.NotFound();

            });

            app.MapPut("/authors/{authorId:long}", async ([FromBody] PutAuthorDto author, [FromRoute] long authorId,
                IAuthorService authorService, IValidator<PutAuthorDto> validator) =>
            {
                var vResult = await validator.ValidateAsync(author);

                if (!vResult.IsValid)
                    return Results.BadRequest(vResult.Errors.Select(e => e.ErrorMessage).ToList());

                var updatedAuthor = await authorService.UpdateAuthorAsync(authorId, author);
                return updatedAuthor is not null ? Results.Ok(updatedAuthor) : Results.NotFound();

            });

            app.MapDelete("/authors/{authorId:long}", async ([FromRoute] long authorId, IAuthorService authorService) =>
            {
                var isAuthorDeleted =  await authorService.DeleteAuthorAsync(authorId);
                return isAuthorDeleted ? Results.NoContent() : Results.NotFound();

            });
            
            return app;
        }
    }
}

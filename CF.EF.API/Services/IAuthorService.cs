using CF.EF.API.Contracts;

namespace CF.EF.API.Services
{
    public interface IAuthorService
    {
        Task<GetAuthorDto> CreateAuthorAsync(PostAuthorDto author);
        Task<IEnumerable<GetAuthorDto>> GetAuthorsAsync();
        Task<GetAuthorDto> GetAuthorByIdAsync(long authorId);
        Task<GetAuthorDto> UpdateAuthorAsync(long authorId, PutAuthorDto author);
        Task<bool> DeleteAuthorAsync(long authorId);
    }
}

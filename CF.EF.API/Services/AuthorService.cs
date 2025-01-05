using AutoMapper;
using CF.EF.API.AppContext;
using CF.EF.API.Contracts;
using CF.EF.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CF.EF.API.Services
{
    public class AuthorService(AppDbContext context, IMapper mapper) : IAuthorService
    {
        private readonly AppDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<GetAuthorDto> CreateAuthorAsync(PostAuthorDto author)
        {
            try
            {
                var authorModel = _mapper.Map<AuthorModel>(author);
                _context.Authors.Add(authorModel);
                await _context.SaveChangesAsync();

                return _mapper.Map<GetAuthorDto>(authorModel);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAuthorAsync(long authorId)
        {
            try
            {
                var authorModel = await _context.Authors.FindAsync(authorId);

                if (authorModel == null)
                {
                    return false;
                }

                _context.Authors.Remove(authorModel);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<GetAuthorDto> GetAuthorByIdAsync(long authorId)
        {
            try
            {
                var authorModel = await _context.Authors.FindAsync(authorId);
                if (authorModel == null)
                {
                    return null!;
                }
                return _mapper.Map<GetAuthorDto>(authorModel);  
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetAuthorDto>> GetAuthorsAsync()
        {
            try
            {
                var authors = await _context.Authors.ToListAsync();
                return authors.Select(_mapper.Map<GetAuthorDto>);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<GetAuthorDto> UpdateAuthorAsync(long authorId, PutAuthorDto author)
        {
            try
            {
                var existingAuthor = await _context.Authors.FindAsync(authorId);
                if(existingAuthor == null)
                {
                    return null!;
                }

                _mapper.Map(author, existingAuthor);
                await _context.SaveChangesAsync();
                return _mapper.Map<GetAuthorDto>(existingAuthor);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

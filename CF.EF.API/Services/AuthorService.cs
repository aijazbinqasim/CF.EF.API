using CF.EF.API.AppContext;
using CF.EF.API.Contracts;
using CF.EF.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CF.EF.API.Services
{
    public class AuthorService(AppDbContext context) : IAuthorService
    {

        private readonly AppDbContext _context = context;

        public async Task<GetAuthorDto> CreateAuthorAsync(PostAuthorDto author)
        {
            try
            {
                var authorModel = new AuthorModel
                {
                    AuthorName = author.AuthorName,
                    AuthorEmail = author.AuthorEmail,
                    Remarks = author.Remarks
                };

                _context.Authors.Add(authorModel);
                await _context.SaveChangesAsync();

                return new GetAuthorDto
                {
                    AuthorId = authorModel.AuthorId,
                    AuthorName = authorModel.AuthorName,
                    AuthorEmail = authorModel.AuthorEmail,
                    Remarks = authorModel.Remarks
                };
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

                return new GetAuthorDto
                {
                    AuthorId = authorModel.AuthorId,
                    AuthorName = authorModel.AuthorName,
                    AuthorEmail = authorModel.AuthorEmail,
                    Remarks = authorModel.Remarks
                };
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
                return authors.Select(author => new GetAuthorDto
                {
                    AuthorId = author.AuthorId,
                    AuthorName = author.AuthorName,
                    AuthorEmail = author.AuthorEmail,
                    Remarks = author.Remarks
                });
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

                existingAuthor.AuthorName = author.AuthorName;
                existingAuthor.AuthorEmail = author.AuthorEmail;
                existingAuthor.Remarks = author.Remarks;

                await _context.SaveChangesAsync();
                return new GetAuthorDto
                {
                    AuthorId = existingAuthor.AuthorId,
                    AuthorName = existingAuthor.AuthorName,
                    AuthorEmail = existingAuthor.AuthorEmail,
                    Remarks = existingAuthor.Remarks
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

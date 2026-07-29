using BookLoan.API.Database;
using BookLoan.API.Entities;
using BookLoan.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookLoan.API.Repository;

public class AuthorRepository : IAuthorRepository
{
    private readonly AppDbContext _context;

    public AuthorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Create(Author author)
    {
        await _context.Author.AddAsync(author);
        await _context.SaveChangesAsync();
        return author.Id;
    }

    public async Task<Author?> GetById(Guid authorId)
    {
        return await _context.Author.FirstOrDefaultAsync(a => a.Id == authorId);
    }

    public async Task<Guid> Update(Author author)
    {
        _context.Author.Update(author);
        await _context.SaveChangesAsync();
        return author.Id;
    }

    public async Task Delete(Author author)
    {
        _context.Author.Remove(author);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Author>> GetAll()
    {
        return await _context.Author.ToListAsync();
    }
    
}
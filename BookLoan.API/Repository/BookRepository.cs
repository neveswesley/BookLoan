using BookLoan.API.Database;
using BookLoan.API.Entities;
using BookLoan.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookLoan.API.Repository;

public class BookRepository : IBookRepository
{
    private readonly AppDbContext _context;

    public BookRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Guid> Create(Book book)
    {
        await _context.Book.AddAsync(book);
        await _context.SaveChangesAsync();
        return book.Id;
    }

    public async Task<List<Book>> GetAll()
    {
        return await _context.Book.Include(b=>b.Author).ToListAsync();
    }

    public async Task<Book> GetById(Guid bookId)
    {
        return await _context.Book.Include(b=>b.Author).FirstOrDefaultAsync(b=>b.Id == bookId);
    }
}
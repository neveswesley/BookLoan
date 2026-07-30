using BookLoan.API.Database;
using BookLoan.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookLoan.API.Repository;

public class BookLoanRepository : IBookLoanRepository
{

    private readonly AppDbContext _context;

    public BookLoanRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Create(Entities.BookLoan bookLoan)
    {
        await _context.BookLoans.AddAsync(bookLoan);
        await _context.SaveChangesAsync();
        return bookLoan.Id;
    }

    public async Task<List<Entities.BookLoan>> GetAllBookLoansActive()
    {
        return await _context.
            BookLoans.
            Where(bl => bl.IsActive == true).Include(bl => bl.Book).ThenInclude(bl=>bl.Author).Include(bl=>bl.User)
            .ToListAsync();
    }
}
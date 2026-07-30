namespace BookLoan.API.Interfaces;
using BookLoan.API.Entities;

public interface IBookLoanRepository
{
    Task<Guid> Create(BookLoan bookLoan);
    Task<List<BookLoan>> GetAllBookLoansActive();
}
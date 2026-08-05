namespace BookLoan.API.Interfaces;
using BookLoan.API.Entities;

public interface IBookLoanRepository
{
    Task<Guid> Create(BookLoan bookLoan);
    Task<List<BookLoan>> GetAllBookLoansActive();
    Task<List<BookLoan>> GetBookLoanByUserId(Guid userId);
    Task<BookLoan> GetBookLoanById(Guid bookLoanId);
    Task ReturnBookLoan(Guid bookLoanId);
}
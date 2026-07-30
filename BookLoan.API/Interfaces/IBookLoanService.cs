using BookLoan.API.DTOs;

namespace BookLoan.API.Interfaces;
using BookLoan.API.Entities;

public interface IBookLoanService
{
    Task<Guid> Create(CreateBookLoanDto dto);
    Task<List<BookLoanResponseDto>> GetAllBookLoansActive();
}
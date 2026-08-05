using BookLoan.API.Entities;

namespace BookLoan.API.DTOs;

public class BookLoanResponseDto
{
    public BookResponseDto Book { get; set; } = new();
    public UserResponseDto User { get; set; } = new();
    public DateTime LoanDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}
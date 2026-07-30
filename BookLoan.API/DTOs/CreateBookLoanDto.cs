namespace BookLoan.API.DTOs;

public class CreateBookLoanDto
{
    public Guid BookId { get; set; }
    public Guid UserId { get; set; }
}
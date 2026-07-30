namespace BookLoan.API.Entities;

public class BookLoan : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid BookId { get; set; }
    public Book Book { get; set; }

    public DateTime LoanDate { get; set; }
    public DateTime? ReturnDate { get; set; }

    public BookLoan()
    {
        
    }

    public void Create(Guid userId, Guid bookId)
    {
        UserId = userId;
        BookId = bookId;
        LoanDate = DateTime.UtcNow;
        ReturnDate = LoanDate.AddDays(3);
    }
}
namespace BookLoan.API.DTOs;

public class CreateBookDto
{
    public string Name { get; set; } = string.Empty;
    public Guid AuthorId { get; set; }
}
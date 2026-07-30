namespace BookLoan.API.Entities;

public class Book : BaseEntity
{
    public string Title { get; private set; } = string.Empty;
    public Author Author { get; private set; }
    public Guid AuthorId { get; private set; }
    public bool IsAvailable { get; private set; }

    public Book()
    {
        
    }

    public Book(string title, Guid authorId)
    {
        Title = title;
        AuthorId = authorId;
        IsAvailable = true;
    }

    public void UpdateBook(string title)
    {
        Title = title;
    }

    public void CompleteLoan()
    {
        IsAvailable = false;
    }

    public void ReturnBook()
    {
        IsAvailable = true;
    }
    
}
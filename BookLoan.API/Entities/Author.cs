using BookLoan.API.DTOs;

namespace BookLoan.API.Entities;

public class Author : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public string Biography { get; private set; } = string.Empty;
    public List<Book> Books { get; private set; }

    public Author()
    {
    }

    public Author(string name, string biography)
    {
        Name = name;
        Biography = biography;
    }

    public void UpdateAuthor(string name, string biography)
    {
        Name = name;
        Biography = biography;
    }

    
}
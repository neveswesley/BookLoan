using BookLoan.API.Entities;

namespace BookLoan.API.Interfaces;

public interface IBookRepository
{
    Task<Guid> Create(Book book);
    Task<List<Book>> GetAll();
    Task<Book> GetById(Guid bookId);
}
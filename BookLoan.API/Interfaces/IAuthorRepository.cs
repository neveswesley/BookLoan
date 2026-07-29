using BookLoan.API.Entities;

namespace BookLoan.API.Interfaces;

public interface IAuthorRepository
{
    Task<Guid> Create(Author author);
    Task<List<Author>> GetAll();
    Task<Author?> GetById(Guid id);
    Task<Guid> Update(Author author);
    Task Delete(Author author);
}
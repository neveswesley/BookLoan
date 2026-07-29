using BookLoan.API.DTOs;
using BookLoan.API.Entities;

namespace BookLoan.API.Interfaces;

public interface IBookService
{
    Task<Guid> Create(CreateBookDto dto);
    Task<List<BookResponseDto>> GetAll();
    Task<BookResponseDto> GetById(Guid id);
    Task<Guid> Update(Guid bookId, UpdateBookDto dto);
    Task Delete(Guid bookId);
}
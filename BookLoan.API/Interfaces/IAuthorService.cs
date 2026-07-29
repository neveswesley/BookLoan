using BookLoan.API.DTOs;
using BookLoan.API.Entities;

namespace BookLoan.API.Interfaces;

public interface IAuthorService
{
    Task<Guid> Create(CreateAuthorDto dto);
    Task<AuthorResponseDto?> GetById(Guid authorId);
    Task<List<AuthorResponseDto>> GetAll();
    Task<Guid> Update(UpdateAuthorDto dto, Guid authorId);
    Task Delete(Guid author);
}
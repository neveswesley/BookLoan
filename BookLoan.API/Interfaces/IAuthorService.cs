using BookLoan.API.DTOs;
using BookLoan.API.Entities;

namespace BookLoan.API.Interfaces;

public interface IAuthorService
{
    Task Create(string name, string biography);
    Task<AuthorResponseDto?> GetById(Guid authorId);
    Task<List<AuthorResponseDto>> GetAll();
    Task<Guid> Update(UpdateAuthorDto dto, Guid authorId);
    Task Delete(Guid author);
}
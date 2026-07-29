using BookLoan.API.DTOs;
using BookLoan.API.Entities;
using BookLoan.API.Interfaces;
using BookLoan.API.Repository;

namespace BookLoan.API.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _repository;

    public AuthorService(IAuthorRepository repository)
    {
        _repository = repository;
    }

    public async Task Create(string name, string biography)
    {
        var author = new Author(name, biography);
        await _repository.Create(author);
    }

    public async Task<AuthorResponseDto?> GetById(Guid authorId)
    {
        var author = await _repository.GetById(authorId);
        return new AuthorResponseDto()
        {
            Name = author.Name,
            Biography = author.Biography
        };
    }

    public async Task<List<AuthorResponseDto>> GetAll()
    {
        var authors = await _repository.GetAll();
        return authors.Select(a => new AuthorResponseDto
        {
            Name = a.Name,
            Biography = a.Biography
        }).ToList();
    }

    public async Task<Guid> Update(UpdateAuthorDto dto, Guid authorId)
    {
        var author = await _repository.GetById(authorId);
        if (author == null)
            throw new NullReferenceException("Author not found");
        
        author.UpdateAuthor(dto.Name, dto.Biography);
        await _repository.Update(author);
        return author.Id;
    }

    public async Task Delete(Guid authorId)
    {
        var author =  await _repository.GetById(authorId);
        await _repository.Delete(author);
    }
}
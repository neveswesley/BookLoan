using BookLoan.API.DTOs;
using BookLoan.API.Entities;
using BookLoan.API.Interfaces;

namespace BookLoan.API.Services;

public class BookService : IBookService
{
    
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Guid> Create(CreateBookDto dto)
    {
        var book = new Book(dto.Name, dto.AuthorId);
        await _bookRepository.Create(book);
        return book.Id;
    }

    public async Task<List<BookResponseDto>> GetAll()
    {
        var books = await _bookRepository.GetAll();
        return books.Select(x=> new BookResponseDto
        {
            Title = x.Title,
            Author = x.Author.Name
        }).ToList();
    }

    public async Task<BookResponseDto> GetById(Guid id)
    {
        var book = await _bookRepository.GetById(id);
        return new BookResponseDto()
        {
            Title = book.Title,
            Author = book.Author.Name
        };
    }
}
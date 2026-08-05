using BookLoan.API.DTOs;
using BookLoan.API.Interfaces;

namespace BookLoan.API.Services;

public class BookLoanService : IBookLoanService
{
    private readonly IBookLoanRepository _bookLoanRepository;
    private readonly IBookRepository _bookRepository;

    public BookLoanService(IBookLoanRepository bookLoanRepository, IBookRepository bookRepository)
    {
        _bookLoanRepository = bookLoanRepository;
        _bookRepository = bookRepository;
    }

    public async Task<Guid> Create(CreateBookLoanDto dto)
    {
        var bookLoan = new Entities.BookLoan();
        var book = await _bookRepository.GetById(dto.BookId);

        bookLoan.Create(dto.UserId, dto.BookId);

        if (!book.IsAvailable)
            throw new Exception("Book is not available");

        book.CompleteLoan();

        await _bookRepository.Update(dto.BookId);
        await _bookLoanRepository.Create(bookLoan);
        return bookLoan.Id;
    }

    public async Task<List<BookLoanResponseDto>> GetAllBookLoansActive()
    {
        var bookLoans = await _bookLoanRepository.GetAllBookLoansActive();
        
        return bookLoans.Select(bl => new BookLoanResponseDto()
        {
            Book = new BookResponseDto()
            {
                Author = bl.Book.Author.Name,
                Title = bl.Book.Title
            },
            User = new UserResponseDto()
            {
                Name = bl.User.Name
            },
            LoanDate = bl.LoanDate,
            ReturnDate = bl.ReturnDate,
        }).ToList();
    }

    public async Task<List<BookLoanResponseDto>> GetBookLoanByUserId(Guid userId)
    {
        var bookLoans = await _bookLoanRepository.GetBookLoanByUserId(userId);

        return bookLoans.Select(bl => new BookLoanResponseDto()
        {
            Book = new BookResponseDto()
            {
                Title = bl.Book.Title,
                Author = bl.Book.Author.Name
            },
            User = new UserResponseDto()
            {
                Name = bl.User.Name
            },
            LoanDate = bl.LoanDate,
            ReturnDate = bl.ReturnDate
        }).ToList();
    }

    public async Task ReturnBook(Guid bookLoanId)
    {
        var bookLoan = await _bookLoanRepository.GetBookLoanById(bookLoanId);
        var book = await _bookRepository.GetById(bookLoan.BookId);
        bookLoan.ReturnBook();
        book.ReturnBook();
        _bookLoanRepository.ReturnBookLoan(bookLoanId);
        _bookRepository.ReturnBook(bookLoan.BookId);
    }
}
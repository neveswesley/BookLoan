using BookLoan.API.DTOs;

namespace BookLoan.API.Interfaces;

public interface IUserService
{
    Task<Guid> Create(CreateUserDto dto);
}
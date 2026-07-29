using BookLoan.API.DTOs;
using BookLoan.API.Entities;

namespace BookLoan.API.Interfaces;

public interface IUserRepository
{
    Task<Guid> Create(User user);
}
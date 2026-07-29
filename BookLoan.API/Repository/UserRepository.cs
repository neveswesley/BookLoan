using BookLoan.API.Database;
using BookLoan.API.DTOs;
using BookLoan.API.Entities;
using BookLoan.API.Interfaces;

namespace BookLoan.API.Repository;

public class UserRepository : IUserRepository
{
    
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Create(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return user.Id;
    }
}
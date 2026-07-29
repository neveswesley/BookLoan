using BookLoan.API.DTOs;
using BookLoan.API.Entities;
using BookLoan.API.Interfaces;

namespace BookLoan.API.Services;

public class UserService : IUserService
{
    
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Guid> Create(CreateUserDto dto)
    {
        var hash = _passwordHasher.Hash(dto.Password);

        var user = new User(dto.Name, dto.Email, hash);
        
        await _userRepository.Create(user);
        return user.Id;
    }
}
using BookLoan.API.Interfaces;
using BCrypt.Net;

using Microsoft.AspNetCore.Identity;

namespace BookLoan.API.Extensions;

public class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool Verify(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}
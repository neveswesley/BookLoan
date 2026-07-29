using BookLoan.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookLoan.API.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Author> Author { get; set; }
    public DbSet<Book> Book { get; set; }
    public DbSet<User> Users { get; set; }
}
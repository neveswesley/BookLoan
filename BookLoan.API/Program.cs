using System.Text.Json;
using BookLoan.API.Database;
using BookLoan.API.Extensions;
using BookLoan.API.Filters;
using BookLoan.API.Interfaces;
using BookLoan.API.Repository;
using BookLoan.API.Services;
using BookLoan.API.Validations.Book;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers(options => { options.Filters.Add<ExceptionFilter>(); })
    .AddJsonOptions(opt => { opt.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase; });

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IBookLoanService, BookLoanService>();
builder.Services.AddScoped<IBookLoanRepository, BookLoanRepository>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateBookValidation>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
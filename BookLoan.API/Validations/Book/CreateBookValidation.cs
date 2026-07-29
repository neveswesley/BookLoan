using BookLoan.API.DTOs;
using FluentValidation;
using FluentValidation.Validators;

namespace BookLoan.API.Validations.Book;

public class CreateBookValidation : AbstractValidator<CreateBookDto>
{
    public CreateBookValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
    }
}
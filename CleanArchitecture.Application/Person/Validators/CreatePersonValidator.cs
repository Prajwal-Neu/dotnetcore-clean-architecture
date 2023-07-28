using CleanArchitecture.Application.Person.Commands;
using FluentValidation;

namespace CleanArchitecture.Application.Person.Validators
{
    public class CreatePersonValidator : AbstractValidator<CreatePerson>
    {
        public CreatePersonValidator()
        {
            RuleFor(createPerson => createPerson.Name).NotNull().NotEmpty().Length(10, 50);
            RuleFor(createPerson => createPerson.Email).EmailAddress().NotEmpty().Length(10, 50);
        }
    }
}
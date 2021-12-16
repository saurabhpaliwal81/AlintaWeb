using FluentValidation;

namespace Application.Customers.Commands
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(v => v.FirstName)
                .MaximumLength(100)
                .NotEmpty();

            RuleFor(v => v.LastName)
                .MaximumLength(100)
                .NotEmpty();

            RuleFor(v => v.DateOfBirth)
               .NotEmpty();
        }
    }
}
using FluentValidation;

namespace Application.Customers.Commands
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
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
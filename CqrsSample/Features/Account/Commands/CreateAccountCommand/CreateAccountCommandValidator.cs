using FluentValidation;

namespace CqrsSample.Features.Account.Commands.CreateAccountCommand
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.EmailAddress).NotEmpty().MaximumLength(50).EmailAddress();
        }
    }
}

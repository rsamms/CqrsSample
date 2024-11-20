using CqrsSample.Common;
using FluentValidation;

namespace CqrsSample.Features.Account.Commands.DeleteAccountCommand
{
    public class DeleteAccountCommandValidator : AbstractValidator<DeleteAccountCommand>
    {
        public DeleteAccountCommandValidator()
        {
            RuleFor(x => x.Id).Must(ValidationRules.BeAValidGuid).WithMessage("The supplied id is invalid");
        }
    }
}

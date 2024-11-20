using CqrsSample.Common;
using FluentValidation;

namespace CqrsSample.Features.Account.Queries.GetByIdAccountQuery
{
    public class GetByIdAccountQueryValidator : AbstractValidator<GetByIdAccountQuery>
    {
        public GetByIdAccountQueryValidator()
        {
            RuleFor(x => x.Id).Must(ValidationRules.BeAValidGuid).WithMessage("The supplied id is invalid");
        }
    }
}

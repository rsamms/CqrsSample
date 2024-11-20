using FluentValidation;

namespace CqrsSample.Features.Account.Queries.GetAllAccountQuery
{
    public class GetAllAccountQueryValidator : AbstractValidator<GetAllAccountQuery>
    {
        public GetAllAccountQueryValidator()
        {
            RuleFor(x => x.SearchTerm).NotEmpty();
        }
    }
}

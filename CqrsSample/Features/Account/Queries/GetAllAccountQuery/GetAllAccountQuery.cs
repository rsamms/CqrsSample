using MediatR;

namespace CqrsSample.Features.Account.Queries.GetAllAccountQuery
{
    public class GetAllAccountQuery : IRequest<List<Entities.Account>>
    {
        public string SearchTerm { get; set; }
    }
}

using MediatR;

namespace CqrsSample.Features.Account.Queries.GetByIdAccountQuery
{
    public class GetByIdAccountQuery : IRequest<Entities.Account>
    {
        public string Id { get; set; }
    }
}

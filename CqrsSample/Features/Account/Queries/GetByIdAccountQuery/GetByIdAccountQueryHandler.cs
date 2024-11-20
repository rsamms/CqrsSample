using AutoMapper;
using CqrsSample.Framework.Sql;
using MediatR;

namespace CqrsSample.Features.Account.Queries.GetByIdAccountQuery
{
    public class GetByIdAccountQueryHandler(IMediator mediator, IMapper mapper, IRepository repository) : SqlQueryHandler<GetByIdAccountQueryHandler, GetByIdAccountQuery, Entities.Account>(mediator, mapper, repository)
    {
        public override async Task<Entities.Account> Handle(GetByIdAccountQuery request, CancellationToken cancellationToken)
        {
            // retrieve from data store

            var account = await Repository.GetById<Entities.Account>(Guid.Parse(request.Id));

            return account;
        }
    }
}

using AutoMapper;
using CqrsSample.Framework.MemCache;
using CqrsSample.Framework.Sql;
using MediatR;

namespace CqrsSample.Features.Account.Queries.GetAllAccountQuery
{
    public class GetAllAccountQueryHandler(IMediator mediator, IMapper mapper, ICacheProvider cacheProvider) : MemCacheQueryHandler<GetAllAccountQueryHandler, GetAllAccountQuery, List<Entities.Account>>(mediator, mapper, cacheProvider)
    {
        public override async Task<List<Entities.Account>> Handle(GetAllAccountQuery request, CancellationToken cancellationToken)
        {
            // retrieve from data store

            var accounts = await CacheProvider.Query<Entities.Account>(request.SearchTerm);

            return accounts;
        }
    }
}

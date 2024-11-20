using AutoMapper;
using CqrsSample.Framework.Mediatr;
using MediatR;

namespace CqrsSample.Framework.MemCache
{
    public abstract class
        MemCacheQueryHandler<THandler, TRequest, TResponse> : BaseQueryHandler<THandler, TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        protected MemCacheQueryHandler(IMediator mediator, IMapper mapper, ICacheProvider cacheProvider)
            : base(mediator, mapper)
        {
            CacheProvider = cacheProvider;
        }

        protected ICacheProvider CacheProvider { get; }
    }
}

using AutoMapper;
using CqrsSample.Framework.Mediatr;
using MediatR;

namespace CqrsSample.Framework.Sql
{
    public abstract class
         SqlQueryHandler<THandler, TRequest, TResponse>(IMediator mediator, IMapper mapper, IRepository repository) : BaseQueryHandler<THandler, TRequest, TResponse>(mediator, mapper)
         where TRequest : IRequest<TResponse>
    {
        protected IRepository Repository { get; } = repository;
    }
}

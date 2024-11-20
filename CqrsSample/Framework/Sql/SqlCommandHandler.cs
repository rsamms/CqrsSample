using AutoMapper;
using CqrsSample.Framework.Mediatr;
using MediatR;

namespace CqrsSample.Framework.Sql
{
    public abstract class
        SqlCommandHandler<THandler, TRequest, TResponse>(IMediator mediator, IMapper mapper, IRepository repository) : BaseCommandHandler<THandler, TRequest, TResponse>(mediator, mapper)
        where TRequest : ICommandRequest<TResponse>
    {
        protected IRepository Repository { get; } = repository;
    }
}

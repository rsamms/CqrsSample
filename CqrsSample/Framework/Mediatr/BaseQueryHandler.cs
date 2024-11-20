using AutoMapper;
using MediatR;

namespace CqrsSample.Framework.Mediatr
{
    public abstract class BaseQueryHandler<THandler, TRequest, TResponse>(IMediator mediator, IMapper mapper) : IRequestHandler<TRequest, TResponse>
       where TRequest : IRequest<TResponse>
    {
        protected IMediator Mediator { get; } = mediator;

        protected IMapper Mapper { get; } = mapper;

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}

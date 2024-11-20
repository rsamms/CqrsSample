using AutoMapper;
using MediatR;

namespace CqrsSample.Framework.Mediatr
{
    public abstract class BaseCommandHandler<THandler, TRequest, TResponse>(IMediator mediator, IMapper mapper) : ICommandHandler<TRequest, TResponse>
         where TRequest : ICommandRequest<TResponse>
    {
        protected IMediator Mediator { get; } = mediator;

        protected IMapper Mapper { get; } = mapper;

        public abstract Task<ICommandResponse<TResponse>> Handle(TRequest request, CancellationToken cancellationToken);
    }
}

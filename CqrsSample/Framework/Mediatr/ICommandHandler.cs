using MediatR;

namespace CqrsSample.Framework.Mediatr
{
    public interface ICommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, ICommandResponse<TResponse>>
        where TRequest : ICommandRequest<TResponse>
    {
    }
}

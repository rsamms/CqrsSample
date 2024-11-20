using MediatR;

namespace CqrsSample.Framework.Mediatr
{
    public interface ICommandRequest<TResponse> : IRequest<ICommandResponse<TResponse>>
    {
    }
}

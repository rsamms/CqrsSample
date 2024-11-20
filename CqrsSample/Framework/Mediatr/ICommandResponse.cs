namespace CqrsSample.Framework.Mediatr
{
    public interface ICommandResponse<TResponse>
    {
        TResponse Response { get; }

        bool IsSuccessful { get; }

        IEnumerable<string> Errors { get; }
    }
}

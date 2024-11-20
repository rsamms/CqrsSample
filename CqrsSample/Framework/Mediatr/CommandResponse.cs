namespace CqrsSample.Framework.Mediatr
{
    public class CommandResponse<TResponse> : ICommandResponse<TResponse>
    {
        public TResponse Response { get; set; }

        public bool IsSuccessful { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public static CommandResponse<TResponse> Succeeded(TResponse response)
        {
            return new CommandResponse<TResponse>
            {
                IsSuccessful = true,
                Response = response
            };
        }

        public static CommandResponse<TResponse> Failed(params string[] errors)
        {
            return new CommandResponse<TResponse>
            {
                IsSuccessful = false,
                Errors = new List<string>(errors)
            };
        }
    }
}

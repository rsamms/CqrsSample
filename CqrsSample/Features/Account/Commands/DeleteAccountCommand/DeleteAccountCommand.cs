using CqrsSample.Framework.Mediatr;

namespace CqrsSample.Features.Account.Commands.DeleteAccountCommand
{
    public class DeleteAccountCommand : ICommandRequest<bool>
    {
        public string Id { get; set; }
    }
}

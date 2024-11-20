using CqrsSample.Framework.Mediatr;

namespace CqrsSample.Features.Account.Commands.UpdateAccountCommand
{
    public class UpdateAccountCommand : ICommandRequest<bool>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

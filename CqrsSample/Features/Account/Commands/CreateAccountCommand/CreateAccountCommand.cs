using CqrsSample.Framework.Mediatr;

namespace CqrsSample.Features.Account.Commands.CreateAccountCommand
{
    public class CreateAccountCommand: ICommandRequest<CreateAccountCommandResponse>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }
    }
}

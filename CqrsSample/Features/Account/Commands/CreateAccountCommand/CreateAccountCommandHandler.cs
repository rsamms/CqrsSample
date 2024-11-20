using AutoMapper;
using CqrsSample.Framework.Mediatr;
using CqrsSample.Framework.Sql;
using MediatR;

namespace CqrsSample.Features.Account.Commands.CreateAccountCommand
{
    public class CreateAccountCommandHandler(IMediator mediator,
        IMapper mapper, IRepository repository) : SqlCommandHandler<CreateAccountCommandHandler, CreateAccountCommand,
        CreateAccountCommandResponse>(mediator,mapper,repository)
    {
        public override async Task<ICommandResponse<CreateAccountCommandResponse>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            // Save to data store
            var success = true;
            var account = await Repository.Save(new Entities.Account { EmailAddress = request.EmailAddress, FirstName = request.FirstName, LastName = request.LastName});

            return success ? CommandResponse<CreateAccountCommandResponse>.Succeeded(new CreateAccountCommandResponse { Id = account.AccountId, Success = true }) : CommandResponse<CreateAccountCommandResponse>.Failed();
        }
    }
}

using AutoMapper;
using CqrsSample.Framework.Mediatr;
using CqrsSample.Framework.Sql;
using MediatR;

namespace CqrsSample.Features.Account.Commands.DeleteAccountCommand
{
    public class DeleteAccountCommandHandler(IMediator mediator,
        IMapper mapper, IRepository repository) : SqlCommandHandler<DeleteAccountCommandHandler, DeleteAccountCommand,
        bool>(mediator, mapper, repository)
    {
        public override async Task<ICommandResponse<bool>> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var success = Guid.TryParse(request.Id, out var accountId);
            
            if (success)
            {
                await Repository.Delete(accountId);
                return CommandResponse<bool>.Succeeded(true);
            }

            return CommandResponse<bool>.Failed();
        }
    }
}

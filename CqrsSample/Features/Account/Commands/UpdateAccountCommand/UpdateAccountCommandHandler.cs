using AutoMapper;
using CqrsSample.Framework.Mediatr;
using CqrsSample.Framework.Sql;
using MediatR;

namespace CqrsSample.Features.Account.Commands.UpdateAccountCommand
{
    public class UpdateAccountCommandHandler(IMediator mediator,
        IMapper mapper, IRepository repository) : SqlCommandHandler<UpdateAccountCommandHandler, UpdateAccountCommand,
        bool>(mediator, mapper, repository)
    {
        public override async Task<ICommandResponse<bool>> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            await Repository.Save(new Entities.Account { FirstName = request.FirstName, LastName = request.LastName });

            return CommandResponse<bool>.Succeeded(true);
        }
    }
}

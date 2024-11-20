using CqrsSample.Features.Account.Commands.CreateAccountCommand;
using CqrsSample.Features.Account.Commands.DeleteAccountCommand;
using CqrsSample.Features.Account.Commands.UpdateAccountCommand;
using CqrsSample.Features.Account.Queries.GetByIdAccountQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CqrsSample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("", Name = "CreateAccountAsync")]
        [ProducesResponseType(typeof(CreateAccountCommandResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(void), StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateAccountAsync([FromBody] CreateAccountCommand createAccountCommand, CancellationToken cancellationToken)
        {
            var createAccountCommandResponse = await _mediator.Send(createAccountCommand, cancellationToken);

            if (createAccountCommandResponse.IsSuccessful)
            {
                return Ok(createAccountCommandResponse.Response);
            }

            return Conflict();
        }

        [HttpPut("", Name = "UpdateAccountAsync")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateAccountAsync([FromBody] UpdateAccountCommand updateAccountCommand, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(updateAccountCommand, cancellationToken);

            return response.IsSuccessful ? Ok(response.Response) : StatusCode(StatusCodes.Status500InternalServerError, "The account could not be updated");
        }

        [HttpDelete("", Name = "DeleteAccountAsync")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteAccountAsync([FromBody] DeleteAccountCommand deleteAccountCommand, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(deleteAccountCommand, cancellationToken);

            return response.IsSuccessful ? Ok(response.Response) : StatusCode(StatusCodes.Status500InternalServerError, "The account could not be updated");
        }

        [HttpGet("", Name = "GetByIdAccountAsync")]
        [ProducesResponseType(typeof(Features.Entities.Account), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdAccountAsync([FromQuery] string accountId, CancellationToken cancellationToken)
        {
            var account = await _mediator.Send(new GetByIdAccountQuery { Id = accountId }, cancellationToken);

            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using Confitec.Services.Handles.Users.Commands;
using Confitec.Services.QueryHandlers.Users.Queries;
using Confitec.Core.Exceptions;
using Confitec.Shared.Helpers;

namespace Confitec.Api.Controllers.V1
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            if (command is null) return UnprocessableEntity();

            try
            {
                var result = await _mediator.Send(command);

                return Ok(new ApiResponseResult { Data = result });
            }
            catch (DomainException e)
            {
                return BadRequest(new ApiResponseResult { Errors = e.Errors });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] EditUserCommand command)
        {
            if (command is null) return UnprocessableEntity();

            command.Id = id;

            try
            {
                var result = await _mediator.Send(command);

                return Ok(new ApiResponseResult { Data = result });
            }
            catch (DomainException e)
            {
                return BadRequest(new ApiResponseResult { Errors = e.Errors });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _mediator.Send(new DeleteUserCommand { Id = id });

                return NoContent();
            }
            catch (DomainException e)
            {
                return BadRequest(new ApiResponseResult { Errors = e.Errors });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _mediator.Send(new GetUserListQuery()));
            }
            catch (DomainException e)
            {
                return BadRequest(new ApiResponseResult { Errors = e.Errors });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                return Ok(await _mediator.Send(new GetUserQuery { Id = id}));
            }
            catch (DomainException e)
            {
                return BadRequest(new ApiResponseResult { Errors = e.Errors });
            }
        }
    }
}

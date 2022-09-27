using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using user.application.contracts.persistence;
using user.application.features.users.commands.DeleteUser;
using user.application.features.users.commands.InsertUser;
using user.application.features.users.commands.UpdateUser;
using user.application.features.users.queries.GetUserById;
using user.application.features.users.queries.GetUserByUsername;
using user.application.features.users.queries.GetUsers;
using user.domain.entities;

namespace user.api.Controllers
{
    [Route("users_api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById([FromQuery] GetUserByIdQuery request)
        {

            var result = await mediator.Send(request);

            if(result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("GetUserByUsername")]
        public async Task<IActionResult> GetUserByUsername([FromQuery] GetUserByUsernameQuery request)
        {

            var result = await mediator.Send(request);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetUsersQuery query)
        {
            var result = await mediator.Send(query);

            if (result==null || !result.Any())
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromQuery] DeleteUserCommands command)
        {
            var result = await mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
        {
            var result = await mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("InsertUser")]
        public async Task<IActionResult> InsertUser([FromBody] InsertUserCommand command)
        {
            var result = await mediator.Send(command);

            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return NoContent();
        }
    }
}

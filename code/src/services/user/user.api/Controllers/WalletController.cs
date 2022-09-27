using MediatR;
using Microsoft.AspNetCore.Mvc;
using user.application.features.wallets.commands.DeleteWallet;
using user.application.features.wallets.commands.InsertWallet;
using user.application.features.wallets.commands.UpdateWallet;
using user.application.features.wallets.queries.GetWalletById;
using user.application.features.wallets.queries.GetWallets;

namespace user.api.Controllers
{
    [Route("users_api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IMediator mediator;

        public WalletController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetWalletByIdQuery query)
        {
            if (query==null)
            {
                return BadRequest();
            }

            var result = await mediator.Send(query);

            if(result==null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] GetWalletsQuery query)
        {
            if (query == null)
            {
                return BadRequest();
            }

            var result = await mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("InsertWallet")]
        public async Task<IActionResult> Insert([FromBody] InsertWalletCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            var result = await mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("UpdateWallet")]
        public async Task<IActionResult> Update([FromBody] UpdateWalletCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            var result = await mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("DeleteWallet")]
        public async Task<IActionResult> Delete([FromQuery] DeleteWalletCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            var result = await mediator.Send(command);

            if (result == 0)
                return NotFound();

            return NoContent();
        }
    }
}

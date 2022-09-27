using MediatR;
using Microsoft.AspNetCore.Mvc;
using orders.appliaction.features.orders.commands.CheckoutOrder;
using orders.appliaction.features.orders.commands.DeleteOrder;
using orders.appliaction.features.orders.commands.UpdateOrder;
using orders.appliaction.features.orders.queries;
using orders.appliaction.models.OrderVM;

namespace orders.api.Controllers
{
    [Route("orders_api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrdersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetOrders")]
        public async Task<ActionResult<OrdersVM>> GetOrders([FromQuery] string? username)
        {
            var query = new GetOrdersQuery(username);

            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpPost("CheckoutOrder")]
        public async Task<IActionResult> CheckoutOrder([FromBody] CheckoutOrderCommand command)
        {       
            var result = await mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder([FromQuery] DeleteOrderCommand command)
        {
            var result = await mediator.Send(command);

            return NoContent();
        }

        [HttpPut("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
        {
            var result = await mediator.Send(command);

            return Ok(result);
        }
    }
}

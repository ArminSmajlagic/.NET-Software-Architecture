using basket.api.IRepos;
using basket.api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace basket.api.Controllers
{
    [Route("basket_api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketRepository repository;

        public BasketsController(IBasketRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("GetBasketByUsername")]
        public async Task<IActionResult> Get([FromQuery] string username)
        {
            if(username == null)
                return BadRequest();

            var result = await repository.GetBasket(username);

            if(result==null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("AddBasket")]
        public async Task<IActionResult> Post([FromBody] Basket basket)
        {
            if (basket == null)
                return BadRequest();

            var result = await repository.UpdateBasket(basket);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("DeleteBasket")]
        public async Task<IActionResult> Delete([FromQuery] string username)
        {
            if (username == null)
                return BadRequest();

            var result = await repository.DeleteBasket(username);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("CheckoutBasket")]
        public async Task<IActionResult> Checkout([FromBody] BasketCheckout basketCheckout)
        {
            if (basketCheckout == null)
                return BadRequest();

            var result = await repository.Checkout(basketCheckout);

            if(result == null)
                return NotFound();

            return Ok(result);
        }
    }
}

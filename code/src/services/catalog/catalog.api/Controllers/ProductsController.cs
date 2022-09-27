using catalog.api.IRepos;
using catalog.api.Models;
using catalog.api.Models.SearchObject;
using Microsoft.AspNetCore.Mvc;

namespace catalog.api.Controllers
{
    [Route("catalog_api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository productsRepository;

        public ProductsController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] ProductSearchObject search) //search by product id and category id
        {
            if (search == null)
                return BadRequest();

            var result = await productsRepository.GetProduct(search);

            if(result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] ProductSearchObject search) //search by name for filter
        {
            if (search == null)
                return BadRequest();

            var result = await productsRepository.GetProducts(search);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            if (product == null)
                return BadRequest();

            var result = await productsRepository.Insert(product);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();


            var result = await productsRepository.Delete(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Product product)
        {
            if (product == null)
                return BadRequest();

            var result = await productsRepository.Update(product);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}

using catalog.api.IRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace catalog.api.Controllers
{
    [Route("catalog_api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesRepository categoriesRepository;

        public CategoriesController(ICategoriesRepository categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]string? id)
        {
            if(string.IsNullOrEmpty(id))
            {
                return Ok(await categoriesRepository.GetCategories());
            }
            else
            {
                var result = await categoriesRepository.GetCategory(id);

                if(result == null)
                    return NotFound();

                return Ok(result);
            }

            //return StatusCode(StatusCodes.Status500InternalServerError,"Somthing went wrong");
        }
    }
}

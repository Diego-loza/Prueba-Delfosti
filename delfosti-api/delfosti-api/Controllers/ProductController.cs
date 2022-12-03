using Microsoft.AspNetCore.Mvc;
using delfosti_api.Models;
using delfosti_api.Services;

namespace delfosti_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productoService;

        public ProductController(ProductService productoService) => _productoService = productoService;

        [HttpGet]
        public async Task<List<Producto>> Get() => await _productoService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Producto>> Get(string id)
        {
            var producto = await _productoService.GetAsync(id);

            if (producto is null)
            {
                return NotFound();
            }

            return producto;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Producto newProduct)
        {
            await _productoService.CreateAsync(newProduct);

            return NoContent();
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Producto updatedProduct)
        {
            var producto = await _productoService.GetAsync(id);

            if (producto is null)
            {
                return NotFound();
            }

            updatedProduct._id = producto._id;

            await _productoService.UpdateAsync(id, updatedProduct);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var producto = await _productoService.GetAsync(id);

            if (producto is null)
            {
                return NotFound();
            }

            await _productoService.RemoveAsync(id);

            return NoContent();
        }
    }
}

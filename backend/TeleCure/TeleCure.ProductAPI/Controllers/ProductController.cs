using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeleCure.ProductAPI.Helpers;

namespace TeleCure.ProductAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [AuthorizeToken]
        public IActionResult GetAll()
        {
            return Ok(StaticProductStore.Products);
        }

        [HttpGet("{id}")]
        [AuthorizeToken]
        public IActionResult Get(int id)
        {
            var product = StaticProductStore.Products.FirstOrDefault(p => p.Id == id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost]
        [AuthorizeToken]
        public IActionResult Create([FromBody] Product product)
        {
            product.Id = StaticProductStore.NextId++;
            StaticProductStore.Products.Add(product);
            return Ok(product);
        }

        [HttpPut("{id}")]
        [AuthorizeToken]
        public IActionResult Update(int id, [FromBody] Product updated)
        {
            var product = StaticProductStore.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            product.Name = updated.Name;
            product.Price = updated.Price;
            return Ok(product);
        }

        [HttpDelete("{id}")]
        [AuthorizeToken]
        public IActionResult Delete(int id)
        {
            var product = StaticProductStore.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            StaticProductStore.Products.Remove(product);
            return NoContent();
        }
    }
}

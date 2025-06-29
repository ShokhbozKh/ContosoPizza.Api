using ContosoPizza.Api.Data;
using ContosoPizza.Api.DTOs.ProductDto;
using ContosoPizza.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContosoPizza.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly PizzaDbContext _context;
        public ProductsController( PizzaDbContext pizzaDbContext)
        {
            _context = pizzaDbContext ?? throw new ArgumentNullException(nameof(pizzaDbContext));
        }
        // GET: api/products
        [HttpGet]
        public async Task <ActionResult<IEnumerable<ReadProductDto>>> GetProducts()
        {
            var findProduct = await _context.Products.ToListAsync();
            var resultProducts = findProduct.Select(p => new ReadProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price
            }).ToList();

            return Ok(resultProducts);
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadProductDto>> GetProductById(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }

            var readProductDto = new ReadProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };

            return Ok(readProductDto);
        }

        // POST api/products
        [HttpPost]
        public async Task<ActionResult<ReadProductDto>> Post([FromBody] CreateProductDto newProduct)
        {
            if (newProduct == null)
            {
                return BadRequest("Product data is null.");
            }
            var product = new Product
            {
                Name = newProduct.Name,
                Description = newProduct.Description,
                Price = newProduct.Price
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            var readProductDto = new ReadProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, readProductDto);
           
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProductDto editProduct)
        {
            if (editProduct == null )
            {
                return BadRequest("Product data is null or invalid.");
            }

           var resultId = await _context.Products.FindAsync(id);
            if (resultId == null || id<0)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            resultId.Name = editProduct.Name ?? resultId.Name;
            resultId.Description = editProduct.Description ?? resultId.Description;
            resultId.Price = editProduct.Price != 0 ? editProduct.Price : resultId.Price;
            _context.Products.Update(resultId);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();  

            return NoContent();
        }

    }
}

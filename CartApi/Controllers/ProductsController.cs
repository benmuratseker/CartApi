using CartApi.Entities;
using CartApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _context;

        public ProductsController(IProductRepository context)
        {
            _context = context;
            if (!_context.GetAllProducts().Any())
            {
                _context.CreateProduct(new Product { Code = "Prod1", Name = "Product1", Price = 11.0 });
                _context.CreateProduct(new Product { Code = "Prod2", Name = "Product2", Price = 22.99 });
                _context.CreateProduct(new Product { Code = "Prod3", Name = "Product3", Price = 15.0 });
                _context.CreateProduct(new Product { Code = "Prod4", Name = "Product4", Price = 47.75 });
                _context.CreateProduct(new Product { Code = "Prod5", Name = "Product5", Price = 5.9 });
            }

        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
           
            return await _context.GetAllProducts().ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(long id)
        {
            var product = await _context.GetAllProducts().FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(long id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }


            try
            {
                 _context.UpdateProduct(id,product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.CreateProduct(product);

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(long id)
        {
            var product = await _context.GetAllProducts().FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.DeleteProduct(id);
          

            return product;
        }

        private bool ProductExists(long id)
        {
            return _context.GetAllProducts().Any(e => e.Id == id);
        }
    }
}

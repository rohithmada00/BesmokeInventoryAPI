using BesmokeInventoryAPI.Data;
using BesmokeInventoryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BesmokeInventoryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductsController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get() => await _context.Products.ToListAsync();

        [HttpPost]
        public async Task<ActionResult<Product>> Post(Product product)
        {
            if (_context.Products.Any(p => p.Name == product.Name))
                return Conflict("Product with same name exists");

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product updated)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            product.Type = updated.Type;
            product.Size = updated.Size;
            product.Material = updated.Material;

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

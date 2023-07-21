using BesmokeInventoryAPI.Data;
using BesmokeInventoryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BesmokeInventoryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly AppDbContext _context;
        public InventoryController(AppDbContext context) => _context = context;

        [HttpPost("update")]
        public async Task<IActionResult> UpdateInventory(int productId, int amount)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) return NotFound();

            var operation = new InventoryOperation
            {
                ProductId = productId,
                AmountChanged = amount
            };
            _context.InventoryOperations.Add(operation);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("report")]
        public IActionResult InventoryReport()
        {
            var report = _context.Products.Select(p => new
            {
                p.Name,
                p.Type,
                p.Size,
                p.Material,
                Available = _context.InventoryOperations
                    .Where(io => io.ProductId == p.Id)
                    .Sum(io => io.AmountChanged)
            }).ToList();

            return Ok(report);
        }
    }

}

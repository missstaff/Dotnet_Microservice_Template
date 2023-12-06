using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiscountsController : ControllerBase
    {
        private readonly ILogger<DiscountsController> _logger;
        private readonly ApiDbContext _context;

        public DiscountsController(
            ILogger<DiscountsController> logger,
            ApiDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Get all discounts.
        /// </summary>
        /// <returns>A list of all discounts.</returns>
        [HttpGet("all", Name = "GetAllDiscounts")]
        public async Task<IActionResult> Get()
        {
            var allDiscounts = await _context.Discounts.ToListAsync();
            return Ok(allDiscounts);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly ApiDbContext _context;

        public CustomersController(
            ILogger<CustomersController> logger,
            ApiDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Get all customers.
        /// </summary>
        /// <returns>A list of all customers.</returns>
        [HttpGet("all", Name = "GetAllCustomers")]
        public async Task<IActionResult> Get()
        {
            var allCustomers = await _context.Customers.ToListAsync();
            return Ok(allCustomers);
        }
    }
}
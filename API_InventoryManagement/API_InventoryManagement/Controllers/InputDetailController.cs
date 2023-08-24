using API_InventoryManagement.Data;
using API_InventoryManagement.DTO;
using API_InventoryManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InputDetailController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InputDetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<InputDetailController>
        [HttpGet]
        public IActionResult Get()
        {
            var inputDetails = _context.InputDetails.ToList();
            return Ok(inputDetails);
        }

        [Authorize(Roles = "STAFF")]
        [HttpPost]
        public IActionResult Post([FromBody] InputDetailRequestDTO value)
        {
            var inputDetail = new InputDetail()
            {
                InputId = value.InputId,
                ProductId = value.ProductId,
                Quantity = value.Quantity,
                InputPrice = value.InputPrice
            };
            _context.InputDetails.Add(inputDetail);
            _context.SaveChanges();
            return Ok(inputDetail);
        }

    }
}

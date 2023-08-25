using API_InventoryManagement.Data;
using API_InventoryManagement.DTO;
using API_InventoryManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN,STAFF")]
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

        // GET input detail by input id
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var inputDetails = _context.InputDetails.Include(x=>x.Product).Where(x => x.InputId.Contains(id)).Select(x => new
            {
                x.ProductId,
                x.Product.ProductName,
                x.Quantity,
                x.ExpiredDate,
                x.QuantityInStock,
                x.InputPrice
            }).ToList();
            return Ok(inputDetails);
        }

        [HttpPost]
        public IActionResult Post([FromBody] InputDetailRequestDTO value)
        {
            var inputDetail = new InputDetail()
            {
                InputId = value.InputId,
                ProductId = value.ProductId,
                Quantity = value.Quantity,
                ExpiredDate = value.ExpiredDate,
                QuantityInStock = value.Quantity,
                InputPrice = value.InputPrice
            };
            _context.InputDetails.Add(inputDetail);
            _context.SaveChanges();
            return Ok(inputDetail);
        }
    }
}

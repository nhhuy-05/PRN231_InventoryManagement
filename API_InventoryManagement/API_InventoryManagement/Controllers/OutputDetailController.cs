using API_InventoryManagement.Data;
using API_InventoryManagement.DTO;
using API_InventoryManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace API_InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "ADMIN,STAFF")]
    public class OutputDetailController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OutputDetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<OutputDetailController>
        [HttpGet]
        public IActionResult Get()
        {
            var outputDetails = _context.OutputDetails.ToList();
            return Ok(outputDetails);
        }

        // GET api/<OutputDetailController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var outputDetail = _context.OutputDetails.Include(x => x.Product).Where(x => x.OutputId.Contains(id)).Select(x => new
            {
                x.ProductId,
                x.Product.ProductName,
                x.Quantity,
                x.InputId,
                x.OutputPrice
            }).ToList();
            return Ok(outputDetail);
        }

        [HttpPost]
        public IActionResult Post([FromBody] OutputDetailRequestDTO value)
        {
            var outputDetail = new OutputDetail()
            {
                OutputId = value.OutputId,
                ProductId = value.ProductId,
                Quantity = value.Quantity,
                InputId = value.InputId,
                OutputPrice = value.OutputPrice
            };
            _context.OutputDetails.Add(outputDetail);
            _context.SaveChanges();
            // update quantity in stock in input detail table
            var inputDetail = _context.InputDetails.Find(value.InputId, value.ProductId);
            inputDetail.QuantityInStock -= value.Quantity;
            _context.InputDetails.Update(inputDetail);
            _context.SaveChanges();
            return Ok(outputDetail);
        }


    }
}

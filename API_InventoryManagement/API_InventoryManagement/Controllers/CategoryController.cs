using API_InventoryManagement.Data;
using API_InventoryManagement.DTO;
using API_InventoryManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace API_InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult Get()
        {
            var categories = _context.Categories.ToList();
            return Ok(categories);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _context.Categories.Find(id);
            return Ok(category);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] CategoryRequestDTO value)
        {
            var category = new Category()
            {
                CategoryName = value.CategoryName,
                Description = value.Description
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok(category);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            var category = _context.Categories.Find(id);
            category.CategoryName = value;
            _context.SaveChanges();
            return Ok(category);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return Ok(category);
        }
    }
}

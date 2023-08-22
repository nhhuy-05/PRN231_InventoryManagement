using API_InventoryManagement.Data;
using API_InventoryManagement.DTO;
using API_InventoryManagement.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllProduct()
        {
            var products = _context.Products.ToList();
            if (products == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(products);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public IActionResult AddProuduct(ProductRequestDTO dto)
        {
            if (dto==null)
            {
                return BadRequest();
            }
            _context.Products.Add(_mapper.Map<Product>(dto));
            _context.SaveChanges();
            return Ok("Add successfully");
        }

        [HttpPut("{id}")]
        public IActionResult EditProduct(int id, ProductRequestDTO dto)
        {
            var product = _context.Products.FirstOrDefault(x=>x.Id== id);
            if (product == null) return BadRequest();
            product.ProductName= dto.ProductName;
            product.SupplierId= dto.SupplierId;
            product.UnitId = dto.UnitId;
            product.CategoryId = dto.CategoryId;
            product.Description= dto.Description;
            product.Picture = dto.Picture;
            _context.Products.Update(product);
            _context.SaveChanges();
            return Ok("Edit successfully");

        }
    }
}

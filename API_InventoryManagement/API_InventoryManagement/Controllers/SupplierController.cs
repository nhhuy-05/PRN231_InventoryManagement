using API_InventoryManagement.Data;
using API_InventoryManagement.DTO;
using API_InventoryManagement.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Cryptography.Xml;

namespace API_InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN,STAFF")]
    public class SupplierController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SupplierController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var sups = _context.Suppliers.ToList();
            if (sups==null)
            {
                return NotFound();
            }
            return Ok(sups);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var sup= _context.Suppliers.FirstOrDefault(x=>x.Id==id);
            if (sup==null)
            {
                return NotFound();
            }
            return Ok(sup);
        }
        [HttpPost]
        public IActionResult AddSupplier(SupplierRequestDTO dto)
        {
            if (dto==null)
            {
                return BadRequest();
            }
            _context.Suppliers.Add(_mapper.Map<Supplier>(dto));
            _context.SaveChanges();
            return Ok("Add successfully");
        }
        [HttpPut("{id}")]
        public IActionResult Edit( int id,SupplierRequestDTO dto)
        {
            var sup = _context.Suppliers.FirstOrDefault(x => x.Id == id);
            if (sup==null)
            {
                return NotFound();
            }
            sup.SupplierName = dto.SupplierName;
            sup.Address = dto.Address;
            sup.Email = dto.Email;
            sup.ContractDate = DateTime.Now;
            sup.Phone = dto.Phone;
            _context.Suppliers.Update(sup);
            _context.SaveChanges();
            return Ok("Update successfully");
        }
    }
}

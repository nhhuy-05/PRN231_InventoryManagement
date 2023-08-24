using API_InventoryManagement.Data;
using API_InventoryManagement.DTO;
using API_InventoryManagement.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace API_InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN,STAFF")]
    public class UnitController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UnitController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var units = _context.Units.ToList();
            if (units == null)
            {
                return NotFound();
            }
            return Ok(units);
        }
        [HttpGet("{id}")]
        public IActionResult GetUnit(int id)
        {
            var unit=_context.Units.FirstOrDefault(x=>x.Id== id);
            if (unit == null)
            {
                return NotFound();
            }
            return Ok(unit);
        }
        [HttpPost]
        public IActionResult AddUnit(UnitRequestDTO dto)
        {
            if (dto==null)
            {
                return BadRequest();
            }
            Unit u = new Unit();
            u.UnitName = dto.UnitName;
            _context.Units.Add(u);
            _context.SaveChanges();
            return Ok("Add successfully");
        }
        [HttpPut("{id}")]
        public IActionResult EditUnit(int id, string name)
        {
            var unit = _context.Units.FirstOrDefault(x => x.Id == id);
            if (unit == null)
            {
                return NotFound();
            }
            unit.UnitName= name;
            _context.Units.Update(unit);
            _context.SaveChanges();
            return Ok("Edit successfully");
        }
    }
}

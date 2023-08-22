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
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CustomerController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllCustomer()
        {
            var customer = _context.Customers.ToList();
            if (customer==null)
            {
                return NotFound();
            }
            
            return Ok(customer);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            if (customer==null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPost]
        public IActionResult AddCustomer(CustomerRequestDTO dto)
        {
            if (dto==null)
            {
                return BadRequest();
            }
            else
            {
                _context.Customers.Add(_mapper.Map<Customer>(dto));
                _context.SaveChanges();
                return Ok("Add successfully");
            }
        }
        [HttpPut]
        public IActionResult EditCustomer(int id, CustomerRequestDTO dto)
        {
            var customer = _context.Customers.FirstOrDefault(x=>x.Id== id);
            if (customer==null)
            {
                return NotFound();
            }
            customer.CustomerName = dto.CustomerName;
            customer.Email = dto.Email;
            customer.Phone = dto.Phone;
            customer.Address= dto.Address;
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return Ok("Update succesffuly");
        }
        [HttpDelete]
        public IActionResult DeleteCustoer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            if (customer==null)
            {
                return NotFound();
            }
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return Ok("Delete successfully");
        }
    }
}

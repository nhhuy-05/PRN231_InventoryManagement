using API_InventoryManagement.Data;
using API_InventoryManagement.DTO;
using API_InventoryManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace API_InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN,STAFF")]
    public class OutputController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public OutputController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Output
        [HttpGet]
        public IActionResult Get()
        {
            var outputs = _context.Outputs.ToList();
            return Ok(outputs);
        }

        // GET: api/Output/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var output = _context.Outputs.Find(id);
            return Ok(output);
        }

        // POST: api/Output
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OutputRequestDTO value)
        {
            try
            {
                // get current user id
                var user = await _userManager.FindByNameAsync(User.FindFirst(ClaimTypes.Name).Value);

                var output = new Output()
                {
                    Id = Guid.NewGuid().ToString(),
                    OutputDate = DateTime.Now,
                    CustomerId = value.CustomerId,
                    StaffId = user.Id,
                    Status = value.Status,
                    Note = value.Note
                };
                var outputResponse = new OutputResponseDTO()
                {
                    Id = output.Id,
                    OutputDate = output.OutputDate,
                    CustomerId = output.CustomerId,
                    StaffId = output.StaffId,
                    Status = output.Status,
                    Note = output.Note
                };

                _context.Outputs.Add(output);
                _context.SaveChanges();

                return Ok(outputResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

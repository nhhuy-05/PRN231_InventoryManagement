using API_InventoryManagement.Data;
using API_InventoryManagement.DTO;
using API_InventoryManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API_InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InputController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public InputController(ApplicationDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        // GET: api/Input
        [HttpGet]
        public IActionResult Get()
        {
            var inputs = _context.Inputs.ToList();
            return Ok(inputs);
        }

        // GET: api/Input/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var input = _context.Inputs.Find(id);
            return Ok(input);
        }

        // POST: api/Input
        [Authorize(Roles = "STAFF")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InputRequestDTO value)
        {
            // get current user id
            var user = await _userManager.FindByNameAsync(User.FindFirst(ClaimTypes.Name).Value);

            var input = new Input()
            {
                Id = Guid.NewGuid().ToString(),
                InputDate = DateTime.Now,
                SupplierId = value.SupplierId,
                StaffId = user.Id,
                Status = value.Status,
                Note = value.Note
            };
            _context.Inputs.Add(input);
            _context.SaveChanges();
            return Ok(input);
        }

        // PUT: api/Input/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]int id, [FromBody] string value)
        {
            var input = _context.Inputs.Find(id);
            input.Note = value;
            _context.SaveChanges();
            return Ok(input);
        }


    }
}

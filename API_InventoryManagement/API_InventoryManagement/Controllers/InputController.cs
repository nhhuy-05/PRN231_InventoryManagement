using API_InventoryManagement.Data;
using API_InventoryManagement.DTO;
using API_InventoryManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API_InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN,STAFF")]
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
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InputRequestDTO value)
        {
            try
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
                var inputResonse = new InputResponseDTO
                {
                    Id = input.Id,
                    InputDate = input.InputDate,
                    SupplierId = input.SupplierId,
                    StaffId = input.StaffId,
                    Status = input.Status,
                    Note = input.Note
                };
                _context.Inputs.Add(input);
                _context.SaveChanges();
                return Ok(inputResonse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Input/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] string value)
        {
            var input = _context.Inputs.Find(id);
            input.Note = value;
            _context.SaveChanges();
            return Ok(input);
        }

        //Get input by product id in input detail
        [HttpGet("GetInputByProductId/{id}")]
        public IActionResult GetInputByProductId(int id)
        {
            // get list of input id by product id has inputid, inputdate, productid,productname quanityinstock and inputprice and quantityinstock is greater than 0
            var input = _context.Inputs
                .Include(x => x.InputDetails)
                .ThenInclude(x => x.Product)
                .Where(x => x.InputDetails.Any(x => x.ProductId == id && x.QuantityInStock > 0))
                .Select(x => new
                {
                    x.Id,
                    x.InputDate,
                    x.InputDetails.FirstOrDefault(x => x.ProductId == id).ProductId,
                    x.InputDetails.FirstOrDefault(x => x.ProductId == id).Product.ProductName,
                    x.InputDetails.FirstOrDefault(x => x.ProductId == id).ExpiredDate,
                    x.InputDetails.FirstOrDefault(x => x.ProductId == id).QuantityInStock,
                    x.InputDetails.FirstOrDefault(x => x.ProductId == id).InputPrice
                }).ToList();
            return Ok(input);
        }

        //Get input by product id in input detail
        [HttpGet("GetInputByProductIdAndInpuId/{inputId}/{productid}")]
        public IActionResult GetInputByProductId(int productid, string inputId)
        {
            // get list of input id by product id has inputid, inputdate, productid,productname quanityinstock and inputprice and quantityinstock is greater than 0
            var input = _context.Inputs
                .Include(x => x.InputDetails)
                .ThenInclude(x => x.Product)
                .Where(x => x.InputDetails.Any(x => x.ProductId == productid && x.QuantityInStock > 0 && x.InputId == inputId))
                .Select(x => new
                {
                    x.Id,
                    x.InputDate,
                    x.InputDetails.FirstOrDefault(x => x.ProductId == productid).ProductId,
                    x.InputDetails.FirstOrDefault(x => x.ProductId == productid).Product.ProductName,
                    x.InputDetails.FirstOrDefault(x => x.ProductId == productid).ExpiredDate,
                    x.InputDetails.FirstOrDefault(x => x.ProductId == productid).QuantityInStock,
                    x.InputDetails.FirstOrDefault(x => x.ProductId == productid).InputPrice
                }).FirstOrDefault();
            return Ok(input);
        }


    }
}

using API_InventoryManagement.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN,STAFF")]
    public class ReportController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetInputPriceAndNumberOfInput")]
        public IActionResult GetInputPriceAndNumberOfInput()
        {
            DateTime today = DateTime.Today;
            DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            var inputSummary = new
            {
                TotalInputPrice = _context.InputDetails.Where(inputDetail =>
                    inputDetail.Input.InputDate >= firstDayOfMonth &&
                    inputDetail.Input.InputDate <= lastDayOfMonth)
                    .Sum(inputDetail => inputDetail.InputPrice),
                NumberOfInputsThisMonth = _context.Inputs.Count(input =>
                    input.InputDate >= firstDayOfMonth &&
                    input.InputDate <= lastDayOfMonth)
            };
            return Ok(inputSummary);
        }

        [HttpGet("GetOutputPriceAndNumberOfOutput")]
        public IActionResult GetOutputPriceAndNumberOfOutput()
        {
            DateTime today = DateTime.Today;
            DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            var outputSummary = new
            {
                TotalOutputPrice = _context.OutputDetails.Where(outputDetail =>
                                   outputDetail.Output.OutputDate >= firstDayOfMonth &&
                                                      outputDetail.Output.OutputDate <= lastDayOfMonth)
                    .Sum(outputDetail => outputDetail.OutputPrice),
                NumberOfOutputsThisMonth = _context.Outputs.Count(output =>
                                   output.OutputDate >= firstDayOfMonth &&
                                                      output.OutputDate <= lastDayOfMonth)
            };
            return Ok(outputSummary);
        }

        [HttpGet("GetNumberOfCustomerAndSupplier")]
        public IActionResult GetNumberOfCustomerAndSupplier()
        {
            var customerAndSupplierSummary = new
            {
                NumberOfCustomers = _context.Customers.Count(),
                NumberOfSuppliers = _context.Suppliers.Count()
            };
            return Ok(customerAndSupplierSummary);
        }

        [HttpGet("GetNumberOfProduct")]
        public IActionResult GetNumberOfProduct()
        {
            var numberOfProduct = _context.Products.Count();
            return Ok(numberOfProduct);
        }
    }
}

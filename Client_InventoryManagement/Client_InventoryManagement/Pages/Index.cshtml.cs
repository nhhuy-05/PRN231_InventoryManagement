using Client_InventoryManagement.DTO;
using Client_InventoryManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IdentityModel.Tokens.Jwt;

namespace Client_InventoryManagement.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }


        public async Task<IActionResult> OnGet()
        {
            // get token from cookie
            var jwtToken = Request.Cookies["jwtToken"];
            // check if token is null or empty
            if (string.IsNullOrEmpty(jwtToken))
            {
                // redirect to login page
                return RedirectToPage("/Account/Login");
            }
            else
            {
                // get user claims from token
                var token = new JwtSecurityToken(jwtToken);
                var claims = token.Claims;
                // check if user is admin
                if (claims.ElementAt(0).Value == "ADMIN")
                {
                    ReportService reportService = new ReportService();
                    var inputPriceAndNumberOfInput = await reportService.GetInputPriceAndNumberOfInput(jwtToken);
                    var outputPriceAndNumberOfOutput = await reportService.GetOutputPriceAndNumberOfOutput(jwtToken);
                    var numberOfCustomerAndSupplier = await reportService.GetNumberOfCustomerAndSupplier(jwtToken);
                    var numberOfProduct = await reportService.GetNumberOfProduct(jwtToken);
                    ViewData["TotalInputPrice"] = inputPriceAndNumberOfInput.TotalInputPrice;
                    ViewData["NumberOfInputsThisMonth"] = inputPriceAndNumberOfInput.NumberOfInputsThisMonth;
                    ViewData["TotalOutputPrice"] = outputPriceAndNumberOfOutput.TotalOutputPrice;
                    ViewData["NumberOfOutputsThisMonth"] = outputPriceAndNumberOfOutput.NumberOfOutputsThisMonth;
                    ViewData["NumberOfCustomers"] = numberOfCustomerAndSupplier.NumberOfCustomers;
                    ViewData["NumberOfSuppliers"] = numberOfCustomerAndSupplier.NumberOfSuppliers;
                    //ViewData["NumberOfProducts"] = numberOfProduct.NumberOfProducts;
                    return Page();
                }
                else
                {
                    // response a message
                    return RedirectToPage("/Error404");
                }
            }
        }
    }
}
using Client_InventoryManagement.DTO;
using Client_InventoryManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace Client_InventoryManagement.Pages.Customer
{
    public class AddCustomerModel : PageModel
    {
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
                    return Page();
                }
                else
                {
                    // response a message
                    return RedirectToPage("/Error404");
                }
            }
        }


        public async Task<IActionResult> OnPost(CustomerRequestDTO dto)
        {

            if (dto == null)
            {
                TempData["Message"] = "Please fill the data!";
                return Page();
            }
            else
            {
                CustomerService customerService = new CustomerService();
                
                // get token from cookie
                var jwtToken = Request.Cookies["jwtToken"];
                var response = customerService.AddCustomer(dto, jwtToken);
                if (response == HttpStatusCode.OK)
                {
                    TempData["Message"] = "Add customer successfully";
                    return RedirectToPage("/Customer/CustomerList");
                }
                else
                {
                    TempData["Message"] = "Add Customer failed";
                    return Page();
                }

            }
        }
    }
}
